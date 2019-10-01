using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission1Controller : MonoBehaviour
{
    public Transform Explosion1;                        // Transform donde Explosion1 deberia instanciarse
    public Transform Explosion2;                        // Transform donde Explosion2 deberia instanciarse
    public Transform Explosion3;                        // Transform donde Explosion3 deberia instanciarse

    public Text DestroyedGenerators;                    // Texto en el canvas de Player UI
    public static int GeneratorsCompleted = 0;          // Progreso de la mision

    public GameObject ImmobilizerExplosion;             // Prefab de explosion de Immobilizer
    int ExplosionCounter;                               // Contador de exploiones, para evitar que el sistema de particulas se vuelva loco
    public bool Mission1Completed;                      // Usado por el MissionController para terminar la mision actual e iniciar la siguiente

    public GameObject Immobilizer;

    private void Start()
    {
        ExplosionCounter = 0;
    }

    void Update()
    {
        DestroyedGenerators.text = GeneratorsCompleted + "/ 4";

        if(GeneratorsCompleted >= 4)
        {
            Mission1Completed = true;
            StartCoroutine(DestroyImmobilizer());
            StartCoroutine(EraseImmobilizer());
        }
    }

    IEnumerator DestroyImmobilizer()
    {
        if (ExplosionCounter <= 6)
        {
            Instantiate(ImmobilizerExplosion, Explosion1.position, Explosion1.rotation);
            ExplosionCounter += 1;
            yield return new WaitForSeconds(1);
            Instantiate(ImmobilizerExplosion, Explosion2.position, Explosion2.rotation);
            ExplosionCounter += 1;
            yield return new WaitForSeconds(1);
            Instantiate(ImmobilizerExplosion, Explosion3.position, Explosion3.rotation);
            ExplosionCounter += 1;
        }
    }

    IEnumerator EraseImmobilizer()
    {
        yield return new WaitForSeconds(25);
        Destroy(Immobilizer.gameObject);
    }
}
