using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEntityController : MonoBehaviour
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
        ESpawner.AWingCounter += 1;
    }

    private void Update()
    {
        if (AController.isAllyDead == true)
        {
            InvokeRepeating("SubstractAWing", 2f, 10f);
        }
    }

    void SubstractAWing()
    {
        ESpawner.AWingCounter -= 1;
    }
}
