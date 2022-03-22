using UnityEngine;

namespace AndroidHelper
{
    public class Listener
    {
        class Methods
        {
            public const string onPlayerInitialized = "onPlayerInitialized";
        }

        public static void OnPlayerInitialized()
        {
            if(Application.platform == RuntimePlatform.Android)
            {
                Android.GetCurrentActivity().Call(Methods.onPlayerInitialized);
            }
        }
    }

    public class Android
    {
        public static AndroidJavaObject GetCurrentActivity()
        {
            using (var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                return player.GetStatic<AndroidJavaObject>("currentActivity");
            }
        }

        public static string AndroidGetIntentStringExtra(string key)
        {
            using (var activity = GetCurrentActivity())
            {
                using (var intent = activity.Call<AndroidJavaObject>("getIntent"))
                {
                    return intent.Call<string>("getStringExtra", key);
                }
            }
        }

        public static int AndroidGetIntentIntExtra(string key, int defaultVal)
        {
            using (var activity = GetCurrentActivity())
            {
                using (var intent = activity.Call<AndroidJavaObject>("getIntent"))
                {
                    return intent.Call<int>("getIntExtra", key, defaultVal);
                }
            }
        }
    }
}
