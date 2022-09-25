using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace ToxicFamilyGames.AdsBrowser
{
    public class Banner : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void RecalculateRTB(
                string width,
                string height,
                string left,
                string top);

        [DllImport("__Internal")]
        private static extern void ActivityRTB(bool state);

        [DllImport("__Internal")]
        private static extern void RenderRTB();

        [HideInInspector]
        public RectTransform rt;
        private CanvasScaler scaler;
        private void Awake()
        {
            rt = (RectTransform)transform.GetChild(0);
            rt.GetComponent<RawImage>().color = Color.clear;
            rt.pivot = new Vector2(0, 1);
        }

        public Vector2 minSize = new(20, 20);

        static float timerRBT = 31;
        private void Update()
        {
            timerRBT += Time.unscaledDeltaTime;

            if (timerRBT >= 31)
            {
                timerRBT = 0;
                RecalculateRect();
                RenderRTB();
            }
        }

        public void Active(bool value)
        {
            ActivityRTB(value);
        }
        public void RecalculateRect()
        {
            if (!rt)
                rt = transform.GetChild(0).GetComponent<RectTransform>();

            if (!scaler)
                scaler = GetComponent<CanvasScaler>();

            float width = rt.rect.width;
            float height = rt.rect.height;

            float left = rt.localPosition.x;
            float top = -rt.localPosition.y;

            if (scaler.uiScaleMode == CanvasScaler.ScaleMode.ScaleWithScreenSize)
            {
                Vector2 multResolution = new Vector2(Screen.width / scaler.referenceResolution.x, Screen.height / scaler.referenceResolution.y);

                if (scaler.matchWidthOrHeight == 0)
                {
                    width *= multResolution.x;
                    height *= multResolution.x;
                    left *= multResolution.x;
                    top *= multResolution.x;
                }
                else if (scaler.matchWidthOrHeight == 1)
                {
                    width *= multResolution.y;
                    height *= multResolution.y;
                    left *= multResolution.y;
                    top *= multResolution.y;
                }
            }

            if (width < minSize.x) width = minSize.x;
            if (height < minSize.y) height = minSize.y;

            width = 100 * width / Screen.width;
            height = 100 * height / Screen.height;
            left = 100 * (Screen.width / 2 + left) / Screen.width;
            top = 100 * (Screen.height / 2 + top) / Screen.height;

            left = Mathf.Clamp(left, 0, 100);
            top = Mathf.Clamp(top, 0, 100);

            string _width = width.ToString().Replace(",", ".") + "%";
            string _height = height.ToString().Replace(",", ".") + "%";
            string _left = left.ToString().Replace(",", ".") + "%";
            string _top = top.ToString().Replace(",", ".") + "%";

            RecalculateRTB(_width, _height, _left, _top);
        }
    }
}
