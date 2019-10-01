using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMuzzleFlash : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyCannonFlash());
    }

    IEnumerator DestroyCannonFlash()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
