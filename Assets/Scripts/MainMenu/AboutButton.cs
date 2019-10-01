using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutButton : MonoBehaviour
{
	public GameObject QuitUI;
	public GameObject Buttons;
	public GameObject Logo;
	public GameObject AboutUI;
	public GameObject Camera2;
	public GameObject Camera3;

    public void OpenAboutUI()
    {
		StartCoroutine (WaitToOpenAbout());
    }

	IEnumerator WaitToOpenAbout()
	{
		yield return new WaitForSeconds(1f);
		Camera2.gameObject.SetActive(false);
		Camera3.gameObject.SetActive(true);
		Logo.gameObject.SetActive(false);
        QuitUI.gameObject.SetActive(false);
        Buttons.gameObject.SetActive(false);
		AboutUI.gameObject.SetActive(true);
	}
}
