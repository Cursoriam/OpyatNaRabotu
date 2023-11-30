using UnityEngine;

public static class ResourceManager
{
    public static T LoadAsset<T>(string path) where T : Object
    {
        T asset = Resources.Load<T>(path);
        if (asset == null)
            return null;

        return asset;
    }
}
