using NAudio.CoreAudioApi;
namespace AnderFlowPrismIsland.Logic;
public sealed class VolumeSistema
{
    public static int LimitarPorcentagem(int volume) => Math.Clamp(volume,0,100);
    public int? Ler()
    {
        try { using var enumSaida = new MMDeviceEnumerator();
            using var device = enumSaida.GetDefaultAudioEndpoint(DataFlow.Render,Role.Multimedia);
            return (int)Math.Round(device.AudioEndpointVolume.MasterVolumeLevelScalar*100); }
        catch { return null; }
    }
    public bool? EstaMudo()
    {
        try { using var enumSaida=new MMDeviceEnumerator();
            using var device=enumSaida.GetDefaultAudioEndpoint(DataFlow.Render,Role.Multimedia);
            return device.AudioEndpointVolume.Mute; }
        catch { return null; }
    }
    public bool Ajustar(int valor)
    {
        try { using var enumSaida=new MMDeviceEnumerator();
            using var device=enumSaida.GetDefaultAudioEndpoint(DataFlow.Render,Role.Multimedia);
            device.AudioEndpointVolume.MasterVolumeLevelScalar=LimitarPorcentagem(valor)/100f;
            return true; }
        catch { return false; }
    }
    public bool DefinirMudo(bool mudo)
    {
        try { using var enumSaida=new MMDeviceEnumerator();
            using var device=enumSaida.GetDefaultAudioEndpoint(DataFlow.Render,Role.Multimedia);
            device.AudioEndpointVolume.Mute=mudo; return true; }
        catch { return false; }
    }
}