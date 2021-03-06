﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

[CreateAssetMenu(menuName = "TextGen/WordMappings")]
public class WordMappings : ScriptableObject
{

    [Serializable]
    public class Mapping
    {
        public string code;
        public ExpressionsGroup wordRef;
    }
    [SerializeField]
    private Mapping[] _mappings;


    public string Make(string pattern)
    {
        var result = new StringBuilder(pattern);
        var c = 0;
        var i = 0;
        foreach (var mapping in _mappings)
        {
            while ((i = result.ToString().IndexOf(mapping.code)) >= 0)
            {
                result.Remove(i, mapping.code.Length);
                // result.Insert(i, mapping.wordRef.GetRandom());
                result.Insert(i, Make(mapping.wordRef.GetRandom()));
                c++;
                if (c > 10) break;

            }
        }
        return result.ToString();
    }

    public string GetRandomWordForCode(string code)
    {
        var words = GetWordRefForCode(code);
        if (words == null) return null;
        return words.GetRandom();
    }

    private ExpressionsGroup GetWordRefForCode(string code)
    {
        foreach (var mapping in _mappings)
        {
            if (mapping.code == code) return mapping.wordRef;
        }
        return null;
    }

}
