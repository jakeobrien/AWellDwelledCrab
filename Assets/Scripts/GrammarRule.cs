using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTracery;
using System;

[Serializable]
public class GrammarSymbol
{
    public string id;
    public string[] strings;
}

[CreateAssetMenu(menuName = "Grammar/Rule")]
public class GrammarRule : ScriptableObject
{

    public string rootId;
    public GrammarSymbol[] symbols;

    private TraceryGrammar _grammar;

    public string Get()
    {
        CreateGrammar();
        return _grammar.Parse(rootId);
    }

    private void CreateGrammar()
    {
        if (_grammar != null) return;
        var dict = new Dictionary<string,JSONObject>();
        foreach (var symbol in symbols)
        {
            var strings = new List<JSONObject>();
            foreach (var s in symbol.strings) strings.Add(JSONObject.Create(s));
            dict[symbol.id] = new JSONObject(strings.ToArray());
        }
        var json = new JSONObject(dict);
        _grammar = new TraceryGrammar(json);
    }



    private const string grammar = @"
        'greeting' : ['#hello#', '#hello# #query#', #hello# #observation#',  ],
        'hello' : ['#salutation#', '#salutation# #addressee#', ],
        'salutation' : ['', ]
        'addressee' : [],
        'addresseeNoun' : [],
        'addresseeAdj' : [],
        'query' : [],


    ";


}
