using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryButton : MonoBehaviour
{
	public GameObject MainMenuCanvas;
	public GameObject Gallery;
	public GameObject Camera2;
	public GameObject Camera3;
	public GameObject Camera4;

    public void OpenGallery()
    {
		StartCoroutine (WaitToOpenGallery());
    }

	IEnumerator WaitToOpenGallery()
	{
		yield return new WaitForSeconds(1f);
		Camera2.gameObject.SetActive(false);
		Camera3.gameObject.SetActive(false);
		MainMenuCanvas.gameObject.SetActive(false);
		Camera4.gameObject.SetActive(true);
		Gallery.gameObject.SetActive(true);
	}
}