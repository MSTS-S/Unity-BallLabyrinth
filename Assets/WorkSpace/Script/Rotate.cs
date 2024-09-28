using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    const float RX = 1.5f;
    const float RY = 1.5f;
    const float RZ = 0.0f;

    private void Update()
    {
        this.transform.Rotate(RX, RY, RZ);
    }
}
