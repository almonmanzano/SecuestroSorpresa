using UnityEngine;
using System.Collections;

public class Interactuable : MonoBehaviour
{
    public GameObject txt;
    public GameObject dialog;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && txt.activeSelf)
        {
            txt.SetActive(false);
            dialog.SetActive(true);
        }
    }
    
    void OnTriggerEnter()
    {
        if (!dialog.activeSelf) txt.SetActive(true);
    }
    
    void OnTriggerExit()
    {
        txt.SetActive(false);
        dialog.SetActive(false);
    }

    public void Cancel()
    {
        dialog.SetActive(false);
        txt.SetActive(true);
    }

    public void Accept()
    {
        dialog.SetActive(false);
    }

    public void AcceptAndDelete()
    {
        Accept();
        Destroy(gameObject);
    }
}
