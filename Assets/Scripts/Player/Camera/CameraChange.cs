using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{
	public GameObject ThirdCam;
	public GameObject FirstCam;
	public GameObject BackCam;
    public GameObject LookAtCam;
	public GameObject CockpitUI;
    public GameObject PlayerCanvas;

    public AudioListener listener;

	int CamMode;

    void Update()
    {
		if(Input.GetButtonDown("Camera"))
		{
			if(CamMode == 3)
			{
				CamMode = 0;
			}

			else
			{
				CamMode += 1;
			}
			StartCoroutine(CamChange());
		}
    }

	IEnumerator CamChange()
	{
		yield return new WaitForSeconds(0.01f);
		if(CamMode == 0)
		{
			ThirdCam.SetActive(true);
            PlayerCanvas.SetActive(true);
            listener.enabled = false;
            LookAtCam.SetActive(false);
            LookAtCam.SetActive(false);
            FirstCam.SetActive(false);
			BackCam.SetActive(false);
			CockpitUI.SetActive(false);
		}
		
		if(CamMode == 1)
		{
			FirstCam.SetActive(true);
            PlayerCanvas.SetActive(true);
            CockpitUI.SetActive(true);
            listener.enabled = false;
            LookAtCam.SetActive(false);
            ThirdCam.SetActive(false);
			BackCam.SetActive(false);
		}
		
		if(CamMode == 2)
		{
			BackCam.SetActive(true);
            PlayerCanvas.SetActive(true);
            listener.enabled = false;
            CockpitUI.SetActive(false);
            LookAtCam.SetActive(false);
            FirstCam.SetActive(false);
			ThirdCam.SetActive(false);
		}

        if (CamMode == 3)
        {
            listener.enabled = true;
            LookAtCam.SetActive(true);
            PlayerCanvas.SetActive(false);
            BackCam.SetActive(false);
            CockpitUI.SetActive(false);
            FirstCam.SetActive(false);
            ThirdCam.SetActive(false);
        }
    }
}
