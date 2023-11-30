using System;
using UnityEngine;


public class AssemblyTypeComponent : MonoBehaviour
{
    public enum AssemblyType
    {
        Triangle,
        Square,
        Circle
    };

    [NonSerialized] public AssemblyType Type;
}
