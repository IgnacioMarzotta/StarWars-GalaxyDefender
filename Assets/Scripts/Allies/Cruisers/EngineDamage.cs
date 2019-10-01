using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().insideEngine = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().insideEngine = false;
        }
    }
}       
