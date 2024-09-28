using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialScene_HandR : MonoBehaviour
{
    [SerializeField]
    private Transform _HandAnchor;

    [SerializeField]
    private OVRInput.Controller _TargetController;

    [SerializeField]
    private float _MaxDistance = 50.0f;
    void Update()
    {
        var connected = OVRInput.IsControllerConnected(this._TargetController);
        if (!connected)
            return;

        // Cast ray from controller
        var pointerRay = new Ray(this._HandAnchor.position, this._HandAnchor.forward);

        if (Physics.Raycast(pointerRay, out var hitInfo, this._MaxDistance))
        {
            var tag = hitInfo.collider.gameObject.tag;
            if (tag == "Main" && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}
