using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCannonFireB : MonoBehaviour
{
    public Transform shootingPoint1;
    public Transform shootingPoint2;

    public Transform muzzlePoint1;
    public Transform muzzlePoint2;

    public Rigidbody CannonShotPrefab;
    public GameObject CannonMuzzle;

    private int cannonCooldown;
    private int cannonShotIndex;
    private float volLowRange = .2f;
    private float volHighRange = 1f;

    AudioSource source;
    public AudioClip cannonShotSound;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        cannonCooldown = 200;
        cannonShotIndex = 0;
        ShootFrom1();
    }

    void Update()
    {
        {
            cannonCooldown -= 1;

            if (cannonShotIndex == 2)
            {
                cannonShotIndex = 0;
            }

            if (cannonShotIndex == 0 && cannonCooldown <= 0)
            {
                ShootFrom1();
            }

            if (cannonShotIndex == 1 && cannonCooldown <= 0)
            {
                ShootFrom2();
            }
        }
    }

    void ShootFrom1()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(cannonShotSound, vol);
        Instantiate(CannonMuzzle, muzzlePoint1.position, muzzlePoint1.rotation * Quaternion.Euler(0f, 0f, 0f));
        Rigidbody shotInstance;
        shotInstance = Instantiate(CannonShotPrefab, shootingPoint1.position, shootingPoint1.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
        shotInstance.AddForce(shootingPoint1.forward * 5);
        cannonShotIndex += 1;
        cannonCooldown = 100;
    }

    void ShootFrom2()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(cannonShotSound, vol);
        Instantiate(CannonMuzzle, muzzlePoint2.position, muzzlePoint2.rotation * Quaternion.Euler(0f, 0f, 0f));
        Rigidbody shotInstance;
        shotInstance = Instantiate(CannonShotPrefab, shootingPoint2.position, shootingPoint2.rotation * Quaternion.Euler(90f, 0f, 0f)) as Rigidbody;
        shotInstance.AddForce(shootingPoint2.forward * 5);
        cannonShotIndex += 1;
        cannonCooldown = 100;
    }
}
