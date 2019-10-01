using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitiate : MonoBehaviour
{
	public GameObject WorldBorders;
	public GameObject CameraController;

    void Start()
    {
        StartCoroutine(InitiateLevel());
    }

	IEnumerator InitiateLevel ()
	{
		yield return new WaitForSeconds(15f);
		CameraController.gameObject.SetActive(true);
		WorldBorders.gameObject.SetActive(true);
	}
}
