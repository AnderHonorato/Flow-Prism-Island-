using NAudio.Wave;
using System;

namespace AnderFlowPrismIsland.Logic;

/// <summary>
/// Processa amplitude local de áudio de saída. Não grava nem transmite conteúdo.
/// O usuário precisa ativar explicitamente a captura no painel.
/// </summary>
public sealed class CapturaAudioReativo : IDisposable
{
    private WasapiLoopbackCapture? captura;
    private long ultimaAtualizacao;
    public event Action<double>? IntensidadeAtualizada;
    public bool Ativa => captura is not null;

    public void Iniciar()
    {
        if (captura is not null) return;
        var nova = new WasapiLoopbackCapture();
        try
        {
            nova.DataAvailable += DadosDisponiveis;
            nova.StartRecording();
            captura = nova;
        }
        catch
        {
            nova.DataAvailable -= DadosDisponiveis;
            nova.Dispose();
            throw;
        }
    }

    private void DadosDisponiveis(object? sender, WaveInEventArgs e)
    {
        if (captura is null) return;
        long agora = Environment.TickCount64;
        if (agora - ultimaAtualizacao < 55) return;
        ultimaAtualizacao = agora;
        double valor = IntensidadeAudio.CalcularBuffer(e.Buffer, e.BytesRecorded, captura.WaveFormat.BitsPerSample);
        IntensidadeAtualizada?.Invoke(valor);
    }

    public void Parar()
    {
        var atual = captura;
        captura = null;
        if (atual is null) return;
        atual.DataAvailable -= DadosDisponiveis;
        try { atual.StopRecording(); } catch { }
        atual.Dispose();
    }

    public void Dispose() => Parar();
}

public static class IntensidadeAudio
{
    public static double Calcular(ReadOnlySpan<float> amostras)
    {
        if (amostras.Length == 0) return 0;
        double soma = 0;
        foreach (float amostra in amostras)
        {
            if (!float.IsFinite(amostra)) continue;
            soma += Math.Clamp(amostra, -1f, 1f) * Math.Clamp(amostra, -1f, 1f);
        }
        return Math.Clamp(Math.Sqrt(soma / amostras.Length) * 4.5, 0, 1);
    }

    public static double CalcularBuffer(byte[] buffer, int bytesValidos, int bitsPorAmostra)
    {
        if (buffer is null || bytesValidos <= 0) return 0;
        bytesValidos = Math.Min(bytesValidos, buffer.Length);
        double soma = 0; int n = 0;
        if (bitsPorAmostra == 32)
        {
            for (int i = 0; i <= bytesValidos - 4; i += 16)
            {
                float amostra = BitConverter.ToSingle(buffer, i);
                if (!float.IsFinite(amostra)) continue;
                var v = Math.Clamp(amostra, -1f, 1f);
                soma += v * v; n++;
            }
        }
        else if (bitsPorAmostra == 16)
        {
            for (int i = 0; i <= bytesValidos - 2; i += 8)
            {
                var v = BitConverter.ToInt16(buffer, i) / 32768d;
                soma += v * v; n++;
            }
        }
        return n == 0 ? 0 : Math.Clamp(Math.Sqrt(soma / n) * 4.5, 0, 1);
    }
}
