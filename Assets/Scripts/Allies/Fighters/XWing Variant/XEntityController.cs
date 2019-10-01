using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XEntityController : MonoBehaviour
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
        ESpawner.XWingCounter += 1;
    }

    private void Update()
    {
        if (AController.isAllyDead == true)
        {
            InvokeRepeating("SubstractXWing", 2f, 10f);
        }
    }

    void SubstractXWing()
    {
        ESpawner.XWingCounter -= 1;
    }
}
