using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission3Controller : MonoBehaviour
{
    public Text LifeSupProgress;                        // Texto de progreso en el canvas de Player UI
    public Transform Explosion1;                        // Transform donde la explosion1 deberia instanciarse
    public Transform Explosion2;                        // Transform donde la explosion2 deberia instanciarse
    public GameObject InvictusExplosion;                // Prefab de explosion del generador de escudos

    public static int LifeSupDowned;                    // Progreso de la mision

    int ExplosionCounter;                               // Con el proposito de evitar que el sistema de particulas se vuelva loco con las explosiones

    public AudioSource source;
    public AudioClip BlackNoise;
    public AudioClip Explosion;

    public bool Mission3Completed;                      // Booliano de si la mision fue completada

    void Start()
    {
        LifeSupDowned = 0;
        ExplosionCounter = 0;
    }

    void Update()
    {
        LifeSupProgress.text = LifeSupDowned + " / 2";

        if (LifeSupDowned >= 2)
        {
            StartCoroutine(DestroyInvictus());
            Mission3Completed = true;
        }
    }

    IEnumerator DestroyInvictus()
    {
        if (ExplosionCounter <= 6)
        {
            yield return new WaitForSeconds(10);
            Instantiate(InvictusExplosion, Explosion1.position, Explosion1.rotation);
            ExplosionCounter += 1;
            yield return new WaitForSeconds(1);
            Instantiate(InvictusExplosion, Explosion2.position, Explosion2.rotation);
            ExplosionCounter += 1;
        }
    }
}
