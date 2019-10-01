using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player") && gameObject.GetComponent<EnemyMovement>().target == null)
        {
            gameObject.GetComponent<EnemyMovement>().target = col.gameObject.transform;
        }

        if (col.gameObject.tag.Equals("Ally") && gameObject.GetComponent<EnemyMovement>().target == null)
        {
            Transform target = gameObject.GetComponent<EnemyMovement>().target = col.gameObject.transform;
        }
    }
}

//Simplifique bastante este script en el aspecto de mantener un objetivo consistente y dejarlo si abandona el trigger.
//Al final opte por reducirlo a simplemente unas 20 lineas, por ende solo asigna el objetivo al entrar al
//trigger, y lo persigue hasta matarlo o morir (si es que no tenia un objetivo anterior)