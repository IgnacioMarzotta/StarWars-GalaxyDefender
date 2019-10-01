using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTieShot : MonoBehaviour
{
	void Start()
	{
		StartCoroutine(DestroyLaserBolt());
	}

	IEnumerator DestroyLaserBolt()
	{
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
}