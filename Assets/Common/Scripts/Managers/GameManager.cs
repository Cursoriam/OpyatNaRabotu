using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region properties

    public static Vector2 ScreenBound { get; set; }
    
    private MainAssembly _mainAssembly;
    private SubAssembly _circleAssembly;
    private SubAssembly _triangleAssembly;
    private SubAssembly _squareAssembly;

    #endregion

    #region engine methods

    // Start is called before the first frame update
    void Start()
    {
        ScreenBound = CameraManager.Instance.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, 0));
        
        Initialize();
    }

    private void Update()
    {
        _mainAssembly.MoveAssemblyLines();
        _circleAssembly.MoveAssemblyLines();
        _squareAssembly.MoveAssemblyLines();
        _triangleAssembly.MoveAssemblyLines();
    }

    public void Initialize()
    {
        GameObject subAssembly = ResourceManager.LoadAsset<GameObject>("Prefabs/assembly_sub");
        Vector2 subAssemblySize = subAssembly.GetComponent<SpriteRenderer>().bounds.size;
        _mainAssembly = new MainAssembly();
        _triangleAssembly =
            new SubAssembly(subAssembly, new Vector2(-ScreenBound.x, -ScreenBound.y + subAssemblySize.y),
                AssemblyTypeComponent.AssemblyType.Triangle);
        _squareAssembly = new SubAssembly(subAssembly, new Vector2(0, -ScreenBound.y + subAssemblySize.y),
            AssemblyTypeComponent.AssemblyType.Square);
        _circleAssembly = new SubAssembly(subAssembly,
            new Vector2(ScreenBound.x - subAssemblySize.x,
                -ScreenBound.y + subAssemblySize.y), AssemblyTypeComponent.AssemblyType.Circle);
        
        Time.timeScale = 1;
    }

    #endregion
}