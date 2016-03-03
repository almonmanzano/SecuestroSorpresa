using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour
{
    
	void Start ()
    {
        Destroy(gameObject, 5f);
	}
}
