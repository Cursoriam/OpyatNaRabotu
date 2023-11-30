using UnityEngine;

public class UIBlackSplash : UIImage
{
    #region consts

    private const string BlackSplashSpritePath = "UI/base_square";

    #endregion
    
    #region factory

    public static UIBlackSplash Create(UINode parent, string name, Rect rect)
    {
        UIBlackSplash control = UITools.CreateObject<UIBlackSplash>(parent.Transform, name);
        control.Create(rect, BlackSplashSpritePath);
        return control;
    }

    #endregion

    #region service methods

    protected override void Create(Rect rect, string path)
    {
        base.Create(rect, path);
        SpriteRenderer.color = new Color(0, 0, 0, 0.5f);
    }

    #endregion
}