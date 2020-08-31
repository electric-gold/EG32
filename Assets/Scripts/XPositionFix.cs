using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPositionFix : MonoBehaviour
{
    private static readonly XPositionFix instance = new XPositionFix();

    public static XPositionFix Instance
    {
        get { return instance; }
    }

    public float XPos
    {
        get; set;
    }
}
