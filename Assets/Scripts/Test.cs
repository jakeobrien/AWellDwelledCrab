using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    [SerializeField]
    private WordMappings _wordMappings;
    [SerializeField]
    private string _test;

    [ContextMenu("Test")]
    public void DoTest()
    {
        Dr.Log(_wordMappings.Make(_test));
    }
}
