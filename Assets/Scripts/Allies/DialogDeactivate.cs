using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDeactivate : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyDialog());
    }

    IEnumerator DestroyDialog()
    {
        yield return new WaitForSeconds(39);
        Destroy(gameObject);
    }
}
