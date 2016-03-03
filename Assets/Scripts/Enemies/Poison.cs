using UnityEngine;
using System.Collections;

public class Poison : MonoBehaviour
{
    GameObject player;

    private bool playerInRange, playable, sink;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        playable = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GetPlayable();

        if (playable && playerInRange && !sink)
        {
            // Attack!
            sink = true;
            player.GetComponent<PlayerController>().Damage();
            GameObject.FindWithTag("GameController").GetComponent<GameController>().SetPlayable(false);
            StartCoroutine(WaitFor());
        }

        if (sink)
        {
            player.transform.position = player.transform.position - new Vector3(0f, 0.05f, 0f);
        }

        // Material
        float offset = Time.time * 0.01f;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") playerInRange = true;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player") playerInRange = false;
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(1);
        sink = false;
        player.GetComponent<PlayerController>().Respawn();
        GameObject.FindWithTag("GameController").GetComponent<GameController>().SetPlayable(true);
    }
}
