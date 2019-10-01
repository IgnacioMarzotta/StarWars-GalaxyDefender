using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyShooting : MonoBehaviour
{
	public Transform shootingPoint1;
	public Transform shootingPoint2;

	private float timeBetweenAttack;
	public float startTimeBetweenAttack;

	public Rigidbody AllyShotPrefab;

    void Update()
    {
		if(timeBetweenAttack <= 0)
		{
			StartCoroutine(ShootFrom1());
			StartCoroutine(ShootFrom2());
			timeBetweenAttack = startTimeBetweenAttack;
		}

		else
		{
			timeBetweenAttack -= Time.deltaTime;
		}
    }

	IEnumerator ShootFrom1()
	{
		yield return new WaitForSeconds(1f);
		Rigidbody shotInstance;
		shotInstance = Instantiate(AllyShotPrefab, shootingPoint1.position, shootingPoint1.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
		shotInstance.AddForce(shootingPoint1.forward * 2);
	}

	IEnumerator ShootFrom2()
	{
		yield return new WaitForSeconds(1f);
		Rigidbody shotInstance;
		shotInstance = Instantiate(AllyShotPrefab, shootingPoint2.position, shootingPoint2.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
		shotInstance.AddForce(shootingPoint2.forward * 2);
	}
}