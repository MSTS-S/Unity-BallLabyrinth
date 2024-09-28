using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToClear : MonoBehaviour
{
    private float GetHandTrigerForce_L()
    {
        float HandTriggerForce_L = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        return HandTriggerForce_L;
    }

    private float GetHandTrigerForce_R()
    {
        float HandTriggerForce_R = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        return HandTriggerForce_R;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand_L"))
        {
            if (GetHandTrigerForce_L() > 0.0f)
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.transform.parent = other.transform;
                SceneManager.LoadScene("ClearScene");

            }
        }
        else if (other.CompareTag("Hand_R"))
        {
            if (GetHandTrigerForce_R() > 0.0f)
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.transform.parent = other.transform;
                SceneManager.LoadScene("ClearScene");
            }
        }
    }
}
