using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    Mission1Controller M1Controller;
    Mission2Controller M2Controller;
    Mission3Controller M3Controller;

    public GameObject SGController1;
    public GameObject SGController2;

    public GameObject LSController1;
    public GameObject LSController2;

    public Text GeneratorsDestroyed;
    public Text GeneratorsProgress;
    public Text Quest1Details;

    public Text ShieldsDowned;
    public Text ShieldsProgress;
    public Text Quest2Details;

    public Text CapsulesDestroyed;
    public Text CapsulesProgress;
    public Text Quest3Details;

    public GameObject LevelCompleted;

    public AudioSource source;
    public AudioClip Mission2Task;
    public AudioClip CampaignCompleted;

    bool Task2Played;
    bool CampCompletePlayed;

    public GameObject WhiteScreen;

    private void Awake()
    {
        M1Controller = GetComponent<Mission1Controller>();
        M2Controller = GetComponent<Mission2Controller>();
        M3Controller = GetComponent<Mission3Controller>();
    }

    void Start()
    {
        Task2Played = false;
        CampCompletePlayed = false;
        SGController1.SetActive(false);
        SGController2.SetActive(false);
        LSController1.SetActive(false);
        LSController2.SetActive(false);
        LevelCompleted.gameObject.SetActive(false);
        Mission1Initiate();
    }

    void Update()
    {
        CheckIf1Done();

        CheckIf2Done();

        CheckIf3Done();
    }


    void CheckIf1Done()
    {
        if (M1Controller.Mission1Completed == true)
        {
            if (Task2Played == false)
            {
                source.PlayOneShot(Mission2Task);
                Task2Played = true;
            }

            Mission1Finished();
            Mission2Initiate();
        }
    }

    void CheckIf2Done()
    {
        if (M2Controller.Mission2Completed == true)
        {
            Mission2Finished();
            Mission3Initiate();
        }
    }

    void CheckIf3Done()
    {
        if (M3Controller.Mission3Completed == true)
        {
            LevelCompleted.gameObject.SetActive(true);

            if (CampCompletePlayed == false)
            {
                 source.PlayOneShot(CampaignCompleted);
                 CampCompletePlayed = true;
            }

            else
            {
                return;
            }

            Mission3Finished();

            Time.timeScale = 0.01f;
        }
    }

    //MISSION 1


    void Mission1Initiate()
    {
        M1Controller.gameObject.SetActive(true);
        Quest1Details.gameObject.SetActive(true);
        GeneratorsDestroyed.gameObject.SetActive(true);
        GeneratorsProgress.gameObject.SetActive(true);
    }

    void Mission1Finished()
    {
        M1Controller.gameObject.SetActive(false);
        Quest1Details.gameObject.SetActive(false);
        GeneratorsDestroyed.gameObject.SetActive(false);
        GeneratorsProgress.gameObject.SetActive(false);
    }


    //MISSION 2


    void Mission2Initiate()
    {
        SGController1.SetActive(true);
        SGController2.SetActive(true);
        M2Controller.gameObject.SetActive(true);
        Quest2Details.gameObject.SetActive(true);
        ShieldsDowned.gameObject.SetActive(true);
        ShieldsProgress.gameObject.SetActive(true);
    }

    void Mission2Finished()
    {
        SGController1.SetActive(false);
        SGController2.SetActive(false);
        LSController1.SetActive(true);
        LSController2.SetActive(true);
        M2Controller.gameObject.SetActive(false);
        Quest2Details.gameObject.SetActive(false);
        ShieldsDowned.gameObject.SetActive(false);
        ShieldsProgress.gameObject.SetActive(false);
    }


    //MISSION 3


    void Mission3Initiate()
    {
        M3Controller.gameObject.SetActive(true);
        Quest3Details.gameObject.SetActive(true);
        CapsulesDestroyed.gameObject.SetActive(true);
        CapsulesProgress.gameObject.SetActive(true);
    }

    void Mission3Finished()
    {
        Quest3Details.gameObject.SetActive(false);
        CapsulesDestroyed.gameObject.SetActive(false);
        CapsulesProgress.gameObject.SetActive(false);
    }
}
