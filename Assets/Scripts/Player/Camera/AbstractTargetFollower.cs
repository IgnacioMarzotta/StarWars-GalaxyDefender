using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
    public abstract class AbstractTargetFollower : MonoBehaviour
    {
        public enum UpdateType // Los metodos de actualizacion son los siguientes:
        {
            FixedUpdate, // Update en FixedUpdate (para trackear rigidbodies).
            LateUpdate, // Update en LateUpdate. (para trackear objetivos que se mueven en Update)
            ManualUpdate, // Usuario debe llamar para actualizar la camara
        }

        [SerializeField] protected Transform m_Target;            // Objeto objetivo
        [SerializeField] private bool m_AutoTargetPlayer = true;  // En caso de que el PlayerCamRig tenga qeu targetear al Player automaticamente
        [SerializeField] private UpdateType m_UpdateType;         // Update type

        protected Rigidbody targetRigidbody;


        protected virtual void Start()
        {
            // Si auto targeting es usado, encuentra el objetivo con tag Player
            //  cualquier clase heredada de aqui debe tener nombre base.Start() para que funcione esta accion.
            if (m_AutoTargetPlayer)
            {
                FindAndTargetPlayer();
            }
            if (m_Target == null) return;
            targetRigidbody = m_Target.GetComponent<Rigidbody>();
        }


        private void FixedUpdate()
        {
            // Actualiza aqui en caso de que Updatetype sea Fixed en caso de que el target tenga 
            // rigidbody y no sea kinematic
            if (m_AutoTargetPlayer && (m_Target == null || !m_Target.gameObject.activeSelf))
            {
                FindAndTargetPlayer();
            }
            if (m_UpdateType == UpdateType.FixedUpdate)
            {
                FollowTarget(Time.deltaTime);
            }
        }


        private void LateUpdate()
        {
            // Actualiza desde aqui en case de que updatetype este seteado en Late o auto, si el target no posee
            // rigidbody, o si tiene pero esta seteado en kinematic
            if (m_AutoTargetPlayer && (m_Target == null || !m_Target.gameObject.activeSelf))
            {
                FindAndTargetPlayer();
            }
            if (m_UpdateType == UpdateType.LateUpdate)
            {
                FollowTarget(Time.deltaTime);
            }
        }


        public void ManualUpdate()
        {
            // Aqui actualiza si updatetype esta puesto en Late o Auto, si el objetivo no tiene un
            // rigidbody, o si tiene pero esta seteado a kinematic

            if (m_AutoTargetPlayer && (m_Target == null || !m_Target.gameObject.activeSelf))
            {
                FindAndTargetPlayer();
            }
            if (m_UpdateType == UpdateType.ManualUpdate)
            {
                FollowTarget(Time.deltaTime);
            }
        }

        protected abstract void FollowTarget(float deltaTime);


        public void FindAndTargetPlayer()
        {
            // auto targetea algun objecto taggeado player, en caso de que player sea nulo

            var targetObj = GameObject.FindGameObjectWithTag("Player");
            if (targetObj)
            {
                SetTarget(targetObj.transform);
            }
        }


        public virtual void SetTarget(Transform newTransform)
        {
            m_Target = newTransform;
        }


        public Transform Target
        {
            get { return m_Target; }
        }
    }
}
