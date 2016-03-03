using UnityEngine;
using System.Collections;

public class CenteredText : MonoBehaviour
{
    private float speed = 30;
    private bool skippable = false;
    
    void Update ()
    {
        if (gameObject.transform.position.y < Screen.height / 2f)
        {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        
        StartCoroutine(waitFor());
        
        if (Input.GetKey(KeyCode.Space) && skippable)
        {
            Application.LoadLevel(0);
        }
    }
    
    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(30);
        skippable = true;
    }
}
