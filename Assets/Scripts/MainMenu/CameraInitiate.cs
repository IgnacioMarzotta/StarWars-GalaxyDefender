using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraInitiate : MonoBehaviour
{
	public GameObject Camera1;
	public GameObject Camera2;
    public GameObject MainMenu;

    void Start()
    {
        MainMenu.gameObject.SetActive(false);
        Camera2.gameObject.SetActive(false);
		Camera1.gameObject.SetActive(true);
		StartCoroutine(InitiateMainMenu());
    }

    IEnumerator InitiateMainMenu()
	{
		yield return new WaitForSeconds(17);
		Camera1.gameObject.SetActive(false);
		Camera2.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(true);
	}
}
