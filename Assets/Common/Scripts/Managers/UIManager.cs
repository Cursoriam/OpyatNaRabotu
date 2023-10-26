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

    public static Vector2 ScreenBound { get; set; }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ScreenBound = mainCameraManager.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
            mainCameraManager.transform.position.z));

        int z = 0;
        UIBlackSplash bs = new UIBlackSplash();
        GameObject blackSplash = bs.Create("back_splash", "UI/base_square", Rect.zero, null, 0);

        UIImage imageCreator = new UIImage();
        GameObject bg = imageCreator.Create("background",
            "UI/background",
            new Rect(10, 10, 0.1f, 0.2f),
            blackSplash.transform, -1);

        imageCreator.Create("button", "UI/button", new Rect(90, 80, 1, 0.5f), bg.transform, -2);
    }
}
