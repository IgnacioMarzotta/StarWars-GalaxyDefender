using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//La mayoria del script esta hecha en C#, aunque una parte que incluye algunas variables de giro esta hecho en JS.

public class PlayerController : MonoBehaviour
{
	//https://es.wikipedia.org/wiki/%C3%81ngulos_de_navegaci%C3%B3n
		
    [SerializeField] private float m_MaxEnginePower = 40f;        // Potencia maxima del motor
    [SerializeField] private float m_Lift = 0.002f;               // Cantidad de "lift" / "Levantar" mientras el player se mueve hacia adelante
    [SerializeField] private float m_ZeroLiftSpeed = 300;         // Velocidad a la cual no hay "lift"
    [SerializeField] private float m_RollEffect = 1f;             // Fuerza de rotacion en Z / alabeo
    [SerializeField] private float m_PitchEffect = 1f;            // Fuerza de rotacion en y / cabeceo
    [SerializeField] private float m_YawEffect = 0.2f;            // Fuerza de rotacion en x / guiñada
    [SerializeField] private float m_BankedTurnEffect = 0.5f;     // La cantidad de turno de hacer un turno bancado.
    [SerializeField] private float m_AerodynamicEffect = 0.02f;   // Cuanto afecta la aerodinamica a la velocidad del jugador
    [SerializeField] private float m_AutoTurnPitch = 0.5f;        // Cuanto compensa la rotacion en x luego de un giro
    [SerializeField] private float m_AutoRollLevel = 0.2f;        // Cuanto compensa la rotacion en y luego de un giro
    [SerializeField] private float m_AutoPitchLevel = 0.2f;       // Cuanto compensa la rotacion en mientras no gira
    [SerializeField] private float m_AirBrakesEffect = 3f;        // Cuanto el drag del rigidbody afecta al girar
    [SerializeField] private float m_ThrottleChangeSpeed = 0.3f;  // Aceleracion
    [SerializeField] private float m_DragIncreaseFactor = 0.001f; // Cuanto deberia aumentar el drag con la velocidad

    public float Altitude { get; private set; }                     // Peso del player sobre el suelo
    public float Throttle { get; private set; }                     // Cantidad de potencia usada
    public bool AirBrakes { get; private set; }                     // Si se estan usando los frenos o no
    public float ForwardSpeed { get; private set; }                 // Que tan rapido el player se mueve hacia adelante
    public float EnginePower { get; private set; }                  // Cuanto poder se le da al motor
    public float MaxEnginePower{ get { return m_MaxEnginePower; }}  // Output maximo del motor.
    public float RollAngle { get; private set; }
    public float PitchAngle { get; private set; }
    public float RollInput { get; private set; }
    public float PitchInput { get; private set; }
    public float YawInput { get; private set; }
    public float ThrottleInput { get; private set; }

    private float m_OriginalDrag;         // Drag cuando empieza la escena.
    private float m_OriginalAngularDrag;  // Drag angular cuando empieza la escena.
    private float m_AeroFactor;
    private bool m_Immobilized = false;   // Para hacer el jugador incontrolable, en caso de impacto, por ejemplo.
    private float m_BankedTurnAmount;
    private Rigidbody m_Rigidbody;
	WheelCollider[] m_WheelColliders;

    public Image HPBar;
	public GameObject DeathUI;
	public GameObject Thruster1;
	public GameObject Thruster2;
	public GameObject Flare1;
	public GameObject Flare2;
    public GameObject PlayerExplosion;
        
	float maxHealth = 100f;
	public float health;

    private bool hasExploded;
    public bool insideEngine;

    private void Start()
    {
		health = maxHealth;
        hasExploded = false;    

        m_Rigidbody = GetComponent<Rigidbody>();
        // Guarda los valores de drag originales, varian durante la escena
        m_OriginalDrag = m_Rigidbody.drag;
        m_OriginalAngularDrag = m_Rigidbody.angularDrag;

		for (int i = 0; i < transform.childCount; i++ )
		{
			foreach (var componentsInChild in transform.GetChild(i).GetComponentsInChildren<WheelCollider>())
			{
				componentsInChild.motorTorque = 0.18f;
			}
		}
    }


        public void Move(float rollInput, float pitchInput, float yawInput, float throttleInput, bool airBrakes)
        {
            // Transfiere valores de input en propiedades
            RollInput = rollInput;
            PitchInput = pitchInput;
            YawInput = yawInput;
            ThrottleInput = throttleInput;
            AirBrakes = airBrakes;

            ClampInputs();

            CalculateRollAndPitchAngles();

            AutoLevel();

            CalculateForwardSpeed();

            ControlThrottle();

            CalculateDrag();

            CaluclateAerodynamicEffect();

            CalculateLinearForces();

            CalculateTorque();

            CalculateAltitude();
        }
		
		void Update()
		{
			HPBar.fillAmount = health / 100f;

			if(health <= 0)
			{
                PlayerDeath();
                StartCoroutine(DeathUIController());
            }

			if(health < 60)
			{
				Flare1.gameObject.SetActive(true);
			}

			if(health < 40)
			{
				Flare2.gameObject.SetActive(true);
				Thruster1.gameObject.SetActive(false);
			}

			if(health < 20)
			{
				Thruster2.gameObject.SetActive(false);
			}

			if(health > 60)
			{
				Thruster2.gameObject.SetActive(true);
				Thruster1.gameObject.SetActive(true);
				Flare1.gameObject.SetActive(false);
				Flare2.gameObject.SetActive(false);
			}

			if(health > 100)
			{
				health = 100f;
			}

            if (insideEngine)
            {
                health --;
            }
		}

        void PlayerDeath()
        {
           GetComponent<MeshRenderer>().enabled = false;
           GetComponent<PlayerMovement>().enabled = false;
           GetComponent<PlayerAttacks>().enabled = false;
           GetComponent<Transform>();
        }
        
		IEnumerator DeathUIController()
		{
			yield return new WaitForSeconds(2f);

            DeathUI.gameObject.SetActive(true);
            
            if(hasExploded == false)
            {
                Instantiate(PlayerExplosion, transform.position, transform.rotation);
                hasExploded = true;
            }

            else
            {
                hasExploded = true;
            }
		}

        private void ClampInputs()
        {
            // clamp the inputs to -1 to 1 range
            RollInput = Mathf.Clamp(RollInput, -1, 1);
            PitchInput = Mathf.Clamp(PitchInput, -1, 1);
            YawInput = Mathf.Clamp(YawInput, -1, 1);
            ThrottleInput = Mathf.Clamp(ThrottleInput, -1, 1);
        }


        private void CalculateRollAndPitchAngles()
        {
            // Calcula angulos de roll & pitch
            var flatForward = transform.forward;
            flatForward.y = 0;
            if (flatForward.sqrMagnitude > 0)
            {
                flatForward.Normalize();
                // Calcula angulo de pitch actual
                var localFlatForward = transform.InverseTransformDirection(flatForward);
                PitchAngle = Mathf.Atan2(localFlatForward.y, localFlatForward.z);
                // Calcula angulo de roll actual
                var flatRight = Vector3.Cross(Vector3.up, flatForward);
                var localFlatRight = transform.InverseTransformDirection(flatRight);
                RollAngle = Mathf.Atan2(localFlatRight.y, localFlatRight.x);
            }
        }


        private void AutoLevel()
        {
            m_BankedTurnAmount = Mathf.Sin(RollAngle);
            // Compensa el roll en caso de que no haya input
            if (RollInput == 0f)
            {
                RollInput = -RollAngle*m_AutoRollLevel;
            }
            // Compensa el pitch en caso de que no haya input
            if (PitchInput == 0f)
            {
                PitchInput = -PitchAngle*m_AutoPitchLevel;
                PitchInput -= Mathf.Abs(m_BankedTurnAmount*m_BankedTurnAmount*m_AutoTurnPitch);
            }
        }


        private void CalculateForwardSpeed()
        {
            // Velocidad horizontal
            var localVelocity = transform.InverseTransformDirection(m_Rigidbody.velocity);
            ForwardSpeed = Mathf.Max(0, localVelocity.z);
        }


        private void ControlThrottle()
        {
            // Sobreesribe la velocidad actual si esta inmobilizado
            if (m_Immobilized)
            {
                ThrottleInput = -0.5f;
            }

            Throttle = Mathf.Clamp01(Throttle + ThrottleInput*Time.deltaTime*m_ThrottleChangeSpeed);

            EnginePower = Throttle*m_MaxEnginePower;
        }


        private void CalculateDrag()
        {
            float extraDrag = m_Rigidbody.velocity.magnitude*m_DragIncreaseFactor;
            m_Rigidbody.drag = (AirBrakes ? (m_OriginalDrag + extraDrag)*m_AirBrakesEffect : m_OriginalDrag + extraDrag);
            m_Rigidbody.angularDrag = m_OriginalAngularDrag*ForwardSpeed;
        }


        private void CaluclateAerodynamicEffect()
        {
            if (m_Rigidbody.velocity.magnitude > 0)
            {
                m_AeroFactor = Vector3.Dot(transform.forward, m_Rigidbody.velocity.normalized);
                m_AeroFactor *= m_AeroFactor;
                var newVelocity = Vector3.Lerp(m_Rigidbody.velocity, transform.forward*ForwardSpeed,
                                               m_AeroFactor*ForwardSpeed*m_AerodynamicEffect*Time.deltaTime);
                m_Rigidbody.velocity = newVelocity;

                m_Rigidbody.rotation = Quaternion.Slerp(m_Rigidbody.rotation,
                                                      Quaternion.LookRotation(m_Rigidbody.velocity, transform.up),
                                                      m_AerodynamicEffect*Time.deltaTime);
            }
        }


        private void CalculateLinearForces()
        {
            // Guarda variables de fuerza aqui:
            var forces = Vector3.zero;
            forces += EnginePower*transform.forward;
            var liftDirection = Vector3.Cross(m_Rigidbody.velocity, transform.right).normalized;
            var zeroLiftFactor = Mathf.InverseLerp(m_ZeroLiftSpeed, 0, ForwardSpeed);
           var liftPower = ForwardSpeed*ForwardSpeed*m_Lift*zeroLiftFactor*m_AeroFactor;
            forces += liftPower*liftDirection;
           m_Rigidbody.AddForce(forces);
        }


        private void CalculateTorque()
        {
            // Guarda las variables de torque aqui
            var torque = Vector3.zero;
            // Añade torque para el pitch en caso de input
            torque += PitchInput*m_PitchEffect*transform.right;
            // Añade torque para el yaw el caso de input
            torque += YawInput*m_YawEffect*transform.up;
            //  Añade torque para el roll en caso de input
            torque += -RollInput*m_RollEffect*transform.forward;
            //  Añade torque para el giro
            torque += m_BankedTurnAmount*m_BankedTurnEffect*transform.up;
            // Torque total, multiplicado por la velocidad horizontal
            m_Rigidbody.AddTorque(torque*ForwardSpeed*m_AeroFactor);
        }


        private void CalculateAltitude()
        {
            // Calculo de altitud
            // Lanza un raycast hacia el suelo (en caso de haber uno), para no colisionar con los propios colliders del player
            var ray = new Ray(transform.position - Vector3.up*10, -Vector3.up);
            RaycastHit hit;
            Altitude = Physics.Raycast(ray, out hit) ? hit.distance + 10 : transform.position.y;
        }


        //Funcion para llamar de otros scripts, en caso de que el jugador impacte, o para algo personalizado.
        public void Immobilize()
        {
            m_Immobilized = true;
        }


        // Saca al jugador del estado de impacto
        public void Reset()
        {
            m_Immobilized = false;
        }
}
