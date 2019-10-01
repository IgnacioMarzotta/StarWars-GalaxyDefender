using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof (PlayerController))]
public class PlayerMovement : MonoBehaviour
{
        // Referencia al player
        private PlayerController m_Player;

        private void Awake()
        {
            // Referencia el player controller
            m_Player = GetComponent<PlayerController>();
        }
    
        private void FixedUpdate()
        {
            // Lee input de roll, pitch y yaw del player
            float roll = Input.GetAxis("Horizontal");
            float pitch = Input.GetAxis("Vertical");
            bool airBrakes = Input.GetButton("Brakes");

            // auto acelera o desacelera dependiendo de si frena
            float throttle = airBrakes ? -1 : 1;

            // Pasa el input del player
            m_Player.Move(roll, pitch, 0, throttle, airBrakes);
		}
}