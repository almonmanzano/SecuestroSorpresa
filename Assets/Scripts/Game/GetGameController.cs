using UnityEngine;
using System.Collections;

public class GetGameController : MonoBehaviour
{
    GameObject GameController;
    
	void Start ()
    {
        GameController = GameObject.FindWithTag("GameController");
    }

    public void AddMemory()
    {
        GameController.GetComponent<GameController>().AddMemory();
    }

    public void Retry()
    {
        GameController.GetComponent<GameController>().Retry();
    }

    public void Exit()
    {
        GameController.GetComponent<GameController>().Exit();
    }

    public void GoToMainMenu()
    {
        GameController.GetComponent<GameController>().GoToMainMenu();
    }
}
