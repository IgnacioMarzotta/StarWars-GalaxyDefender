using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieFEntityController : MonoBehaviour
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
        ESpawner.TieFCounter += 1;
    }

    private void Update()
    {
        if (EController.isEnemyDead == true)
        {
            InvokeRepeating("SubstractTieF", 2f, 10f);
        }
    }

    void SubstractTieF()
    {
        ESpawner.TieFCounter -= 1;
    }
}
