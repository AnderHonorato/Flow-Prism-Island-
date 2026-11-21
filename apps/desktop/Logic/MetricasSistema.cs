using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace AnderFlowPrismIsland.Logic;

/// <summary>Telemetria local de CPU, RAM, disco e interface de rede. Sem APIs externas.</summary>
public sealed class MetricasSistema
{
    [StructLayout(LayoutKind.Sequential)]
    private struct FileTime
    {
        public uint Baixo;
        public uint Alto;
        public ulong Ticks => ((ulong)Alto << 32) | Baixo;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct MemoriaWindows
    {
        public uint Tamanho;
        public uint Carga;
        public ulong FisicaTotal;
        public ulong FisicaLivre;
        public ulong PaginacaoTotal;
        public ulong PaginacaoLivre;
        public ulong VirtualTotal;
        public ulong VirtualLivre;
        public ulong VirtualEstendidaLivre;
    }

    [DllImport("kernel32.dll", SetLastError=true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetSystemTimes(out FileTime ocioso, out FileTime kernel, out FileTime usuario);

    [DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GlobalMemoryStatusEx(ref MemoriaWindows memoria);

    private ulong anteriorOcioso, anteriorKernel, anteriorUsuario;
    private bool temAmostra;

    public static string FormatarPercentual(double? valor)
        => valor.HasValue && double.IsFinite(valor.Value)
            ? Math.Clamp(Math.Round(valor.Value), 0, 100).ToString("0") + "%"
            : "Indisponível";

    public static string FormatarMemoria(long usada, long total)
        => total <= 0 ? "Indisponível" : $"{usada / 1073741824d:0.0} / {total / 1073741824d:0.0} GB";

    public EstadoMaquina Ler()
    {
        double? cpu = null;
        double? ram = null;
        string ramTexto = "Indisponível";
        double? disco = null;
        string discoTexto = "Indisponível";
        string rede = "Indisponível";
        try
        {
            if (GetSystemTimes(out var idle, out var kernel, out var user))
            {
                if (temAmostra)
                {
                    ulong tempo = (kernel.Ticks - anteriorKernel) + (user.Ticks - anteriorUsuario);
                    ulong livre = idle.Ticks - anteriorOcioso;
                    if (tempo > 0 && livre <= tempo) cpu = 100d * (tempo - livre) / tempo;
                }
                anteriorOcioso = idle.Ticks;
                anteriorKernel = kernel.Ticks;
                anteriorUsuario = user.Ticks;
                temAmostra = true;
            }
        }
        catch { }
        try
        {
            var m = new MemoriaWindows { Tamanho = (uint)Marshal.SizeOf<MemoriaWindows>() };
            if (GlobalMemoryStatusEx(ref m) && m.FisicaTotal > 0)
            {
                ram = 100d * (m.FisicaTotal - m.FisicaLivre) / m.FisicaTotal;
                ramTexto = FormatarMemoria((long)(m.FisicaTotal - m.FisicaLivre), (long)m.FisicaTotal);
            }
        }
        catch { }
        try
        {
            string root = Path.GetPathRoot(Environment.SystemDirectory) ?? "C:\\";
            var drive = DriveInfo.GetDrives().FirstOrDefault(d => d.IsReady && d.RootDirectory.FullName.Equals(root, StringComparison.OrdinalIgnoreCase));
            if (drive is { TotalSize: > 0 })
            {
                disco = 100d * (drive.TotalSize - drive.AvailableFreeSpace) / drive.TotalSize;
                discoTexto = FormatarMemoria(drive.TotalSize - drive.AvailableFreeSpace, drive.TotalSize);
            }
        }
        catch { }
        try
        {
            var nic = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback
                    && n.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                .OrderByDescending(n => n.Speed)
                .FirstOrDefault();
            if (nic is not null) rede = nic.Name;
        }
        catch { }

        return new EstadoMaquina(cpu, ram, disco, ramTexto, discoTexto, rede);
    }
}

public sealed record EstadoMaquina(double? Cpu, double? Ram, double? Disco, string RamTexto, string DiscoTexto, string Rede);
