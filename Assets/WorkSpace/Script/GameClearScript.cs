using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearScript : MonoBehaviour
{
    public GameObject GameObject_Battery_Blue;
    public GameObject GameObject_Battery_Red;
    public GameObject GameObject_Battery_Green;
    public GameObject GameObject_Battery_Cyan;
    public GameObject GameObject_Battery_Orange;

    public GameObject TrophyPedestal;
    public GameObject Trophy;

    private AudioSource audioSource;
    public AudioClip PedestalMoving;
    public AudioClip ParticleSystem;

    private BatterySetting Battery_Blue;
    private BatterySetting Battery_Red;
    private BatterySetting Battery_Green;
    private BatterySetting Battery_Cyan;
    private BatterySetting Battery_Orange;

    const float UP_SPEED = 0.175f;

    private float Position_y;
    private float MoveDistance = 0.0f;

    private int ClearCount;

    private bool PedestalStopFlag = false;
    private bool AudioPlayFlag = false;
    private bool FinishFlag = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        Battery_Blue = GameObject_Battery_Blue.GetComponent<BatterySetting>();
        Battery_Red = GameObject_Battery_Red.GetComponent<BatterySetting>();
        Battery_Green = GameObject_Battery_Green.GetComponent<BatterySetting>();
        Battery_Cyan = GameObject_Battery_Cyan.GetComponent<BatterySetting>();
        Battery_Orange = GameObject_Battery_Orange.GetComponent<BatterySetting>();

        Trophy.SetActive(false);
    }

    private void CheckClear()
    {
        ClearCount = 0;

        if (Battery_Blue.ClearState()) ClearCount += 1;
        if (Battery_Red.ClearState()) ClearCount += 1;
        if (Battery_Green.ClearState()) ClearCount += 1;
        if (Battery_Cyan.ClearState()) ClearCount += 1;
        if (Battery_Orange.ClearState()) ClearCount += 1;

        Debug.Log("ClearCount : " + ClearCount);
    }

    void Update()
    {
        CheckClear();

        if (Input.GetKey(KeyCode.C))
        {
            ClearCount = 5;
        }
        Position_y = TrophyPedestal.transform.position.y;

        if (ClearCount == 5 && PedestalStopFlag == false)
        {
            if (AudioPlayFlag == false)
            {
                audioSource.PlayOneShot(PedestalMoving);
                AudioPlayFlag = true;
            }
            TrophyPedestal.transform.position = new Vector3(0, Position_y + Time.deltaTime * UP_SPEED, 0);
            MoveDistance += Time.deltaTime * UP_SPEED;

        }

        if (Mathf.Abs(MoveDistance) > TrophyPedestal.transform.localScale.y && PedestalStopFlag == false)
        {
            GetComponent<AudioSource>().Stop();
            PedestalStopFlag = true;
            Trophy.SetActive(true);
        }

        if (PedestalStopFlag == true && FinishFlag == false)
        {
            TrophyPedestal.SetActive(false);
            GetComponent<ParticleSystem>().Play();
            audioSource.PlayOneShot(ParticleSystem);
            FinishFlag = true;

        }
    }
}
