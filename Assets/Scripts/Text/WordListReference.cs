using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Text/wordlist")]
public class WordListReference : Reference<StringArrayReference[]>
{

    public string GetRandom()
    {
        var array = value.GetRandom();
        return array.value.GetRandom();
    }

}
