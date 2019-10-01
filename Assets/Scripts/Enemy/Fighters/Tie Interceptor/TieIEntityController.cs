using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieIEntityController : MonoBehaviour
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
        ESpawner.TieICounter += 1;
    }

    private void Update()
    {
        if (EController.isEnemyDead == true)
        {
            InvokeRepeating("SubstractTieI", 2f, 10f);
        }
    }

    void SubstractTieI()
    {
        ESpawner.TieICounter -= 1;
    }
}