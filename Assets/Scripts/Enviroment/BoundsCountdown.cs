using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundsCountdown : MonoBehaviour
{
    public int exitTimer;
    public Text exitCounter;

    public PlayerController PController;
    public GameObject ExitBoundsUI;

    void Start()
    {
        exitTimer = 500;
    }

    void Update()
    {
        exitTimer--;
        exitCounter.text = exitTimer + "   left";

        if (exitTimer <= 0)
        {
            exitTimer = 0;
            PController.health = 0;
            ExitBoundsUI.SetActive(false);
        }
    }
}