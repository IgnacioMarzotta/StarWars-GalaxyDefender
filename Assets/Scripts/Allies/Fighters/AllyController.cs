using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyController : MonoBehaviour
{
	public float allyHealth;
	private float maxAllyHealth = 150f;
	private int ExplosionCounter;

    public bool isAllyDead;

	public GameObject Colliders;
	public GameObject Body;
	public GameObject Canvas;
	public GameObject Explosion;

    AudioSource source;
    public AudioClip allyExplosion;
    public AudioClip[] allyDeath;

    bool ExplosionPlayed;
    bool DeathSoundPlayed;

	public Image AllyHPBar;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        source.clip = allyDeath[Random.Range(0, allyDeath.Length)];
        isAllyDead = false;
        allyHealth = maxAllyHealth;
		allyHealth = 150f;
		ExplosionCounter = 0;
    }

    void Update()
    {
        AllyHPBar.fillAmount = allyHealth / maxAllyHealth;

		if(allyHealth <= 0)
		{
            DestroyAlly();
		}
    }

	IEnumerator WaitToDestroyAlly()
	{
        source.PlayOneShot(allyExplosion);
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}

    void DestroyAlly()
    {
		Colliders.SetActive(false);
		Body.SetActive(false);
		Canvas.SetActive(false);

        if (ExplosionCounter == 0 && DeathSoundPlayed == false)
		{
            source.PlayOneShot(source.clip);
            DeathSoundPlayed = true;
			Instantiate(Explosion, transform.position, transform.rotation);
			ExplosionCounter += 1;
		}

		else if(ExplosionCounter >= 1)
		{
			return;
		}

        isAllyDead = true;
		StartCoroutine(WaitToDestroyAlly());
    }
}