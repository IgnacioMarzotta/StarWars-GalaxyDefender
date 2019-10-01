using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator cam_anim;   //Animator de la camara tercera persona
    public Animator In1_anim;   //Animator de Invictus 1
    public Animator In2_anim;   //Animator de Invictus 2
    public Animator Im_anim;    //Animator de Immobilizer

    public Mission1Controller M1Controller;
    public Mission3Controller M3Controller;

    public GameObject UICanvas; //Canvas del Player

    void Start()
    {

        cam_anim.SetBool("playedFirst", false);
        cam_anim.enabled = true;
        UICanvas.SetActive(false);
        StartCoroutine(CameraAnimation1());
    }

    void Update()
    {
        if (M1Controller.Mission1Completed == true)
        {
            Im_anim.SetTrigger("im_destroyed");
        }

        if(M3Controller.Mission3Completed == true)
        {
            In1_anim.SetTrigger("in1_destroyed");
            In2_anim.SetTrigger("in2_destroyed");
        }
    }

    IEnumerator CameraAnimation1()
    {
        yield return new WaitForSeconds(6);
        UICanvas.SetActive(true);
        cam_anim.SetBool("playedFirst", true);
        cam_anim.enabled = false;
    }
}
