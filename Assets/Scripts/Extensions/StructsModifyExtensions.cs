using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StructsModifyExtensions
{
    public static Color SetAlfa(this Color color, float alfa)
    {
        color.a = alfa;
        return color;
    }
}
