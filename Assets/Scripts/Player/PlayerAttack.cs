using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject leafs, ghosts, blood;

    Animator anim;

    private GameObject enemy;
    private bool playable;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        playable = GameObject.FindWithTag("GameController").GetComponent<GameController>().GetPlayable();

        // Attack
        if (playable && Input.GetMouseButtonDown(0) && !anim.GetBool("Attacking"))
        {
            anim.SetBool("Attacking", true);
            GetComponent<AudioSource>().Play();

            if (enemy != null)
            {
                if (enemy.name == "dinoseto") Instantiate(leafs, enemy.transform.position, enemy.transform.rotation);
                else if (enemy.name == "Bat") Instantiate(blood, enemy.transform.position + new Vector3(0f, 1f, 0f), enemy.transform.rotation);
                else Instantiate(ghosts, enemy.transform.position + new Vector3(0f, 1f, 0f), enemy.transform.rotation);
                
                Destroy(enemy);
            }
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy") enemy = collider.gameObject;
    }

    void OnTriggerExit(Collider collider)
    {
        enemy = null;
    }

    void StopAttacking()
    {
        anim.SetBool("Attacking", false);
    }
}
