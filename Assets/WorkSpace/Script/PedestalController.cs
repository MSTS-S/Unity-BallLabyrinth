using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalController : MonoBehaviour
{
    const float DOWN_SPEED = 0.2f;
    private bool TouchFlag = true;
    private float MoveDistance = 0.0f;
    private float Position_x, Position_y, Position_z;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Grabbable"))
        {
            TouchFlag = false;
            GetComponent<AudioSource>().Play();
        }
    }

    private void GetCurrentPosition()
    {
        Position_x = this.transform.position.x;
        Position_y = this.transform.position.y;
        Position_z = this.transform.position.z;
    }

    private void Awake()
    {
        GetCurrentPosition();
    }
    private void Update()
    {
        GetCurrentPosition();

        if (TouchFlag == false)
        {
            this.transform.position = new Vector3(Position_x, Position_y + -Time.deltaTime * DOWN_SPEED, Position_z);
            MoveDistance += Time.deltaTime * DOWN_SPEED;
        }

        if (Mathf.Abs(MoveDistance) > this.transform.localScale.y)
        {
            GetComponent<AudioSource>().Stop();
            this.gameObject.SetActive(false);
        }
    }
}