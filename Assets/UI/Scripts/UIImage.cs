using UnityEngine;

public class UIImage
{
    #region attributes

    protected GameObject Image;

    #endregion

    public virtual GameObject Create(string name, string path, Rect rect, Transform parent, int z)
    {
        //TODO: to common
        GameObject go = new GameObject();
        RectTransform rf = go.AddComponent<RectTransform>();
        go.name = name;
        
        if (go == null)
            return null;
        
        Image = go;

        if (parent != null && parent.GetComponent<RectTransform>() != null)
            Image.transform.SetParent(parent);

        rf.sizeDelta = Vector2.one;
        rf.localScale = rect.size;
        rf.localPosition = new Vector3(rf.localPosition.x, rf.localPosition.y, z);
        
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = ResourceLoader.Load<Sprite>(path);
        
        return Image;
    }
}