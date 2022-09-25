using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ToxicFamilyGames.AdsBrowser
{
        public class YandexSDK : MonoBehaviour
        {
            public static YandexSDK instance;
            [SerializeField]
            private string vkLink = "";

            [SerializeField]
            private bool isIntervalAd = false;
            [SerializeField]
            private int intevalAd = 5 * 60;
            [SerializeField]
            private GameObject intervalMsg;

            [DllImport("__Internal")]
            private static extern void ShowInterAd();
            [DllImport("__Internal")]
            private static extern void ShowRewardedAd();

            [DllImport("__Internal")]
            private static extern bool IsMobile();

            public bool isMobile()
            {
#if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
#endif
                return false;
            }

            [System.Serializable]
            public class AdEvent
            {
                public UnityEvent rewardAd = new UnityEvent();
            }

            [FormerlySerializedAs("OnRewarded")]
            [SerializeField]
            private AdEvent[] events = { new AdEvent() };
            public AdEvent[] Events
            {
                get { return events; }
                set { events = value; }
            }

            private void Awake()
            {
                if (instance == null)
                {
                    instance = this;
                }
                else
                {
                    Destroy(gameObject);
                }
            }


            double time = 0;
            void Update()
            {
                if (!isIntervalAd) return;
                time += Time.deltaTime;
                if (time > intevalAd - 30)
                {
                    if (intervalMsg != null)
                        intervalMsg.SetActive(true);
                }
                if (time > intevalAd)
                {
                    if (intervalMsg != null)
                        intervalMsg.SetActive(false);
                    ShowInter();
                    time = 0;
                }
            }

            public void ShowInter()
            {
#if !UNITY_EDITOR
            ShowInterAd();
#endif
            }

            private int rewardId = 0;
            public void ShowRewarded(int rewardId)
            {
                this.rewardId = rewardId;
#if !UNITY_EDITOR
            ShowRewardedAd();
#else
                OnRewarded();
#endif
            }

            public void OnRewarded()
            {
                events[rewardId].rewardAd.Invoke();
            }

            public void OnOpen()
            {
                print("RewardAdIsOpen");
                FocusSoundController.Silence(true);
            }

            public void OnClose()
            {
                print("RewardAdIsClose");
                FocusSoundController.Silence(false);
            }

            public void SetPrefferedLanguage(string lang)
            {
                print("Language set: " + lang);
                PlayerPrefs.SetString("selectedLanguage", lang);
            }

            public void LockCursor()
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            public void VK()
            {
                Application.OpenURL(vkLink);
            }

    }
}