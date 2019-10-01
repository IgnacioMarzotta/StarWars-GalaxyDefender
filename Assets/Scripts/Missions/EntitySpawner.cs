using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    //VARIABLES ALIADAS

	public int AWingCounter;
    public int YWingCounter;
    public int XWingCounter;

    public GameObject AWingPrefab;
    public GameObject YWingPrefab;
    public GameObject XWingPrefab;

    public Transform AWingSpawnPoint;
    public Transform YWingSpawnPoint;
    public Transform XWingSpawnPoint;

    public GameObject aWingParent;
    public GameObject yWingParent;
    public GameObject xWingParent;

    public int AllyCooldown;

    //VARIABLES ENEMIGAS

    public int TieFCounter;
    public int TieICounter;
    public int TieBCounter;

    public GameObject TieFPrefab;
    public GameObject TieBPrefab;
    public GameObject TieIPrefab;

    public Transform TieFSpawnPoint;
    public Transform TieBSpawnPoint;
    public Transform TieISpawnPoint;

    public GameObject tieFParent;
    public GameObject tieBParent;
    public GameObject tieIParent;

    public int EnemyCooldown;

    private void Start()
    {
        AWingCounter = 0;
        YWingCounter = 0;
        XWingCounter = 0;
        TieFCounter = 0;
        TieBCounter = 0;
        TieICounter = 0;

        AllyCooldown = 200;
        EnemyCooldown = 100;
    }

    void Update()
    {
        CheckIfAWing();

        CheckIfYWing();

        CheckIfXWing();

        CheckIfTieF();

        CheckIfTieB();

        CheckIfTieI();
    }

    private void FixedUpdate()
    {
        AllyCooldown --;
        EnemyCooldown --;

        if(EnemyCooldown < 0)
        {
            EnemyCooldown = 0;
        }

        if(AllyCooldown < 0)
        {
            AllyCooldown = 0;
        }        
    }

    /// <summary>
    /// / C H E C K S
    /// </summary>
    /// <returns></returns>

    void CheckIfAWing()
    {
        if (AWingCounter < 15 && AllyCooldown <= 0)
        {
            StartCoroutine(SpawnAWing());
            AllyCooldown = 200;
        }

        else
        {
            return;
        }

    }

    void CheckIfYWing()
    {
        if (YWingCounter < 15 && AllyCooldown <= 0)
        {
            StartCoroutine(SpawnYWing());
            AllyCooldown = 200;
        }

        else
        {
            return;
        }
    }

    void CheckIfXWing()
    {
        if (XWingCounter < 25 && AllyCooldown <= 0)
        {
            StartCoroutine(SpawnXWing());
            AllyCooldown = 200;
        }

        else
        {
            return;
        }
    }

    void CheckIfTieF()
    {
        if (TieFCounter < 30 && EnemyCooldown <= 0)
        {
            StartCoroutine(SpawnTieF());
            EnemyCooldown = 100;
        }

        else
        {
            return;
        }
    }

    void CheckIfTieB()
    {
        if (TieBCounter < 10 && EnemyCooldown <= 0)
        {
            StartCoroutine(SpawnTieB());
            EnemyCooldown = 100;
        }

        else
        {
            return;
        }

    }

    void CheckIfTieI()
    {
        if (TieICounter < 15 && EnemyCooldown <= 0)
        {
            StartCoroutine(SpawnTieI());
            EnemyCooldown = 100;
        }

        else
        {
            return;
        }
    }

    
    /// <summary>
    /// /INSTANTIATES
    /// </summary>
    /// <returns></returns>
    

    //A-WING
    IEnumerator SpawnAWing()
	{
        yield return new WaitForSeconds(2);
		GameObject AWing = Instantiate(AWingPrefab, AWingSpawnPoint.position, AWingSpawnPoint.rotation) as GameObject;
        AWing.transform.parent = aWingParent.transform;
	}

    //Y-WING
    IEnumerator SpawnYWing()
    {
        yield return new WaitForSeconds(2);
        GameObject YWing = Instantiate(YWingPrefab, YWingSpawnPoint.position, YWingSpawnPoint.rotation) as GameObject;
        YWing.transform.parent = yWingParent.transform;
    }

    //X-WING
    IEnumerator SpawnXWing()
    {
        yield return new WaitForSeconds(2);
        GameObject XWing = Instantiate(XWingPrefab, XWingSpawnPoint.position, XWingSpawnPoint.rotation) as GameObject;
        XWing.transform.parent = xWingParent.transform;
    }

    //TIE FIGHTER
    IEnumerator SpawnTieF()
	{
        yield return new WaitForSeconds(2);
        GameObject TieF = Instantiate(TieFPrefab, TieFSpawnPoint.position, TieFSpawnPoint.rotation) as GameObject;
        TieF.transform.parent = tieFParent.transform;
    }

    //TIE BOMBER
    IEnumerator SpawnTieB()
    {
        yield return new WaitForSeconds(2);
        GameObject TieB = Instantiate(TieBPrefab, TieBSpawnPoint.position, TieBSpawnPoint.rotation) as GameObject;
        TieB.transform.parent = tieBParent.transform;
    }

    //TIE INTERCEPTOR
    IEnumerator SpawnTieI()
    {
        yield return new WaitForSeconds(2);
        GameObject TieI = Instantiate(TieIPrefab, TieISpawnPoint.position, TieBSpawnPoint.rotation) as GameObject;
        TieI.transform.parent = tieIParent.transform;
    }
}
