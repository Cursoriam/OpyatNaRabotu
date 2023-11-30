using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SubAssembly
{
    #region const

    private float Velocity = 0.5f;

    #endregion

    #region attributes

    private readonly GameObject _assembly;
    private readonly GameObject _assemblyParent;
    private readonly List<GameObject> _assemblyLines;
    private Vector2 _startPoint;
    private AssemblyTypeComponent.AssemblyType _type;

    #endregion

    #region properties

    private Vector2 AssemblySize { get; set; }

    #endregion

    #region construction

    public SubAssembly(GameObject assembly, Vector2 startPoint, AssemblyTypeComponent.AssemblyType type)
    {
        _assembly = assembly;

        if (_assembly == null)
            return;

        _assemblyParent = new GameObject
        {
            name = "assembly"
        };

        _assemblyLines = new List<GameObject>();

        Bounds assemblyBounds = _assembly.GetComponent<SpriteRenderer>() != null
            ? _assembly.GetComponent<SpriteRenderer>().bounds
            : default;

        if (assemblyBounds == default)
            return;

        AssemblySize = new Vector2(assemblyBounds.size.x, assemblyBounds.size.y);
        _startPoint = startPoint;
        _type = type;
        CreteAssemblyLines();
    }

    #endregion

    #region public methods

    public void MoveAssemblyLines()
    {
        foreach (Transform lineTransform in _assemblyLines.Select(line => line.transform))
        {
            lineTransform.Translate(Time.deltaTime * Velocity * Vector2.right);

            if (lineTransform.position.y > GameManager.ScreenBound.y + AssemblySize.y / 2)
                lineTransform.position = new Vector2(_startPoint.x + AssemblySize.x / 2,
                    _startPoint.y - AssemblySize.y / 2);
        }
    }

    #endregion

    #region service methods

    private void CreteAssemblyLines()
    {
        int linesNeeded = (int) Mathf.Ceil(GameManager.ScreenBound.y * 2 / AssemblySize.y);

        for (int i = 0; i <= linesNeeded; i++)
        {
            CreateAssemblyLine(i);
        }
    }

    private void CreateAssemblyLine(int number)
    {
        GameObject line = Object.Instantiate(_assembly);

        line.name = $"assembly_piece_{number}";
        Transform lineTransform = line.transform;

        lineTransform.position = new Vector2(_startPoint.x + AssemblySize.x / 2,
            _startPoint.y + AssemblySize.y * number);
        line.AddComponent<AssemblyTypeComponent>().Type = _type;
        lineTransform.SetParent(_assemblyParent.transform);

        _assemblyLines.Add(line);
    }

    #endregion
}