using UnityEngine;
using System.Collections;

public class ScrollingText : MonoBehaviour
{
    private float speed = 30;
    private bool skippable = false;

    void Update ()
    {
        gameObject.transform.Translate(Vector3.up * Time.deltaTime * speed);

        //StartCoroutine(waitFor());

        if (Input.GetKey(KeyCode.Space) && skippable)
        {
            Application.LoadLevel(0);
        }
	}

    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(5);
        skippable = true;
    }
}
