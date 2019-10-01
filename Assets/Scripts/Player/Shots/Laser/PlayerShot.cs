using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    void Start()
    {
		StartCoroutine(DestroyLaserBolt());  
    }

	IEnumerator DestroyLaserBolt()
	{
		yield return new WaitForSeconds(8f);
		Destroy(gameObject);
	}
}
