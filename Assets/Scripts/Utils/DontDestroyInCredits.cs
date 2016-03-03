using UnityEngine;
using System.Collections;

public class DontDestroyInCredits : MonoBehaviour
{
    public void DontDestroyMusic()
    {
        GameObject.Find("BackgroundMusic").AddComponent<DontDestroy>();
    }
}
