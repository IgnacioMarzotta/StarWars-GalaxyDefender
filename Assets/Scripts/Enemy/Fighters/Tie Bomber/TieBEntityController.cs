using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieBEntityController : MonoBehaviour
{
    EntitySpawner ESpawner;

    EnemyController EController;

    private void Awake()
    {
        EController = GetComponent<EnemyController>();
        ESpawner = GameObject.Find("EntitySpawner").GetComponent<EntitySpawner>();
    }

    void Start()
    {
        ESpawner.TieBCounter += 1;
    }

    private void Update()
    {
        if (EController.isEnemyDead == true)
        {
            InvokeRepeating("SubstractTieB", 2f, 10f);
        }
    }

    void SubstractTieB()
    {
        ESpawner.TieBCounter -= 1;
    }
}