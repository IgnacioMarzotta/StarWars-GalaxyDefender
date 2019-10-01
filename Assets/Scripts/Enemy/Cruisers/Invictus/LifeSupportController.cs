using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSupportController : MonoBehaviour
{
    public GameObject Flare1;
    public GameObject Flare2;
    public GameObject LifeSupGenExplosion;
    public GameObject TorpedoExplosion;
    public GameObject ShotExplosion;
    
    public Image LSGHP;

    float LSGmaxHealth = 1000f;
    float LSGhealth;

    bool addedCurrent;

    void Start()
    {
        addedCurrent = false;
        LSGhealth = LSGmaxHealth;
    }

    void Update()
    {
        LSGHP.fillAmount = LSGhealth / LSGmaxHealth;

        if (LSGhealth < 1000f)
        {
            Flare1.SetActive(true);
        }

        if (LSGhealth < 400f)
        {
            Flare2.SetActive(true);
        }

        if (LSGhealth <= 0)
        {
            Instantiate(LifeSupGenExplosion, transform.position, transform.rotation);
            if (addedCurrent == false)
            {
                Mission3Controller.LifeSupDowned += 1;
                addedCurrent = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("AllyShot"))
        {
            LSGhealth -= 40;
            Instantiate(ShotExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("RapidFireShot"))
        {
            LSGhealth -= 20;
            Instantiate(ShotExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("PlayerTorpedo"))
        {
            LSGhealth -= 150;
            Instantiate(TorpedoExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}