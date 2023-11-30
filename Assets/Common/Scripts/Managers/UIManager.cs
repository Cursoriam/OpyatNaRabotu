using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{

    #region constants

    private const string WINDOW_BG_PATH = "UI/window_bg";


    #endregion

    #region attributes

    [SerializeField] private Camera mainCameraManager;

    #endregion

    #region properties

    

    #endregion
    
    #region public methods

    public static void InstantiateGameOverWindow()
    {
        UINode node = UINode.Create(null, "node", new Rect(-GameManager.ScreenBound.x, -GameManager.ScreenBound.y, GameManager.ScreenBound.x * 2, GameManager.ScreenBound.y * 2), true);
        UIBlackSplash blackSplash = UIBlackSplash.Create(node,
            "blackSplash", 
            new Rect(node.Transform.rect.x, node.Transform.rect.y, node.Transform.rect.width, node.Transform.rect.height));
        UIImage image = UIImage.Create(blackSplash, "square", new Rect(-GameManager.ScreenBound.x + 3f, -GameManager.ScreenBound.y + 3f, 7, 3.5f),
            "UI/background");
    }

    #endregion
}
