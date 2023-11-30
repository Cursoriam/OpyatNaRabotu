using System;
using UnityEngine;

public class UIImage : UINode
{

    #region attributes

    protected SpriteRenderer SpriteRenderer;

    #endregion

    #region factory

    public static UIImage Create(UINode parent, string name, Rect rect, string spritePath)
    {
        UIImage control = UITools.CreateObject<UIImage>(parent.Transform, name);
        control.Create(rect, spritePath);
        return control;
    }

    #endregion

    #region service methods

    protected virtual void Create(Rect rect, string spritePath)
    {
        base.Create(rect);
        SpriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        SpriteRenderer.sprite = ResourceManager.LoadAsset<Sprite>(spritePath);
        
    }

    #endregion
    
}