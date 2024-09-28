using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    [System.Obsolete]
    private void Update()
    {
        Vector2 vectorR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

        this.transform.Rotate(0, vectorR.x, 0);
    }
}