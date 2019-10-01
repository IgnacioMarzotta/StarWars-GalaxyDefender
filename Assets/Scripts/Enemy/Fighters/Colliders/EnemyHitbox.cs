using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
	public EnemyController EController;

    public void TakeBoundsDamage()
    {
        EController.enemyHealth -= 2000f;
    }

	void OnTriggerEnter(Collider target)
	{
		if(target.tag == "AllyShot")
		{
			EController.enemyHealth -= 30f;
		}

        if (gameObject.tag == "RapidFireShot")
        {
            EController.enemyHealth -= 8f;
        }
    }
}
