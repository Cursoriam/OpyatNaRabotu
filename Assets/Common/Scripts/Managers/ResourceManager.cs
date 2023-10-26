using UnityEngine;

public static class ResourceManager
{
    public static GameObject LoadAsset(string path)
    {
        GameObject go = Resources.Load<GameObject>(path);
        if (go == null)
            return null;

        return go;
    }
}
