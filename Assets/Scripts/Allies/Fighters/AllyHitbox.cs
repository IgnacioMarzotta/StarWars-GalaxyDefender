using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHitbox : MonoBehaviour
{
	AllyController AController;

    private void Start()
    {
        AController = GetComponent<AllyController>();
    }

    public void TakeBoundsDamage()
    {
        AController.allyHealth -= 2000f;
    }

    void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag.Equals("EnemyShot"))
		{
			AController.allyHealth -= 10;
		}

		if (col.gameObject.tag.Equals("EnemyBShot"))
		{
			AController.allyHealth -= 20;
		}

		if (col.gameObject.tag.Equals("EnemyIShot"))
		{
			AController.allyHealth -= 5;
		}
	}
}
