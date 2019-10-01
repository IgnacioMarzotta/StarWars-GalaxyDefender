using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBoundsInterior : MonoBehaviour
{
    //public Transform WorldCenter;
    public BoundsCountdown BCountdown;
    public GameObject ExitWorldCanvas;

    private void Awake()
    {
        BCountdown = GetComponent<BoundsCountdown>();
    }

    private void Start()
    {
        GetComponent<BoundsCountdown>().enabled = false;
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            ExitWorldCanvas.SetActive(true);
            gameObject.GetComponent<BoundsCountdown>().enabled = true;
        }

		if (col.gameObject.tag.Equals("Enemy"))
		{
            EnemyController EnemyController = col.GetComponent<EnemyController>();
            EnemyController.enemyHealth -= 2000;
            //Transform target = col.gameObject.GetComponent<EnemyMovement>().target = WorldCenter;
            //col.gameObject.GetComponent<EnemyMovement>().SetTargetNull();
        }

		if (col.gameObject.tag.Equals("Ally"))
		{
            AllyHitbox AllyHitbox = col.GetComponent<AllyHitbox>();
            AllyHitbox.TakeBoundsDamage();
        }
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            ExitWorldCanvas.SetActive(false);
            gameObject.GetComponent<BoundsCountdown>().exitTimer = 500;
            gameObject.GetComponent<BoundsCountdown>().enabled = false;
        }
    }
}
