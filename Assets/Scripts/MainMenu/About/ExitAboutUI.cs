using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAboutUI : MonoBehaviour
{
	public GameObject QuitUI;
	public GameObject Logo;
	public GameObject Buttons;
	public GameObject AboutUI;
	public GameObject Camera2;
	public GameObject Camera3;

    public void CloseAboutUI()
    {
		Camera3.gameObject.SetActive(false);
		Camera2.gameObject.SetActive(true);
		Logo.gameObject.SetActive(true);
		Buttons.gameObject.SetActive(true);
        QuitUI.gameObject.SetActive(false);
		AboutUI.gameObject.SetActive(false);
    }
}
