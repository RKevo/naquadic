using Naquadic.Common.Enums;
using Naquadic.Logging;

namespace Naquadic.Thin;

public interface ISoundNode
{
    public Engine GetEngine();
    public void Start();
    public void Stop();
    public Engine.Listener GetListener();
    public Vec3f GetDirectionToListener();
    public float Volume { get; set; }
    public float Pan { get; set; }
    public float Pitch { get; set; }
    public PanMode PanMode { get; set; }
    public uint EnableSpatialization { get; set; }
    public Engine.Listener PinnedListener { get; set; }
    public Vec3f Position { get; set; }
    public Vec3f Velocity { get; set; }
    public AttenuationModel AttenuationModel { get; set; }
    public Positioning Positioning { get; set; }
    public float RollOff { get; set; }
    public float MinGain { get; set; }
    public float MaxGain { get; set; }
    public float MinDistance { get; set; }
    public float MaxDistance { get; set; }
    public Cone Cone { get; set; }
    public float DopplerFactor { get; set; }
    public float DirectionalAttenuationFactor { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="volumeStart"></param>
    /// <param name="volumeEnd"></param>
    /// <param name="fadeLength">Length of fade effect in PCM frames.</param>
    public void SetFadePCM(float volumeStart, float volumeEnd, ulong fadeLength);

    /// <summary>
    ///
    /// </summary>
    /// <param name="volumeStart"></param>
    /// <param name="volumeEnd"></param>
    /// <param name="fadeLength">Length of fade effect in milliseconds.</param>
    public void SetFadeMsec(float volumeStart, float volumeEnd, ulong fadeLength);
    public float GetCurrentFadeVolume();

    /// <summary>
    ///
    /// </summary>
    /// <param name="globalTime">Absolute global time in PCM frames.</param>
    public void ScheduleStartPCM(ulong globalTime);

    /// <summary>
    ///
    /// </summary>
    /// <param name="globalTime">Absolute global time in milliseconds.</param>
    public void ScheduleStartMsec(ulong globalTime);

    /// <summary>
    ///
    /// </summary>
    /// <param name="globalTime">Absolute global time in PCM frames.</param>
    public void ScheduleStopPCM(ulong globalTime);

    /// <summary>
    ///
    /// </summary>
    /// <param name="globalTime">Absolute global time in milliseconds.</param>
    public void ScheduleStopMsec(ulong globalTime);
    public uint IsPlaying { get; }
    public ulong Time { get; }
}
