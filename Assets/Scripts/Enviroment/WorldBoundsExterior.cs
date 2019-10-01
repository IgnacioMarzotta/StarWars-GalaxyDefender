using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBoundsExterior : MonoBehaviour
{
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            EnemyHitbox EnemyHitbox = col.GetComponent<EnemyHitbox>();
            EnemyHitbox.TakeBoundsDamage();
        }
    }
}
