using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEntityController : MonoBehaviour
{
    EntitySpawner ESpawner;

    AllyController AController;

    private void Awake()
    {
        AController = GetComponent<AllyController>();
        ESpawner = GameObject.Find("EntitySpawner").GetComponent<EntitySpawner>();
    }

    void Start()
    {
        ESpawner.YWingCounter += 1;
    }

    private void Update()
    {
        if (AController.isAllyDead == true)
        {
            InvokeRepeating("SubstractYWing", 2f, 10f);
        }
    }

    void SubstractYWing()
    {
        ESpawner.YWingCounter -= 1;
    }
}
