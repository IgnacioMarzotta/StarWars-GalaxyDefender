using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondsTimer : MonoBehaviour
{
    public Text SecondsElapsed;
    public Text TookSoLong;

    int levelTimer;

    void Start()
    {
        levelTimer = 0;
        TookSoLong.gameObject.SetActive(false);
        SecondsElapsed.gameObject.SetActive(true);
    }

    private void Update()
    {
        SecondsElapsed.text = levelTimer + Time.time + "";

        if(levelTimer >= 3600)
        {
            SecondsElapsed.gameObject.SetActive(false);
            TookSoLong.gameObject.SetActive(true);
        }
    }
}
