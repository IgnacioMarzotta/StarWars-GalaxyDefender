using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour
{
	private List<GameObject> models;

	private int selectionIndex = 0;

    private void Start()
    {
		models = new List<GameObject>();
		foreach (Transform t in transform)
		{
			models.Add(t.gameObject);
			t.gameObject.SetActive(false);
		}

		models[selectionIndex].SetActive(true);
    }

	private void Update()
	{
		Debug.Log(selectionIndex);
	}

	public void Select( int index)
	{
		if(index == selectionIndex)
		{
			return;
		}
		if(index < 0 || index >= models.Count)
		{
			return;
		}

		models[selectionIndex].SetActive(false);
		selectionIndex = index;
		models[selectionIndex].SetActive(true);
	}
}

/*
    public GameObject XWing;
    public GameObject Immobilizer;
    public GameObject Invictus;
    public GameObject Tie;
    public GameObject HomeOne;
    public GameObject Nebulon;
    public GameObject Tantive;
    public GameObject Liberty;
    public GameObject XWingB;
    public GameObject AWing;
    public GameObject RebelYWing;
    public GameObject Venator;
    public GameObject Arc170;
    public GameObject Acclamator;
    public GameObject RepublicYWing;
    public GameObject Providence;
    public GameObject Munificent;
    public GameObject Lucrehulk;
    public GameObject Recusant;
*/