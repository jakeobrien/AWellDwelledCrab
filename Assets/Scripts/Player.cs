using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator animator;
    public PlayerReference playerReference;

    private void Start()
    {
        playerReference.value = this;
        animator.SetBool("isNPC", false);
        StartCoroutine(VaryAnims());
    }

    private IEnumerator VaryAnims()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4f, 20f));
            animator.SetTrigger("vary");
        }
    }

}
