using UnityEngine;
using System.Collections;

public class Memories : MonoBehaviour
{
    public GameObject ps;

    bool done;

    void OnTriggerEnter()
    {
        if (!done)
        {
            GameObject.FindWithTag("GameController").GetComponent<GameController>().AddFinalMemory();
            ps.SetActive(true);
            done = true;
        }
    }
}
