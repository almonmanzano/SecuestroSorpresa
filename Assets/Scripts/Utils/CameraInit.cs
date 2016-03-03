using UnityEngine;
using System.Collections;

public class CameraInit : MonoBehaviour
{
    private bool start, moved, rotated, started;

    void Start()
    {
        StartCoroutine("DelayedInit");
    }

	void Update ()
    {
        if (start)
        {
            if (Application.loadedLevelName == "Scene0")
            {
                Vector3 currentPos = transform.position;
                Vector3 newPos = currentPos - new Vector3(0f, 0f, 0.5f);
                float z = GameObject.FindWithTag("Player").transform.position.z - 10.0f;
                if (!moved)
                {
                    if (currentPos.z > z)
                    {
                        transform.position = newPos;
                    }
                    else
                    {
                        moved = true;
                        if (rotated) GameObject.FindWithTag("GameController").GetComponent<GameController>().StartTutorials();
                    }
                }

                Vector3 currentRot = transform.rotation.eulerAngles;
                if (!rotated)
                {
                    if (currentRot.x < 45.0f)
                    {
                        transform.Rotate(new Vector3(1, 0, 0), 0.1f);
                    }
                    else
                    {
                        rotated = true;
                        if (moved) GameObject.FindWithTag("GameController").GetComponent<GameController>().StartTutorials();
                    }
                }
            }

            // Zoom
            if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
            {
                Camera.main.fieldOfView--;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0) // forward
            {
                Camera.main.fieldOfView++;
            }
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 20, 60);
        }
    }

    IEnumerator DelayedInit()
    {
        yield return new WaitForSeconds(2);
        start = true;
    }
}
