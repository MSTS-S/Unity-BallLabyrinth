using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBatteryPosition : MonoBehaviour
{
    public float InitialLocalPosition_X = 0, InitialLocalPosition_Y, InitialLocalPosition_Z;
    public float InitialRotation_X, InitialRotation_Y, InitialRotation_Z;

    const float LIMIT_POSITION_Y = 0.0f;

    void Update()
    {
        if (this.transform.position.y <= LIMIT_POSITION_Y)
        {
            this.transform.position = new Vector3(InitialLocalPosition_X, InitialLocalPosition_Y, InitialLocalPosition_Z);
            this.transform.eulerAngles = new Vector3(InitialRotation_X, InitialRotation_Y, InitialRotation_Z);
        }
    }
}
