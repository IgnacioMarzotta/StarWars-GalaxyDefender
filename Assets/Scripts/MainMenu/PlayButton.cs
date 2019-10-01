using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
	public GameObject Slash;

    public void PlayGame()
    {
		Slash.gameObject.SetActive(true);
		StartCoroutine (LoadLevel1());
    }

	IEnumerator LoadLevel1()
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("LoadingSceneLVL1");
	}
}
