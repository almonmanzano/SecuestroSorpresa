using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour
{
    public GameObject Lau, Lau2, Diego, Diego2, ps, graphics, marryMe, cam;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenChest()
    {
        Debug.Log("abriendo cofre");
        GameObject.FindWithTag("GameController").GetComponent<GameController>().SetPlayable(false);
        Destroy(gameObject.GetComponent<Interactuable>());
        anim.SetTrigger("Open");
    }

    void AfterOpenChest()
    {
        ps.GetComponent<ParticleSystem>().Play();
        StartCoroutine(Vanish());
    }

    IEnumerator Vanish()
    {
        yield return new WaitForSeconds(2);
        graphics.SetActive(false);
        Lau.SetActive(true);
        GameObject.FindWithTag("GameController").GetComponent<GameController>().FinalSong();
        StartCoroutine(MarryMe());
    }
    
    IEnumerator MarryMe()
    {
        yield return new WaitForSeconds(5);

        // Camera
        Camera.main.transform.position = cam.transform.position;
        Camera.main.transform.rotation = cam.transform.rotation;

        // Diego
        Diego.transform.position = Diego2.transform.position;
        Diego.transform.rotation = Diego2.transform.rotation;

        // Lau
        Lau.transform.position = Lau2.transform.position;
        Lau.transform.rotation = Lau2.transform.rotation;

        marryMe.SetActive(true);
    }

    public void End()
    {
        GameObject.FindWithTag("GameController").GetComponent<GameController>().EndGame();
        GameObject.Find("BackgroundMusic").AddComponent<DontDestroy>();
    }
}
