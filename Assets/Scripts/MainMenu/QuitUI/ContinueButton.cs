using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
	public GameObject QuitUI;
	public GameObject Logo;
	public GameObject Buttons;

    public void CloseQuitUI()
    {
		Logo.gameObject.SetActive(true);
		Buttons.gameObject.SetActive(true);
        QuitUI.gameObject.SetActive(false);
    }
}
