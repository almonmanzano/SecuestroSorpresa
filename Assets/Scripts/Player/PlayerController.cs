using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public GameObject Diego;
    public GameObject Crow;
    public float moveSpeed = 7f;
    public float jumpSpeed = 5f;
    public GameObject[] heartsShown;
    public Image damageImage;
    
    protected CharacterController control;
    protected Vector3 move = Vector3.zero, gravity = Vector3.zero;
    protected bool jumping, gliding;
    
    private int state;
    private bool playable;
    private int hearts;
    private float flashSpeed = 1f;
    private Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    private bool damaged, newscene;
    
    void Start ()
    {
        control = GetComponent<CharacterController> ();
        hearts = GameObject.FindWithTag("GameController").GetComponent<GameController>().GetHearts();
    }
    
    void Update ()
    {
        // State of the game
        state = GameObject.FindWithTag("GameController").GetComponent<GameController>().GetState();
        playable = GameObject.FindWithTag("GameController").GetComponent<GameController>().GetPlayable();

        // Movement
        if (playable)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            move.Normalize();

            move *= moveSpeed;

            if (!control.isGrounded)
            {
                gravity += Physics.gravity * Time.deltaTime;

                // Glide
                if (Input.GetKeyDown(KeyCode.Space) && jumping && state > 1)
                {
                    Diego.SetActive(false);
                    Crow.SetActive(true);
                    Crow.GetComponent<ParticleSystem>().Play();
                    GetComponent<AudioSource>().Play();
                    jumping = false;
                    gliding = true;
                }
            }
            else
            {
                if (gliding)
                {
                    Diego.SetActive(true);
                    Crow.SetActive(false);
                }

                gravity = new Vector3(0, -0.1f, 0);
                jumping = false;
                gliding = false;

                // Jump
                if (Input.GetKeyDown(KeyCode.Space) && control.isGrounded)
                {
                    gravity.y = jumpSpeed;
                    jumping = true;
                }
            }

            if (gliding) gravity *= 0.9f;

            move += gravity;

            Vector3 p1 = transform.position;

            control.Move(move * Time.deltaTime);

            Vector3 p2 = transform.position;

            if (p1.x != p2.x || p1.z != p2.z) // If the position is different
            {
                GameObject Diego = GameObject.Find("Character/Diego");
                Diego.transform.LookAt(p1);
                Diego.transform.Rotate(0, 180, 0);
                Diego.transform.rotation = new Quaternion(0, Diego.transform.rotation.y, 0, Diego.transform.rotation.w);
            }
        }

        // Damage
        if (damaged) damageImage.color = flashColour;
        else damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        damaged = false;

        if (Application.loadedLevelName == "Scene1" && !newscene)
        {
            newscene = true;
            for (int i = 0; i < heartsShown.Length - hearts; i++)
            {
                heartsShown[heartsShown.Length - 1 - i].SetActive(false);
            }
        }
    }

    public void Damage()
    {
        if (hearts > 0)
        {
            damaged = true;
            hearts--;
            GameObject.FindWithTag("GameController").GetComponent<GameController>().SetHearts(hearts);
            heartsShown[hearts].SetActive(false);

            if (hearts == 0)
            {
                // Game Over!
                GameObject.FindWithTag("GameController").GetComponent<GameController>().GameOver();
                Debug.Log("Game Over!");
            }
        }
    }

    public void Respawn()
    {
        transform.position = new Vector3(0f, 7.5f, 180f);
    }
}
