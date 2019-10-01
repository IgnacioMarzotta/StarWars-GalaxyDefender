using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
	public float allySpeed;

	public float wanderIndex; 

    void Start()
    {
        wanderIndex = Random.Range(450, 1000);
    }

    void Update()
    {
        wanderIndex -= 1;

		Wander();
    }
	
	void Wander()
	{
		transform.position += transform.forward * allySpeed * Time.deltaTime;

		if(wanderIndex == 0)
		{
			ChangeAngle();
		}
	}

	void ChangeAngle()
	{
		transform.eulerAngles = new Vector3 (Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        wanderIndex = Random.Range(50, 450);
    }
}