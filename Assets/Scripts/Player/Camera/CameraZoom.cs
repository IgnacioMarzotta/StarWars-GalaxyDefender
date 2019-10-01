using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    float m_FieldOfView;

	void Start()
	{
        m_FieldOfView = 60.0f;	
	}

    void Update()
    {
		Camera.main.fieldOfView = m_FieldOfView;

		if(Input.GetButton("Zoom"))
		{
			m_FieldOfView = 20.0f;
		}

		if(Input.GetButtonUp("Zoom"))
		{
			m_FieldOfView = 60.0f;
		}
    }
}
