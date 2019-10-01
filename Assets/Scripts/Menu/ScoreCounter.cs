using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
	
	public static int scoreValue = 0;
	Text score;

    void Start()
    {
		score = GetComponent<Text>();    
    }

    void Update()
    {
        score.text = "" + scoreValue;

		if(scoreValue == 30)
		{
			SceneManager.LoadScene("Level2");
		}
    }
}
