using UnityEngine;

namespace Skills
{
    public class TimeDilation : MonoBehaviour
    {
        //----------THE OLD CODE STARTS HERE----------
        /*
        private float _TimeScaleAmount = .05f;
        private float _DilationTimerInRealtimeSeconds = 1f;

        private void Update()
        {
            Time.timeScale += (1f / _DilationTimerInRealtimeSeconds) * Time.unscaledDeltaTime;
            Mathf.Clamp(Time.timeScale, 0f, 1f);
        }

        /// <summary>
        /// Don't use yet... 
        /// </summary>
        public void DilateTime()
        {
            Time.timeScale = 0f;
            WaitForSeconds wait = new WaitForSeconds(.5f);
            Time.timeScale = _TimeScaleAmount;
            Time.fixedDeltaTime = Time.timeScale * .02f; //.02f because this brings frame update to normal time.
        }
        */
    }
}


