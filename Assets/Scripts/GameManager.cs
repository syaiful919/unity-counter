using UnityEngine;
using UnityEngine.UI;
using AndroidHelper;

public class GameManager : MonoBehaviour
{
    public Text countText;
    public Button countButton;
    public Button resetButton;
    public Text greetingText;

    private int countNumber = 0;

    private AndroidJavaObject activity;

    private void Awake() {
        Debug.Log("/// [GameManager] Awake");

        if(Application.platform == RuntimePlatform.Android)
        {
            activity = Android.GetCurrentActivity();
            if(activity != null) 
            {
                activity.Call("onPreloadGame", "Hello, i'm from unity");
            }
        }
    }

    private void Start() {
        Debug.Log("/// [GameManager] Start");
        if(Application.platform == RuntimePlatform.Android)
        {
            string extra = Android.AndroidGetIntentStringExtra("greeting");
            if (extra != null)
            {
                greetingText.text = "You have a message: " + extra;
            }
        }
    }

    private void OnDisable()
    {
        Debug.Log("/// [GameManager] OnDisable");
    }

    private void OnDestroy() {
        Debug.Log("/// [GameManager] OnDestroy");
    }

    private void OnApplicationQuit() {
        Debug.Log("/// [GameManager] OnApplicationQuit");
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    public void Count()
    {
        countNumber++;
        countText.text = countNumber.ToString();
    }

    public void Reset() 
    {
        countNumber = 0;
        countText.text = countNumber.ToString();
    }
    
}
