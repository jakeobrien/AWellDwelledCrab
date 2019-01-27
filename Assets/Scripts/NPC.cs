using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NPC : MonoBehaviour
{

    public PlayerReference playerReference;
    public Animator animator;

    private void Start()
    {
        animator.SetBool("isNPC", true);
    }

    public void SetIsTalking(bool isTalking)
    {
        Dr.Log(isTalking);
        animator.SetBool("isTalking", isTalking);
    }

    public void FacePlayer()
    {
        var dir = (playerReference.value.transform.position - transform.position).normalized;
        var lookAt = Quaternion.LookRotation(dir, Vector3.up);
        transform.DORotateQuaternion(lookAt, 0.7f);
    }

}
