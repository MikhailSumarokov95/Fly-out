using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToxicFamilyGames.AdsBrowser
{
    public class FocusSoundController : MonoBehaviour
    {
        void OnApplicationFocus(bool hasFocus)
        {
            Silence(!hasFocus);
        }

        void OnApplicationPause(bool isPaused)
        {
            Silence(isPaused);
        }
        public static void Silence(bool silence)
        {
            AudioListener.pause = silence;
            // Or / And
            AudioListener.volume = silence ? 0 : 1;
        }
    }
}