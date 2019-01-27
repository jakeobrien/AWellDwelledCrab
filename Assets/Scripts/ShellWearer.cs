using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShellWearer : MonoBehaviour
{

    public Vector3 pos;
    public Vector3 rot;
    public Shell currentShell;
    public float force;
    public float donSpeed;

    private bool _isDonning;

    public void Wear(Shell newShell)
    {
        if (_isDonning) return;
        StartCoroutine(WearNewShell(newShell));
    }

    private IEnumerator CastOffOldShell()
    {
        if (currentShell == null) yield break;
        var dir = transform.forward;
        dir.y += 0.5f;
        currentShell.transform.parent = null;
        currentShell.Throw(dir * force);
        currentShell = null;
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator WearNewShell(Shell newShell)
    {
        _isDonning = true;
        yield return CastOffOldShell();
        currentShell = newShell;
        var destPos = pos + transform.InverseTransformDirection(newShell.PosOffset);
        var destRot = rot + newShell.Rot;
        newShell.transform.parent = transform;
        var sequence = DOTween.Sequence();
        sequence.Append(newShell.transform.DOLocalMove(destPos, donSpeed));
        sequence.Join(newShell.transform.DOLocalRotate(destRot, donSpeed));
        yield return new WaitForSeconds(1f);
        _isDonning = false;
    }

}
