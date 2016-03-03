using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour
{
    public int memoriesNeeded = 7;

    int memories;

	void Update ()
    {
        memories = GameObject.FindWithTag("GameController").GetComponent<GameController>().GetMemories();

        if (memories != 0 && memories == memoriesNeeded)
        {
            GameObject.Find("DoorAudio").GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
	}
}
