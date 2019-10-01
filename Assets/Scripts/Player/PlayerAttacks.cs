using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour
{
	public Image RepairCooldown;
	public Image TorpedoesCooldown;
	public Image RapidFireCooldown;

	public Transform shootingPoint1;
	public Transform shootingPoint2;
	public Transform shootingPoint3;
	public Transform shootingPoint4;

    public Transform TorpedoShootingPoint1;
    public Transform TorpedoShootingPoint2;

    public Rigidbody ShotPrefab;
    public Rigidbody TorpedoPrefab;

	//Repair
    float cooldown1 = 10;
	//Torpedoes
    float cooldown2 = 15;
	//RapidFire
    float cooldown3 = 30;

	//Repair
    bool isCooldown1;
    //Torpedoes
	bool isCooldown2;
    //RapidFire
	bool isCooldown3;

	bool RapidFirePlayed;
    bool usingRapidFire;

	private int shootIndex;

    private float volLowRange = .2f;
    private float volHighRange = 1f;

	public AudioClip TorpedoFire;
    public AudioClip XWingShot;
	public AudioClip RapidFireStart;
	public AudioClip RapidFireShot;
	public AudioClip RapidFireEnd;
	public AudioClip[] RepairSound;

    private AudioSource source;

	void Awake()
	{
        source = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
		RapidFirePlayed = false;
		shootIndex = 0;
		source.clip = RepairSound[Random.Range(0,RepairSound.Length)];
    }

    void Update()
    {
		if(Input.GetButtonDown("Fire1"))
		{
			if(shootIndex == 3)
			{
				shootIndex = 0;
			}
			
			else
			{
				shootIndex += 1;
			}

			if(shootIndex == 0)
			{
				ShootFrom1();
			}

			if(shootIndex == 1)
			{
				ShootFrom2();
			}

			if(shootIndex == 2)
			{
				ShootFrom3();
			}

			if(shootIndex == 3)
			{
				ShootFrom4();
			}
		}

////////// REPAIR
        if(Input.GetButtonDown("Repair") && !isCooldown1)
        {
			isCooldown1 = true;
            source.PlayOneShot(source.clip);
			Repair();
            source.clip = RepairSound[Random.Range(0, RepairSound.Length)];
        }

		if(isCooldown1)
		{
			RepairCooldown.fillAmount += 1 / cooldown1 * Time.deltaTime;

			if(RepairCooldown.fillAmount >= 1)
			{
				RepairCooldown.fillAmount = 0;
				isCooldown1 = false;
			}
		}
////////// REPAIR


////////// TORPEDOES
        if(Input.GetButtonDown("Torpedoes") && !isCooldown2)
        {
			isCooldown2 = true;
			Torpedoes();
        }

		if(isCooldown2)
		{
			TorpedoesCooldown.fillAmount += 1 / cooldown2 * Time.deltaTime;
			
			if(TorpedoesCooldown.fillAmount >= 1)
			{
				TorpedoesCooldown.fillAmount = 0;
				isCooldown2 = false;
			}
		}
////////// TORPEDOES


//////////  RAPID FIRE
        if (Input.GetButtonDown("RapidFire") && !isCooldown3)
		{
			StartCoroutine(Ability3Cooldown());
			RapidFire();
			if(!RapidFirePlayed)
			{
				float vol = Random.Range(volLowRange, volHighRange);
				source.PlayOneShot(RapidFireStart, vol);
				StartCoroutine(RapidFireSound());
			}
		}

		if(isCooldown3)
		{
			RapidFireCooldown.fillAmount += 1 / cooldown3 * Time.deltaTime;
			
			if(RapidFireCooldown.fillAmount >= 1)
			{
				RapidFireCooldown.fillAmount = 0;
				isCooldown3 = false;
			}
		}
////////// RAPID FIRE
    }

    void ShootFrom1()
	{
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(XWingShot, vol);
        Rigidbody shotInstance;
		shotInstance = Instantiate(ShotPrefab, shootingPoint1.position, shootingPoint1.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
		shotInstance.AddForce(shootingPoint1.forward * 6);
	}

	void ShootFrom2()
	{
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(XWingShot, vol);
        Rigidbody shotInstance;
		shotInstance = Instantiate(ShotPrefab, shootingPoint2.position, shootingPoint2.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
		shotInstance.AddForce(shootingPoint2.forward * 6);
	}

	void ShootFrom3()
	{
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(XWingShot,vol);
        Rigidbody shotInstance;
		shotInstance = Instantiate(ShotPrefab, shootingPoint3.position, shootingPoint3.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
		shotInstance.AddForce(shootingPoint3.forward * 6);
	}

	void ShootFrom4()
	{
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(XWingShot, vol);
        Rigidbody shotInstance;
		shotInstance = Instantiate(ShotPrefab, shootingPoint4.position, shootingPoint4.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
		shotInstance.AddForce(shootingPoint4.forward * 6);
	}

	void Repair()
	{
        GetComponent<PlayerController>().health += 30;
	}

    void Torpedoes()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(TorpedoFire, vol);

        Rigidbody torpedoInstance1;
        torpedoInstance1 = Instantiate(TorpedoPrefab, TorpedoShootingPoint1.position, TorpedoShootingPoint1.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
        torpedoInstance1.AddForce(TorpedoShootingPoint1.forward * 3);

        Rigidbody torpedoInstance2;
        torpedoInstance2 = Instantiate(TorpedoPrefab, TorpedoShootingPoint2.position, TorpedoShootingPoint2.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
        torpedoInstance2.AddForce(TorpedoShootingPoint2.forward * 3);
    }

    void RapidFire()
    {
		float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(RapidFireShot, vol);

        Rigidbody shotInstance1;
        shotInstance1 = Instantiate(ShotPrefab, shootingPoint1.position, shootingPoint1.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
        shotInstance1.AddForce(shootingPoint1.forward * 6);

        Rigidbody shotInstance2;
        shotInstance2 = Instantiate(ShotPrefab, shootingPoint2.position, shootingPoint2.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
        shotInstance2.AddForce(shootingPoint2.forward * 6);

        Rigidbody shotInstance3;
        shotInstance3 = Instantiate(ShotPrefab, shootingPoint3.position, shootingPoint3.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
        shotInstance3.AddForce(shootingPoint3.forward * 6);

        Rigidbody shotInstance4;
		shotInstance4 = Instantiate(ShotPrefab, shootingPoint4.position, shootingPoint4.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
		shotInstance4.AddForce(shootingPoint4.forward * 6);
    }

	IEnumerator Ability3Cooldown()
	{
		yield return new WaitForSeconds(5f);
		isCooldown3 = true;
	}

	IEnumerator RapidFireSound()
	{
		RapidFirePlayed = true;
		yield return new WaitForSeconds(5f);
		float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(RapidFireEnd, vol);
		RapidFirePlayed = false;
	}
}