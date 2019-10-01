using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldGenerator : MonoBehaviour
{
    public GameObject Flare1;
    public GameObject Flare2;
    public GameObject ShieldGeneratorExplosion;
    public GameObject TorpedoExplosion;
    public GameObject ShotExplosion;

    public Image SGHP;

    float SGmaxHealth = 2000f;
    float SGhealth;

    bool addedCurrent;

    void Start()
    {
        addedCurrent = false;
        SGhealth = SGmaxHealth;
    }

    void Update()
    {
        SGHP.fillAmount = SGhealth / SGmaxHealth;

        if (SGhealth < 600f)
        {
            Flare1.SetActive(true);
        }

        if (SGhealth < 400f)
        {
            Flare2.SetActive(true);
        }

        if (SGhealth <= 0)
        {
            Instantiate(ShieldGeneratorExplosion, transform.position, transform.rotation);

            if (addedCurrent == false)
            {
                Mission2Controller.ShieldsDowned += 1;
                addedCurrent = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("AllyShot"))
        {
            SGhealth -= 40;
            Instantiate(ShotExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("RapidFireShot"))
        {
            SGhealth -= 20;
            Instantiate(ShotExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("PlayerTorpedo"))
        {
            SGhealth -= 150;
            Instantiate(TorpedoExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
