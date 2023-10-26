using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AssemblyLineCreator : MonoBehaviour
{
    #region attributes

    [SerializeField] private GameObject _assemblyLine;

    
    [SerializeField] private float _velocity = 0.5f;
    private List<GameObject> _lines;

    private Vector2 _lineSize;

    #endregion


    #region engine methods

    // Start is called before the first frame update
    void Awake()
    {
        _lines = new List<GameObject>();
        LoadAssemblyLines();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _lines.Count; i++)
        {
            _lines[i].transform.Translate((Time.deltaTime * _velocity) * Vector3.right);
            if (_lines[i].transform.position.x > UIManager.ScreenBound.x + _lineSize.x / 2)
            {
                _lines[i].transform.position = new Vector3(-UIManager.ScreenBound.x - _lineSize.x / 2,
                    -UIManager.ScreenBound.y + _lineSize.y / 2, 0);
            }
        }
    }

    #endregion

    #region service methods

    void LoadAssemblyLines()
    {
        _lineSize = new Vector2(_assemblyLine.GetComponent<SpriteRenderer>().bounds.size.x,
            _assemblyLine.GetComponent<SpriteRenderer>().bounds.size.y);
        int linesNeeded = (int) Mathf.Ceil(UIManager.ScreenBound.x * 2 / _lineSize.x);
        for(int i = 0; i <= linesNeeded; i++){
            GameObject line = Instantiate(_assemblyLine);
            line.transform.position = new Vector3(-UIManager.ScreenBound.x + (_lineSize.x * i),
                -UIManager.ScreenBound.y + _lineSize.y / 2, 0);
            line.name = "BG" + i;
            _lines.Add(line);
        }
    }

    public AssemblyLineCreator(GameObject assemblyLine)
    {
        _assemblyLine = assemblyLine;
    }

    #endregion
    
}