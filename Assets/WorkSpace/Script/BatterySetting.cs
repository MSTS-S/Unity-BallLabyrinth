using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySetting : MonoBehaviour
{
    public GameObject Battery;
    public GameObject BatterySpace;
    public GameObject LightBall;
    public LineRenderer LaserLight;
    public float SetPosition_X, SetPosition_Y, SetPosition_Z;

    private Vector3 BatteryPosition;
    private Vector3 BatterySetPosition;
    private bool ClearFlag = false;
    private bool AudioPlayFlag = false;
    private float Distance;

    const float OBJECT_SET_ACTIVE_DISTANCE = 0.5f;

    public bool ClearState()
    {
        return ClearFlag;
    }

    private void Awake()
    {
        BatterySetPosition = BatterySpace.transform.position;
        LaserLight.SetPosition(0, LightBall.transform.position);
    }

    private void Update()
    {
        BatteryPosition = Battery.transform.position;

        Distance = Vector3.Distance(BatterySetPosition, BatteryPosition);

        if (Distance < OBJECT_SET_ACTIVE_DISTANCE)
        {
            if (Battery.transform.parent.CompareTag("Untagged"))
            {
                Battery.transform.position = new Vector3(SetPosition_X, SetPosition_Y, SetPosition_Z);
                Battery.transform.eulerAngles = new Vector3(0, 0, 90);
                BatterySpace.SetActive(false);

                LaserLight.SetPosition(1, LightBall.transform.position + new Vector3 (0, 10, 0));
                if (AudioPlayFlag == false)
                {
                    GetComponent<AudioSource>().Play();
                    AudioPlayFlag = true;
                }
                ClearFlag = true;
            }
            else
            {
                BatterySpace.SetActive(true);
                LaserLight.SetPosition(1, LightBall.transform.position);
                ClearFlag = false;
                AudioPlayFlag = false;
            }
        }
        else
        {
            BatterySpace.SetActive(false);
            LaserLight.SetPosition(1, LightBall.transform.position);
            ClearFlag = false;
            AudioPlayFlag = false;
        }
    }
}
