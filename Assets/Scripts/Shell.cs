using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    public PlayerReference player;
    public ShellAsset shellAsset;
    public PromptTrigger promptTriggerPrefab;
    private PromptTrigger _promptTrigger;

    public Vector3 PosOffset { get { return shellAsset.posOffset; } }
    public Vector3 Rot { get { return shellAsset.rot; } }

    private void Start()
    {
        _promptTrigger = Instantiate(promptTriggerPrefab, transform.position, Quaternion.identity);
        _promptTrigger.gameObject.AddComponent<StickToTransform>().stickTo = transform;
        _promptTrigger.engaged.AddListener(Don);
    }

    public void Don()
    {
        player.value.GetComponent<ShellWearer>().Wear(this);
        _promptTrigger.enabled = false;
    }

    public void Throw(Vector3 force)
    {
        StartCoroutine(DoThrow(force));
    }

    private IEnumerator DoThrow(Vector3 force)
    {
        var rb = gameObject.AddComponent<Rigidbody>();
        yield return null;
        rb.AddForce(force, ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
        while (rb.velocity.magnitude > 1f)
        {
            yield return new WaitForSeconds(1f);
        }
        Destroy(rb);
        _promptTrigger.enabled = true;
    }


}
