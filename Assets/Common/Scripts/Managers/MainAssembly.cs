using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainAssembly
{
    #region const

    private const float Velocity = 0.5f;

    #endregion

    #region attributes

    private readonly AssemblyTypeComponent.AssemblyType[] _goodsNames =
    {
        AssemblyTypeComponent.AssemblyType.Triangle,
        AssemblyTypeComponent.AssemblyType.Square,
        AssemblyTypeComponent.AssemblyType.Circle
    };

    private readonly GameObject _assembly;
    private readonly GameObject _assemblyParent;
    private readonly List<GameObject> _assemblyLines;

    #endregion

    #region properties

    private Vector2 AssemblySize { get; set; }

    #endregion

    #region construction

    public MainAssembly()
    {
        _assembly = ResourceManager.LoadAsset<GameObject>("Prefabs/assembly_main");

        if (_assembly == null)
            return;

        _assemblyParent = new GameObject();
        _assemblyParent.name = "assembly";

        _assemblyLines = new List<GameObject>();

        Bounds assemblyBounds = _assembly.GetComponent<SpriteRenderer>() != null
            ? _assembly.GetComponent<SpriteRenderer>().bounds
            : default;

        if (assemblyBounds == default)
            return;

        AssemblySize = new Vector2(assemblyBounds.size.x, assemblyBounds.size.y);

        CreteAssemblyLines();
    }

    #endregion

    #region public methods

    public void MoveAssemblyLines()
    {
        foreach (Transform lineTransform in _assemblyLines.Select(line => line.transform))
        {
            lineTransform.Translate(Time.deltaTime * Velocity * Vector2.right);

            if (lineTransform.position.x > GameManager.ScreenBound.x + AssemblySize.x / 2)
            {
                lineTransform.position = new Vector2(-GameManager.ScreenBound.x - AssemblySize.x / 1.5f,
                    -GameManager.ScreenBound.y + AssemblySize.y / 2);
                SpawnGood(lineTransform);
            }
        }
    }

    #endregion

    #region service methods

    private void CreteAssemblyLines()
    {
        int linesNeeded = (int) Mathf.Ceil(GameManager.ScreenBound.x * 2 / AssemblySize.x);

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

        lineTransform.position = new Vector2(-GameManager.ScreenBound.x + AssemblySize.x * number,
            -GameManager.ScreenBound.y + AssemblySize.y / 2);
        lineTransform.SetParent(_assemblyParent.transform);
        SpawnGood(line.transform);

        _assemblyLines.Add(line);
    }

    private void SpawnGood(Transform assemblyLineTransform)
    {
        AssemblyTypeComponent.AssemblyType goodType = _goodsNames[Random.Range(0, 3)];
        GameObject goodPrefab = ResourceManager.LoadAsset<GameObject>($"Prefabs/{goodType.ToString().ToLower()}");
        GameObject good = Object.Instantiate(goodPrefab, assemblyLineTransform, true);
        Vector3 linePosition = assemblyLineTransform.position;
        good.transform.position = new Vector3(linePosition.x, linePosition.y, linePosition.z - 2);
        good.AddComponent<AssemblyTypeComponent>().Type = goodType;
    }

    #endregion
}