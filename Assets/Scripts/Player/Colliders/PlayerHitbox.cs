using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitbox : MonoBehaviour
{
	PlayerController PController;
    public GameObject CannonShotExplosion;
    public GameObject TieShotExplosion;
    public Text DeathReason;

    public string LastHit;

    private void Awake()
    {
        PController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if(PController.health > 0)
        {
            DeathReason.text = "Unfortunately, tou died to a " + LastHit;
        }
    }

    void OnTriggerEnter(Collider col)
	{
		if(col.tag == "EnemyShot")
		{
			PController.health -= 10;
            Instantiate(TieShotExplosion, col.transform.position, col.transform.rotation);
            Destroy(col.gameObject);
            LastHit = "Tie Fighter!";
		}

		if(col.tag == "EnemyBShot")
		{
			PController.health -= 20;
            Instantiate(TieShotExplosion, col.transform.position, col.transform.rotation);
            Destroy(col.gameObject);
            LastHit = "Tie Bomber!";
        }

		if(col.tag == "EnemyIShot")
		{
			PController.health -= 5;
            Instantiate(TieShotExplosion, col.transform.position, col.transform.rotation);
            Destroy(col.gameObject);
            LastHit = "Tie Interceptor!";
        }

		if(col.tag == "EnemyCannonShot")
		{
			PController.health -= 80;
            Instantiate(CannonShotExplosion, col.transform.position, col.transform.rotation);
            Destroy(col.gameObject);
            LastHit = "Cannon shell!";
        }
	}
}
