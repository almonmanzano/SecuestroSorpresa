using UnityEngine;
using System.Collections;

public class CreditsMusic : MonoBehaviour
{
    void OnDestroy()
    {
        Destroy(GameObject.Find("BackgroundMusic"));
    }
}
