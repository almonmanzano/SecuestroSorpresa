using UnityEngine;
using System.Collections;

public class StaticText : MonoBehaviour
{
    public GameObject text;

    private bool skippable = false;
    
    void Update ()
    {
        StartCoroutine(waitFor());
        
        if (Input.GetKey(KeyCode.Space) && skippable)
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
    
    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(3);
        skippable = true;
        text.SetActive(true);
    }
}
