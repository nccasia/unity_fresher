using System;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Lesson1.Scripts
{
    public class SdkLoginCallback : AndroidJavaProxy
    {
        public event Action<bool, string, string, int, AndroidJavaObject> OnLoginCallback;
        public SdkLoginCallback() : base("com.unity3d.player.ISdkLoginCallback") { }

        public void callback(bool isOK, string response, string message, int errorCode, AndroidJavaObject user)
        {
            Debug.Log("xxx.Unity.onResponse " + isOK + ";;; " + response + ";;; " + user.ToString());

            if (OnLoginCallback != null) OnLoginCallback(isOK, response, message, errorCode, user);
        }
    }

    public class IntroductionScript : MonoBehaviour
    {
        public Button btnToastDemo;
        public Button btnVnTac;
        public Button btnBabyShark;
        public Button btnBuyItem;
        public Text lblUserName;

        public AudioClip musicFile;

        private AndroidJavaObject unityActivity;
        void Start()
        {
            btnToastDemo.onClick.AddListener(MakeToast);
            btnBabyShark.onClick.AddListener(PlayBabyShark);
            btnVnTac.onClick.AddListener(startSignin);
            btnBuyItem.onClick.AddListener(BuyItem);

            unityActivity = GetCurrentActivity();

            var loginCallback = new SdkLoginCallback();
            loginCallback.OnLoginCallback += LoginCallback_OnLoginCallback;
            unityActivity.Call("InitSDK", loginCallback);
        }

        private void LoginCallback_OnLoginCallback(bool isOK, string response, string message, int errorCode, AndroidJavaObject user)
        {
            Debug.Log("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx " + response);
            lblUserName.text = user.Call<string>("getName");
        }

        private void PlayBabyShark()
        {
            var audioSource = FindObjectOfType<AudioSource>();

            audioSource.PlayOneShot(musicFile);
        }

        private void MakeToast()
        {
#if UNITY_ANDROID
            ShowAndroidToast("Hello world!");
#else
            Debug.log("This function only run on Android OS");
#endif
        }

#if UNITY_ANDROID
        private void ShowAndroidToast(string msg)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");

            object[] toastParams = new object[3];
            AndroidJavaClass unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            toastParams[0] = unityActivity.GetStatic<AndroidJavaObject>("currentActivity");
            toastParams[1] = msg;
            toastParams[2] = toastClass.GetStatic<int>("LENGTH_LONG");

            //call static function of Toast class, makeText
            AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", toastParams);

            toastObject.Call("show");
        }

        private void startSignin()
        {
            try
            {
                unityActivity.Call("startSignin");

            }
            catch (Exception ex)
            {
                Debug.LogError("xxx.Unity.0 Message " + ex.Message);
                //Debug.LogError("xxx.Unity.1 StackTrace " + ex.StackTrace);
            }
        }

        private void BuyItem()
        {
            const string productID = "android.test.purchased";
            unityActivity.Call("buy", new object[]{productID, 1, "1234", "extra_data"} );
        }

        public static AndroidJavaObject GetCurrentActivity()
        {

            using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                return jc.GetStatic<AndroidJavaObject>("currentActivity");
            }

            return null;
        }
#endif
    }
}
