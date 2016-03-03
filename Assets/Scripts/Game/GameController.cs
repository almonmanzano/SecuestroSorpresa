using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* State of the game
 * 0: without sword
 * 1: without powers
 * 2: with sword and powers!
 */

public class GameController : MonoBehaviour
{
    public GameObject[] tutorials;
    public GameObject[] tales;
    public GameObject pause;
    public GameObject gameOver;
    public AudioClip final, song;
    
    private GameObject sword, chest;
    private int hearts = 3;
    int tutorial, state, tale, memories, finalMemories;
    private bool playable, paused;

    void Start()
    {
        sword = GameObject.Find("Character/Diego/Diego/Sword");
        sword.SetActive(false);

        Debug.Log("State: " + state);
    }

    void Update()
    {
        if (sword == null) sword = GameObject.Find("Character/Diego/Diego/Sword");
        if (chest == null && Application.loadedLevelName == "Scene1")
        {
            chest = GameObject.Find("Chest");
            chest.SetActive(false);
        }
        if (gameOver == null)
        {
            gameOver = GameObject.Find("Canvas/Game Over");
            gameOver.SetActive(false);
        }
        if (pause == null)
        {
            pause = GameObject.Find("Canvas/Pause");
            pause.SetActive(false);
        }

        // Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (playable && !paused)
            {
                paused = true;
                playable = false;
                pause.SetActive(true);
            }
            else if (!playable && paused)
            {
                paused = false;
                playable = true;
                pause.SetActive(false);
            }
        }
    }

    IEnumerator waitFor(int t)
    {
        yield return new WaitForSeconds(t);
        tutorials[tutorial].SetActive(true);
        tutorial++;
    }

    public int GetHearts()
    {
        return hearts;
    }

    public void SetHearts(int h)
    {
        hearts = h;
    }

    public void StartTutorials()
    {
        playable = true;
        StartCoroutine(waitFor(1));
        StartCoroutine(waitFor(5));
    }

    public void NextTutorial()
    {
        StartCoroutine(waitFor(1));
    }

    public void NextState()
    {
        state++;
        if (state == 1)
        {
            sword.SetActive(true);
            Destroy(GameObject.Find("dinoseto").GetComponent<Info>());
        }
        
        Debug.Log("State: " + state);
    }

    public int GetState()
    {
        return state;
    }

    public void NextTale()
    {
        playable = false;
        tales[tale].SetActive(true);
    }

    public void EndTale()
    {
        playable = true;
        tales[tale].SetActive(false);
        tale++;
    }

    public void NextScene()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void AddMemory()
    {
        memories++;
        if (memories == 7)
        {
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().clip = final;
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
        }

        Debug.Log("Memories: " + memories);
    }

    public int GetMemories()
    {
        return memories;
    }

    public void AddFinalMemory()
    {
        finalMemories++;
        if (finalMemories == 7)
        {
            chest.SetActive(true);
        }
    }

    public bool GetPlayable()
    {
        return playable;
    }

    public void SetPlayable(bool p)
    {
        playable = p;
    }

    public void GameOver()
    {
        playable = false;
        gameOver.SetActive(true);
    }

    public void Retry()
    {
        Application.LoadLevel("Scene0");
        Destroy(gameObject);
    }

    public void Exit()
    {
        Application.LoadLevel("FinalSplash");
    }

    public void GoToMainMenu()
    {
        Application.LoadLevel("MainMenu");
        Destroy(gameObject);
    }

    public void FinalSong()
    {
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().clip = song;
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().loop = false;
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
    }

    public void EndGame()
    {
        Application.LoadLevel("Credits");
        Destroy(gameObject);
    }
}
