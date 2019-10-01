using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
	public float clockwise = 15f;
	public float counterClockwise = -15f;

    void Update()
    {
		if(Input.GetKey(KeyCode.E))
		{
			transform.Rotate(0, Time.deltaTime * clockwise, 0);
		}

		if(Input.GetKey(KeyCode.Q))
		{
			transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
		}
    }
}
