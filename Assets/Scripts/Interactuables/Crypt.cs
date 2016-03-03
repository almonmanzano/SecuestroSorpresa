using UnityEngine;
using System.Collections;

public class Crypt : MonoBehaviour
{
    public GameObject cam, cam2;

    private Transform t;

    void OnTriggerEnter()
    {
        cam.SetActive(false);
        cam2.SetActive(true);
        //t = cam.transform;
        //cam.transform.position = cam2.transform.position;
        //cam.transform.rotation = cam2.transform.rotation;
    }

    void OnTriggerExit()
    {
        cam.SetActive(true);
        cam2.SetActive(false);
        //cam.transform.position = t.position;
        //cam.transform.rotation = t.rotation;
    }
}
