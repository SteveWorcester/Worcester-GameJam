using UnityEngine;

public class TimeDilation : MonoBehaviour
{
    public float timeScaleAmount = .1f;
    public float dilationTimerInRealtimeSeconds = 1f;

    /// <summary>
    /// Don't use yet...
    /// </summary>
    public void StartTimeDilation()
    {
        Time.timeScale = timeScaleAmount;
        Time.fixedDeltaTime = timeScaleAmount * .02f; //.02f because this brings frame update to normal time.
    }

    /// <summary>
    /// Don't use yet...
    /// </summary>
    public void StopTimeDilation()
    {
        Time.timeScale += 1f;
        Mathf.Clamp(Time.timeScale, timeScaleAmount, 1f);
    }
}
