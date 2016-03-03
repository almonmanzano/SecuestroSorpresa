using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float range = 20f;
    public float speed = 1.0f;

    GameObject player;
    NavMeshAgent nav;

    private bool attacking, damaged, playable, played;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
    }

    void Update()
    {
        playable = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GetPlayable();

        if (!playable) nav.Stop();
        else
        {
            nav.Resume();
            
            if (!attacking)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance < range)
                {
                    nav.SetDestination(player.transform.position);
                    if (!played)
                    {
                        GetComponent<AudioSource>().Play();
                        played = true;
                    }
                }
                else played = false;
            }
            else
            {
                // Attack!
                if (!damaged)
                {
                    player.GetComponent<PlayerController>().Damage();
                    damaged = true;
                    StartCoroutine(Attack());
                }
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") attacking = true;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player") attacking = false;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2);
        damaged = false;
    }
}
