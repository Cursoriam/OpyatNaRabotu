using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region constants

    private const string ASSEMBLY_LINE_CREATOR_NAME = "AssemblyLineCreator";

    #endregion
    
    #region properties

    public static Vector2 ScreenBound { get; set; }

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        ScreenBound = CameraManager.Instance.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, 0));

        GameObject assemblyLineCreator = new GameObject(ASSEMBLY_LINE_CREATOR_NAME);
        assemblyLineCreator.AddComponent<AssemblyLineCreator>();
    }
    
}
