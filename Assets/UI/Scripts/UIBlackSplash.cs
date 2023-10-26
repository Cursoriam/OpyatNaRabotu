using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBlackSplash : UIImage
{
    public override GameObject Create(string name, string path, Rect rect, Transform parent, int z)
    {
        Vector2 screenBounds = UIManager.ScreenBound;
        base.Create(name,
            path,
            new Rect(-screenBounds.x, -screenBounds.y, screenBounds.x * 2, screenBounds.y * 2),
            parent,
            z);

        Image.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0.5f);
        return Image;
    }
}