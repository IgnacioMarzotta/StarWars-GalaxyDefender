using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideShowUI : MonoBehaviour
{
	public GameObject SelectionPanel;

	//Canvases
    public GameObject XWing;
    public GameObject XWingB;
    public GameObject RebelYWing;
    public GameObject AWing;
    public GameObject HomeOne;
    public GameObject Nebulon;
    public GameObject Tantive;
    public GameObject Liberty;
    public GameObject Immobilizer;
    public GameObject Invictus;
    public GameObject TieF;
    public GameObject TieB;
    public GameObject TieI;
    public GameObject Venator;
    public GameObject Arc170;
    public GameObject Acclamator;
    public GameObject RepublicYWing;
    public GameObject Providence;
    public GameObject Munificent;
    public GameObject Lucrehulk;
    public GameObject Recusant;

	private bool isHidden;

	void Start()
	{
		isHidden = false;
	}

    void Update()
    {

        if(isHidden)
		{
			SelectionPanel.SetActive(false);
			XWing.SetActive(false);
			XWingB.SetActive(false);
			RebelYWing.SetActive(false);
			AWing.SetActive(false);
			HomeOne.SetActive(false);
			Nebulon.SetActive(false);
			Tantive.SetActive(false);
			Liberty.SetActive(false);
			Immobilizer.SetActive(false);
			Invictus.SetActive(false);
			TieF.SetActive(false);
			TieB.SetActive(false);
			TieI.SetActive(false);
			Venator.SetActive(false);
			Arc170.SetActive(false);
			Acclamator.SetActive(false);
			RepublicYWing.SetActive(false);
			Providence.SetActive(false);
			Munificent.SetActive(false);
			Lucrehulk.SetActive(false);
			Recusant.SetActive(false);
		}

		if(!isHidden)
		{
			SelectionPanel.SetActive(true);
			XWing.SetActive(true);
			XWingB.SetActive(true);
			RebelYWing.SetActive(true);
			AWing.SetActive(true);
			HomeOne.SetActive(true);
			Nebulon.SetActive(true);
			Tantive.SetActive(true);
			Liberty.SetActive(true);
			Immobilizer.SetActive(true);
			Invictus.SetActive(true);
			TieF.SetActive(true);
			TieB.SetActive(true);
			TieI.SetActive(true);
			Venator.SetActive(true);
			Arc170.SetActive(true);
			Acclamator.SetActive(true);
			RepublicYWing.SetActive(true);
			Providence.SetActive(true);
			Munificent.SetActive(true);
			Lucrehulk.SetActive(true);
			Recusant.SetActive(true);
		}
    }

	public void OnClickChange()
	{
		isHidden = !isHidden;
	}
}

//		InfoPanels = GameObject.FindGameObjectWithTag("MainMenuInfoPanel");
