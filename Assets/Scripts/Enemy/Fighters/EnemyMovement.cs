using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public Transform target;										// Objetivo, el script PlayerDetection lo asigna

	private AllyController AController;								// AllyController
	private PlayerController PController;							// PlayerController
	
	Rigidbody rb;													// RigidBody

	public float rotationSpeed;										// Velocidad de rotacion del enemigo al mirar a su objetivo
	public float enemySpeed;										// Velocidad del enemigo

	public float wanderIndex;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Start()
	{
        wanderIndex = Random.Range(200, 1000);
	}

    void Update()
    {
		wanderIndex -= 1;

        if(target == null)
		{
			Wander();
		}

		if(target != null)
		{
			FollowTarget();
		}
    }

	void Wander()
	{
        transform.Translate(0, 0, enemySpeed * Time.deltaTime, Space.Self);

		if(wanderIndex == 0)
		{
			ChangeAngle();
		}
	}

	void FollowTarget()
	{
		//Mirar al objetivo
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position),rotationSpeed * Time.deltaTime );

		//Seguir al objetivo
		transform.position += transform.forward * enemySpeed * Time.deltaTime;
	}

	void ChangeAngle()
	{
		transform.eulerAngles = new Vector3 (Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		wanderIndex = Random.Range(50, 250);
    }
}