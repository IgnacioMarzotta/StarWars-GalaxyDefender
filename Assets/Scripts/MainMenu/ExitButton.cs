using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
	public GameObject QuitUI;
	public GameObject Logo;
	public GameObject Buttons;
	public GameObject AboutUI;

    public void OpenQuitUI()
    {
		Logo.gameObject.SetActive(false);
		Buttons.gameObject.SetActive(false);
		AboutUI.gameObject.SetActive(false);
        QuitUI.gameObject.SetActive(true);
    }
}
