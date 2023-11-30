using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AssemblyLineManager
{
    #region constants

    private const float AssemblyLineVelocity = 5f;
    private const string AssemblyLinePath = "assembly_line";

    #endregion

    #region attributes

    private readonly List<GameObject> _lines;

    private Vector2 _lineSize;

    private Vector2 _spawnPoint;

    private bool _isVertical;

    #endregion

    #region construction

    public AssemblyLineManager(Vector2 spawnPoint, bool isVertical = false)
    {
        _lines = new List<GameObject>();
        _spawnPoint = spawnPoint;
        _isVertical = isVertical;
    }

    #endregion

    #region public methods

    public void DoUpdate()
    {
        for (int i = 0; i < _lines.Count; i++)
        {
            if (_isVertical)
            {
                _lines[i].transform.Translate((Time.deltaTime * AssemblyLineVelocity) * Vector3.left);
                if (_lines[i].transform.position.y > GameManager.ScreenBound.y + _lineSize.y / 2)
                {
                    _lines[i].transform.position = new Vector3(_spawnPoint.x + _lineSize.x / 2,
                        _spawnPoint.y + _lineSize.y, 0);
                }
            }
            else
            {
                _lines[i].transform.Translate((Time.deltaTime * AssemblyLineVelocity) * Vector3.right);
                if (_lines[i].transform.position.x > GameManager.ScreenBound.x + _lineSize.x / 2)
                {
                    _lines[i].transform.position = new Vector3(_spawnPoint.x - _lineSize.x / 2,
                        _spawnPoint.y + _lineSize.y / 2, 0);
                }
            }
        }
    }

    public void CreateAssemblyLines()
    {
        GameObject assemblyLine = ResourceManager.LoadAsset<GameObject>(AssemblyLinePath);

        if (assemblyLine == null)
            return;

        _lineSize = new Vector2(assemblyLine.GetComponent<SpriteRenderer>().bounds.size.x,
            assemblyLine.GetComponent<SpriteRenderer>().bounds.size.y);

        int linesNeeded = _isVertical
            ? (int) Mathf.Ceil(GameManager.ScreenBound.y * 2 / _lineSize.y)
            : (int) Mathf.Ceil(GameManager.ScreenBound.x * 2 / _lineSize.x);

        GameObject go = new GameObject();
        go.name = "Assembly";
        for (int i = 0; i <= linesNeeded; i++)
        {
            CreateAssemblyLine(assemblyLine, i, go);
        }
    }

    #endregion

    #region service methods

    void CreateAssemblyLine(GameObject assemblyLine, int number, GameObject assembly)
    {
        GameObject line = Object.Instantiate(assemblyLine);
        if (_isVertical)
            line.transform.rotation = Quaternion.Euler(line.transform.rotation.x, line.transform.rotation.y, -90);

        line.transform.position = _isVertical
            ? new Vector3(_spawnPoint.x + _lineSize.x / 2,
                _spawnPoint.y + _lineSize.y + (_lineSize.y * number), 0)
            : new Vector3(_spawnPoint.x + (_lineSize.x * number),
                _spawnPoint.y + _lineSize.y / 2, 0);
        line.transform.SetParent(assembly.transform);
        _lines.Add(line);
    }

    #endregion
}