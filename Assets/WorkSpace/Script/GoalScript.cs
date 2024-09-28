using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject TreasureChest;
    public GameObject Battery;

    [SerializeField, ReadOnly]
    private string BALL_TAG = "Ball";

    [SerializeField, ReadOnly]
    private string ANIMATER_BOOL = "OpenFlag";

    private Animator animator;
    private bool ClearFlag = false;

    private void PlaySound()
    {
        if (ClearFlag == false)
        {
            GetComponent<AudioSource>().Play();
            Battery.SetActive(true);
            animator.SetBool(ANIMATER_BOOL, true);
            ClearFlag = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(BALL_TAG))
        {
            PlaySound();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(BALL_TAG))
        {
            PlaySound();
        }
    }

    private void Awake()
    {
        animator = TreasureChest.GetComponent<Animator>();
        Battery.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlaySound();
        }
    }
}
