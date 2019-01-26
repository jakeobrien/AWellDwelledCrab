using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Radar : MonoBehaviour
{


    [SerializeField]
    private float _detectInterval;
    [SerializeField]
    private int _maxResults;
    [SerializeField]
    private float _radius;
    [SerializeField]
    private LayerMask _layersToDetect;
    [SerializeField]
    private Collider[] _collidersToIgnore;

    private Collider[] _detectedColliders;
    private GameObject[] _results;

    public GameObject[] Results
    {
        get { return _results; }
    }

    private void OnEnable()
    {
        StartCoroutine(Detect());
    }

    private IEnumerator Detect()
    {
        _detectedColliders = new Collider[_maxResults];
        var wait = new WaitForSeconds(_detectInterval);
        while (enabled)
        {
            var count = Physics.OverlapSphereNonAlloc(transform.position, _radius, _detectedColliders, _layersToDetect);
            var results = new List<GameObject>(count);
            for (int i = 0; i < count; i++ )
            {
                if (Array.IndexOf(_collidersToIgnore, _detectedColliders[i]) >= 0) continue;
                var obj = _detectedColliders[i].gameObject;
                results.Add(obj);
            }
            _results = results.ToArray();
            yield return wait;
        }
    }

}
