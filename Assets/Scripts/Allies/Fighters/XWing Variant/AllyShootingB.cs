using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyShootingB : MonoBehaviour
{
	public Transform shootingPoint1;
	public Transform shootingPoint2;
	public Transform shootingPoint3;
	public Transform shootingPoint4;

	private float timeBetweenAttack;
	public float startTimeBetweenAttack;

	public Rigidbody XWingShotPrefab;

    void Update()
    {
		if(timeBetweenAttack <= 0)
		{
			StartCoroutine(ShootFrom1());
			StartCoroutine(ShootFrom2());
			StartCoroutine(ShootFrom3());
			StartCoroutine(ShootFrom4());
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
		shotInstance = Instantiate(XWingShotPrefab, shootingPoint1.position, shootingPoint1.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
		shotInstance.AddForce(shootingPoint1.forward * 2);
	}

	IEnumerator ShootFrom2()
	{
		yield return new WaitForSeconds(1f);
		Rigidbody shotInstance;
		shotInstance = Instantiate(XWingShotPrefab, shootingPoint2.position, shootingPoint2.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
		shotInstance.AddForce(shootingPoint2.forward * 2);
	}

	IEnumerator ShootFrom3()
	{
		yield return new WaitForSeconds(1f);
		Rigidbody shotInstance;
		shotInstance = Instantiate(XWingShotPrefab, shootingPoint3.position, shootingPoint3.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
		shotInstance.AddForce(shootingPoint3.forward * 2);
	}

	IEnumerator ShootFrom4()
	{
		yield return new WaitForSeconds(1f);
		Rigidbody shotInstance;
		shotInstance = Instantiate(XWingShotPrefab, shootingPoint4.position, shootingPoint4.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
		shotInstance.AddForce(shootingPoint4.forward * 2);
	}
}