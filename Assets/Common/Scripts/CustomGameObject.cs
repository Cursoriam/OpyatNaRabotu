using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGameObject
{
    protected virtual GameObject Create(string name)
    {
        GameObject go = new GameObject();
        go.AddComponent<RectTransform>();
        go.name = name;
        
        return go;
    }
}
