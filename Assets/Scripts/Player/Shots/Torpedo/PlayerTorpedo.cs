using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorpedo : MonoBehaviour
{

    void Start()
    {
		StartCoroutine(DestroyTorpedo());  
    }

    void Update()
    {
        
    }

	IEnumerator DestroyTorpedo()
	{
		yield return new WaitForSeconds(10f);
		Destroy(gameObject);
	}
}
