using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCannonShot : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyShot());
    }

	IEnumerator DestroyShot()
	{
		yield return new WaitForSeconds(7f);
		Destroy(gameObject);
	}
}
