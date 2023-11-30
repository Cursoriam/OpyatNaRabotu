using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITools
{
    public static T CreateObject<T>(Transform transform, string name) where T: MonoBehaviour
    {
        GameObject go = new GameObject();
        T component = go.AddComponent<T>();
        
        go.AddComponent<RectTransform>();
        
        go.name = name;
        go.transform.SetParent(transform, false);
        return component;
    }
}
