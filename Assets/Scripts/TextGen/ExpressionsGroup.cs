using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "TextGen/ExpressionsGroup")]
public class ExpressionsGroup : Reference<Expressions[]>
{

    public string GetRandom()
    {
        var array = value.GetRandom();
        return array.value.GetRandom();
    }

}
