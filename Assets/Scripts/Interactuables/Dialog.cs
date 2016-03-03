using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour
{
    public GameObject txt;
    public GameObject[] dialogs;

    private int state;
    private GameObject dialog;
    private bool playable;
    
    void Update()
    {
        playable = GameObject.FindWithTag("GameController").GetComponent<GameController>().GetPlayable();

        // Dialog
        dialog = dialogs[state];

        // Collision detection
        if (playable && Input.GetKeyDown(KeyCode.E) && txt.activeSelf)
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
        txt.SetActive(true);
        state++;
    }

    public void Rude()
    {
        dialog.SetActive(false);
        txt.SetActive(true);
        state = dialogs.Length - 1;
    }
}
