using UnityEngine;

namespace Utils
{
    static class Viewport
    {
        public static float Height { get; private set; }
        public static float Width { get; private set; }

        static Viewport()
        {
            float screenRatio = (float)Screen.width / Screen.height;
            Height = Camera.main.orthographicSize * 2;
            Width = Height * screenRatio;
        }
    }
}