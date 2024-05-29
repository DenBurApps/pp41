using UnityEngine;
#if UNITY_IOS
using UnityEngine.iOS;
#endif
public static class OpenRateUsOnAwake
{
    public static void RateUs()
    {
        if (!PlayerPrefs.HasKey("Showed"))
        {
#if UNITY_IOS
        Device.RequestStoreReview();
#endif
            PlayerPrefs.SetInt("Showed", 1);
        }
    }
}
