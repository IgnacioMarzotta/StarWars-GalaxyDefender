using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof (ParticleSystem))]
public class AfterburnerParticles : MonoBehaviour
{
        // script que controla el sistema de particulas basado
        // en la velocidad del Jugador
        public Color minColour; // Color base al iniciar

        private PlayerController m_Player; // El jugador al que el sistema de particulas esta enganchado
        private ParticleSystem m_System; // Particle System siendo controlado
        private float m_OriginalStartSize; // Tamaño inicial
        private float m_OriginalLifetime; // Tiempo de vida original
        private Color m_OriginalStartColor; // Color inicial del Particle System

        private void Start()
        {
            // Obtener el player de la jerarquia
            m_Player = FindPlayerParent();

            // conseguir el particle system
            m_System = GetComponent<ParticleSystem>();

            // propiedades originales del sistema de particulas
            m_OriginalLifetime = m_System.main.startLifetime.constant;
            m_OriginalStartSize = m_System.main.startSize.constant;
            m_OriginalStartColor = m_System.main.startColor.color;
        }


        private void Update()
        {
			ParticleSystem.MainModule mainModule = m_System.main;
			// actualizar el sistema de particulas basado en la velocidad del jugador
			mainModule.startLifetime = Mathf.Lerp(0.0f, m_OriginalLifetime, m_Player.Throttle);
			mainModule.startSize = Mathf.Lerp(m_OriginalStartSize*.3f, m_OriginalStartSize, m_Player.Throttle);
			mainModule.startColor = Color.Lerp(minColour, m_OriginalStartColor, m_Player.Throttle);
        }


        private PlayerController FindPlayerParent()
        {
            // conseguir referencia al componente transform
            var t = transform;

            // Atraviesa la jerarquia hasta encontrar el PlayerController
            // (ya que esta ubicado en un objeto hijo)
            while (t != null)
            {
                var aero = t.GetComponent<PlayerController>();
                if (aero == null)
                {
                    // intenta el siguiente padre 
                    t = t.parent;
                }
                else
                {
                    return aero;
                }
            }
			// Controller no encontrado
			throw new Exception(" PlayerContoller no fue encontrado en la jerarquia");
        }    
}