using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceLoader
{
    public static object Load(string path)
    {
        object obj = Resources.Load(path);
        if (obj == null)
        {
            Debug.LogError($"There is no resourse on path {path}");
            return null;
        }

        return obj;
    }

    public static T Load<T>(string path) where T : Object
    {
        T obj = Resources.Load<T>(path);
        if (obj == null)
        {
            Debug.LogError($"There is no resourse on path {path}");
            return null;
        }

        return obj;
    }
}