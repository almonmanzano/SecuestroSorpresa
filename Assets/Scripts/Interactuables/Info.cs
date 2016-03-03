using UnityEngine;
using System.Collections;

public class Info : MonoBehaviour
{
    public GameObject txt;

    void OnTriggerEnter()
    {
        if (txt != null) txt.SetActive(true);
    }

    void OnTriggerExit()
    {
        if (txt != null) txt.SetActive(false);
    }

    public void Destroy()
    {
        Destroy(txt);
    }

    void OnDestroy()
    {
        Destroy();
    }
}
