using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugScript : MonoBehaviour
{
    public GameObject Debug;

    void Update()
    {
        Debug.GetComponent<TextMeshProUGUI>().text = this.transform.position.y.ToString();
    }
}
