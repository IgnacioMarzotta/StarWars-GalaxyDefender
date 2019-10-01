using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGallery : MonoBehaviour
{
	public GameObject MainMenuCanvas;
	public GameObject Gallery;
	public GameObject Camera2;
	public GameObject Camera3;
	public GameObject Camera4;

    public void CloseGallery()
    {
		StartCoroutine (WaitToCloseGallery());
    }

	IEnumerator WaitToCloseGallery()
	{
		yield return new WaitForSeconds(1f);
		Camera4.gameObject.SetActive(false);
		Gallery.gameObject.SetActive(false);
		Camera3.gameObject.SetActive(false);
		Camera2.gameObject.SetActive(true);
		MainMenuCanvas.gameObject.SetActive(true);
	}
}