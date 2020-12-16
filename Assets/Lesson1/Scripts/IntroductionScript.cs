using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Lesson1.Scripts
{
    public class LoginCallback : AndroidJavaProxy
    {
        public event Action<bool, string, string, int, AndroidJavaObject> OnLoginCallback;
        public LoginCallback() : base("vn.vntac.sdk.listener.OnLoginListener") { }

        public void onResponse(bool isOK, String response, String message, int errorCode, AndroidJavaObject user)
        {
            Debug.Log("xxx.Unity.onResponse " + isOK + ";;; " + response + ";;; " + user.ToString());

            if (OnLoginCallback != null) OnLoginCallback(isOK, response, message, errorCode, user);
        }
    }

    public class User : AndroidJavaClass
    {
        public User() : base("vn.vntac.sdk.model.User") {}
    }
 
    public class IntroductionScript : MonoBehaviour
    {
        public Button btnToastDemo;
        public Button btnVnTac;
        public Button btnBabyShark;

        public AudioClip musicFile;

        void Start()
        {
            btnToastDemo.onClick.AddListener(MakeToast);
            btnBabyShark.onClick.AddListener(PlayBabyShark);
            btnVnTac.onClick.AddListener(InitVnTacSDK);
        }

        private void PlayBabyShark()
        {
            var audioSource = FindObjectOfType<AudioSource>();

            audioSource.PlayOneShot(musicFile);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void MakeToast()
        {
#if UNITY_ANDROID
            ShowAndroidToast("Hello world!");
#else
            Debug.log("This function only run on Android OS");
#endif
        }

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

        private void InitVnTacSDK()
        {
            try
            {
                string key_base64_endcode =
                    "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA29qRBoq/lvn884LWBnfMxL946NyL5rPhQdzrcRugdQLuUnyq/kfvvdY9AUBfVUa+bRLF6wOEIfWdcH5Xj/6HO2A8aBqUnWI42yLCiVOritB6celuexoE9UIqpVq/CgvnPyBu7hniPURpqFvbpp7gnyzFUg0EUjTUsgYHNtYRMDYWDlji57mAJrT917bD4PUOHBmjPN+qwgbb1sYpNXwcNyjATFBFpwkmxEzj7/mcZDOUohAwHSg0WPmJd0kMuyjMM3Ts7ZtdV2he08Zopauc8qlTQig3jvoIYeurs78uE7lCXnVLb3fiaKazeptOzPAy7yzx8WqJvRP7YwAraJc/iwIDAQAB";
                string productID = "android.test.purchased";

                var context = GetApplicationContext();
                var currentActivity = GetCurrentActivity();


                //AndroidJavaClass vntacSDK = new AndroidJavaClass("vn.vntac.sdk.VNTacSDK");
                AndroidJavaObject vntacSDK = new AndroidJavaObject("vn.vntac.sdk.VNTacSDK", new object[] { currentActivity });
                AndroidJavaObject vntacUser = new AndroidJavaObject("vn.vntac.sdk.model.User");


                Debug.Log("xxx.Unity.Done CONSTRUCTOR");

                vntacSDK.Call("initInAppBilling", new object[] {key_base64_endcode});

                Debug.Log("xxx.Unity.Done === initInAppBilling");

                var loginObj = new LoginCallback();
                loginObj.OnLoginCallback += OnLoginCallback;
                vntacSDK.Call("login", new object[]{currentActivity, loginObj });

                Debug.Log("xxx.Unity.Done === login setting");

                vntacSDK.Call("checkSessionUser");

                Debug.Log("xxx.Unity.Done checkSessionUser");

                //vntacSDK.Call("startSignin");

                //Debug.Log("xxx.Unity.Done startSignin");

                

            }
            catch (Exception ex)
            {
                Debug.LogError("xxx.Unity.0 Message " + ex.Message);
                //Debug.LogError("xxx.Unity.1 StackTrace " + ex.StackTrace);
            }
        }

        private void OnLoginCallback(bool isOK, string response, string message, int errorCode, AndroidJavaObject user)
        {
            ShowAndroidToast(response);

            Debug.Log("xxx.Unity callback " + isOK + ", " + response);
        }


#if UNITY_ANDROID
        public static AndroidJavaObject GetApplicationContext()
        {

            using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    return jo.Call<AndroidJavaObject>("getApplicationContext");
                }
            }

            return null;
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
