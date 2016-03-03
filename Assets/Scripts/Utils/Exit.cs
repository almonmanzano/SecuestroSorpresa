using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour
{
    public float showSplashTimeout = 2.0F;
    private bool allowQuitting = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Application.loadedLevelName == "FinalSplash") StartCoroutine("DelayedQuit");
    }

    void OnApplicationQuit()
    {
        if (Application.loadedLevelName != "FinalSplash")
        {
            Application.LoadLevel("FinalSplash");
            StartCoroutine("DelayedQuit");
        }
        if (!allowQuitting) Application.CancelQuit();
    }

    IEnumerator DelayedQuit()
    {
        yield return new WaitForSeconds(showSplashTimeout);
        allowQuitting = true;
        Debug.Log("Cerrando juego");
        Application.Quit();
    }
}
