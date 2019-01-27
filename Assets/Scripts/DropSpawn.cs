using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawn : MonoBehaviour
{

    public bool constrainXZRot;
    private static RigidbodyConstraints baseConstraints = RigidbodyConstraints.None;//RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    private void Start()
    {
        var rb = gameObject.AddComponent<Rigidbody>();
        StartCoroutine(CleanUp());
    }

    private IEnumerator CleanUp()
    {
        yield return new WaitForSeconds(1f);
        var rb = GetComponent<Rigidbody>();
        if (constrainXZRot) rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | baseConstraints;
        else rb.constraints = baseConstraints;
        while (rb.velocity.magnitude > 0.5f)
        {
            yield return new WaitForSeconds(3f);
        }
        Destroy(rb);
    }


}
