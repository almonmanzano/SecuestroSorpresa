using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip menuMusic;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            source.clip = menuMusic;
            source.Play();
        }
    }
}
