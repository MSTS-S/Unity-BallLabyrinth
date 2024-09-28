using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerController : MonoBehaviour
{
    [SerializeField]
    private Transform _HandAnchor;

    [SerializeField]
    private OVRInput.Controller _TargetController;

    [SerializeField]
    private float _MaxDistance = 50.0f;

    [SerializeField]
    private LineRenderer _LaserPointerRenderer;

    void Update()
    {
        var connected = OVRInput.IsControllerConnected(this._TargetController);
        if (!connected)
            return;

        var pointerRay = new Ray(this._HandAnchor.position, this._HandAnchor.forward);

        this._LaserPointerRenderer.SetPosition(0, pointerRay.origin);

        if (Physics.Raycast(pointerRay, out var hitInfo, this._MaxDistance))
        {
            if (hitInfo.transform.tag == "Hand_L" || hitInfo.transform.tag == "Hand_R")
            {
                _LaserPointerRenderer.SetPosition(1, pointerRay.origin + pointerRay.direction * this._MaxDistance);
            }
            else
            {
                _LaserPointerRenderer.SetPosition(1, hitInfo.point);
            }
        }
        else
        {
            _LaserPointerRenderer.SetPosition(1, pointerRay.origin + pointerRay.direction * this._MaxDistance);
        }
    }
}
