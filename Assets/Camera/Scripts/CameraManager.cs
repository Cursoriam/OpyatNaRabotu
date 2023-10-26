using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region attributes

    public static Camera Instance { get; set; }

    #endregion
    
    public void Awake()
    {
        Camera camera = GetComponent<Camera>();
        if (camera != null && Instance == null)
        {
            Instance = camera;
        }
    }
}
