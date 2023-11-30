using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINode : MonoBehaviour
{
    #region attributes
    
    [NonSerialized] RectTransform m_Transform;
    
    #endregion

    #region properties
    
    public RectTransform Transform
    {
        get
        {
            if (((object) m_Transform) == null)
                m_Transform = GetComponent<RectTransform>();
            return m_Transform;
        }
    }
    
    public Rect Rect
    {
        get => Transform.rect;
        set
        {
            if (Transform.rect == value)
                return;

            Transform.sizeDelta = value.size;
            Transform.pivot = new Vector2(
                Mathf.Approximately(value.size.x, 0) ? 0 : -value.min.x / value.size.x,
                Mathf.Approximately(value.size.y, 0) ? 0 : -value.min.y / value.size.y
            );
        }
    }

    #endregion
    
    
    public static UINode Create(
        Transform _Parent,
        string _ID,
        Rect   _Rect,
        bool   _Centered = false
    )
    {
        UINode control = UITools.CreateObject<UINode>(_Parent, _ID);
        if (_Centered)
        {
            control.Create(new Rect(_Rect.center, Vector2.zero));
            control.Rect = new Rect(-_Rect.size / 2, _Rect.size);
        }
        else
        {
            control.Create(_Rect);
        }

        return control;
    }

    public virtual void Create(Rect rect)
    {
        Transform.anchoredPosition = rect.min;
        
        Transform.pivot     = Vector2.zero;
        Transform.sizeDelta = rect.size;
    }
}
