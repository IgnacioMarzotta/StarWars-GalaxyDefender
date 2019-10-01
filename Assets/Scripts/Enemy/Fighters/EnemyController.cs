using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float enemyHealth;
	private float maxEnemyHealth = 200f;

	public Image enemyHPBar;

	public GameObject Body;
	public GameObject Colliders;
	public GameObject Canvas;
	public GameObject Explosion;

	private int ExplosionCounter;
    public bool isEnemyDead;

    AudioSource source;
    public AudioClip enemyExplosion;
    public AudioClip[] enemyDeath;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        source.clip = enemyDeath[Random.Range(0, enemyDeath.Length)];
        isEnemyDead = false;
        enemyHealth = maxEnemyHealth;
		ExplosionCounter = 0;
    }

    void Update()
    {
        enemyHPBar.fillAmount = enemyHealth / maxEnemyHealth;

		if(enemyHealth <= 0)
		{
            DestroyEnemy();
		}
    }

	IEnumerator WaitToDestroyEnemy()
	{
        source.PlayOneShot(enemyExplosion);
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}

    void DestroyEnemy()
    {
		Body.SetActive(false);
		Colliders.SetActive(false);
		Canvas.SetActive(false);
        source.PlayOneShot(source.clip);

		if(ExplosionCounter == 0)
		{
			Instantiate(Explosion, transform.position, transform.rotation);
			ExplosionCounter += 1;
		}

		else if(ExplosionCounter >= 1)
		{
			return;
		}

        isEnemyDead = true;
		StartCoroutine(WaitToDestroyEnemy());
    }
}
