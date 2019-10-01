using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission2Controller : MonoBehaviour
{
    public Text DestroyedShieldGenerators;              // Texto en el canvas de Player UI
    public Transform Explosion1;                        // Transform donde la explosion1 deberia instanciarse
    public Transform Explosion2;                        // Transform donde la explosion2 deberia instanciarse
    public GameObject ShieldGenExplosion;               // Prefab de explosion del generador de escudos

    public static int ShieldsDowned;                    // Progreso de la mision
    public bool Mission2Completed;                      // Booliano de si la mision fue completada

    int ExplosionCounter;                               // Con el proposito de evitar que el sistema de particulas se vuelva loco con las explosiones

    void Start()
    {
        ShieldsDowned = 0;
        ExplosionCounter = 0;
    }

    void Update()
    {
        DestroyedShieldGenerators.text = ShieldsDowned + " / 2";

        if (ShieldsDowned == 2)
        {
            StartCoroutine(DestroyInvictusShields());
            Mission2Completed = true;
        }
    }

    IEnumerator DestroyInvictusShields()
    {
        if (ExplosionCounter <= 6)
        {
            yield return new WaitForSeconds(1);
            Instantiate(ShieldGenExplosion, Explosion1.position, Explosion1.rotation);
            ExplosionCounter += 1;
            yield return new WaitForSeconds(1);
            Instantiate(ShieldGenExplosion, Explosion2.position, Explosion2.rotation);
            ExplosionCounter += 1;
        }
    }
}
