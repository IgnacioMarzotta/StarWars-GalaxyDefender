using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotDetector : MonoBehaviour
{
    public GameObject CannonShotExplosion;
    public GameObject PlayerShotExplosion;
    public GameObject TieShotExplosion;
    public GameObject TorpedoExplosion;

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "EnemyShot")
        {
            Instantiate(TieShotExplosion, target.transform.position, target.transform.rotation);
            Destroy(target.gameObject);
        }

        if (target.tag == "AllyShot")
        {
            Instantiate(PlayerShotExplosion, target.transform.position, target.transform.rotation);
            Destroy(target.gameObject);
        }

        if (target.tag == "EnemyCannonShot")
        {
            Instantiate(CannonShotExplosion, target.transform.position, target.transform.rotation);
            Destroy(target.gameObject);
        }

        if (target.tag == "PlayerTorpedo")
        {
            Instantiate(TorpedoExplosion, target.transform.position, target.transform.rotation);
            Destroy(target.gameObject);
        }
    }
}
