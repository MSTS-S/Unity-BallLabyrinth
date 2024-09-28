using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearToInitial : MonoBehaviour
{
    private bool X_Flag = false;
    private bool A_Flag = false;

    void Update()
    {
        X_Flag = false;
        A_Flag = false;

        if ((OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch) == true)) X_Flag = true;
        if ((OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch) == true)) A_Flag = true;

        if (X_Flag && A_Flag) SceneManager.LoadScene("InitialScene");
    }
}
