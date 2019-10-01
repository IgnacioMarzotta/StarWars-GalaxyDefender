using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityGenerator : MonoBehaviour
{
    public Image GGHP;

    public GameObject Flare1;
    public GameObject Flare2;
    public GameObject Flare3;
    public GameObject GeneratorExplosion;
    public GameObject TorpedoExplosion;
    public GameObject ShotExplosion;

    float GGmaxHealth = 2500f;
    public float GGhealth;

    bool addedCurrent;

    void Start()
    {
        addedCurrent = false;
        GGhealth = GGmaxHealth;
    }

    void Update()
    {
        GGHP.fillAmount = GGhealth / GGmaxHealth;

        if (GGhealth < 600f)
        {
            Flare1.SetActive(true);
        }

        if (GGhealth < 400f)
        {
            Flare2.SetActive(true);
        }

        if (GGhealth < 200f)
        {
            Flare3.SetActive(true);
        }

        if (GGhealth <= 0)
        {
            Instantiate(GeneratorExplosion, transform.position, transform.rotation);
            if (addedCurrent == false)
            {
                Mission1Controller.GeneratorsCompleted += 1;
                addedCurrent = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("AllyShot"))
        {
            GGhealth -= 40;
            Instantiate(ShotExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("RapidFireShot"))
        {
            GGhealth -= 20;
            Instantiate(ShotExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("PlayerTorpedo"))
        {
            GGhealth -= 150;
            Instantiate(TorpedoExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
