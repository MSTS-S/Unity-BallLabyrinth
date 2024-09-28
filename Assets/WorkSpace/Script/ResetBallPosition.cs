using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallPosition : MonoBehaviour
{
    public float InitialLocalPosition_X, InitialLocalPosition_Y, InitialLocalPosition_Z;

    const float LIMIT_POSITION_X = 0.3f;
    const float LIMIT_POSITION_Y = 0.1f;
    const float LIMIT_POSITION_Z = 0.3f;

    private void ResetPosition()
    {
        this.transform.localPosition = new Vector3(InitialLocalPosition_X, InitialLocalPosition_Y, InitialLocalPosition_Z);
    }

    void Update()
    {
        if (Mathf.Abs(this.transform.localPosition.x) >= LIMIT_POSITION_X)
        {
            ResetPosition();
        }

        if (Mathf.Abs(this.transform.localPosition.y) >= LIMIT_POSITION_Y)
        {
            ResetPosition();
        }

        if (Mathf.Abs(this.transform.localPosition.z) >= LIMIT_POSITION_Z)
        {
            ResetPosition();
        }
    }
}
