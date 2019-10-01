using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject as1;
    public GameObject as2;
    public GameObject as3;

    void Start()
    {
        as2.SetActive(false);
        as3.SetActive(false);
        as1.SetActive(true);
        StartCoroutine(LevelSounds());
    }
    
    IEnumerator LevelSounds()
    {
        yield return new WaitForSeconds(39);
        as1.SetActive(false);
        as2.SetActive(true);
        as3.SetActive(true);
    }
}
