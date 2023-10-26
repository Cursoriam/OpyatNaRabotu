using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SquareManager : MonoBehaviour
{
    [SerializeField] private GameObject _product;


    private List<GameObject> _products;
    [SerializeField] private float _productVelocity = 0.5f;
    [SerializeField] private float _spawnCooldown = 2.0f;
    private float _timeElapsed = 0.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        _products = new List<GameObject>();

        GameObject square = Instantiate(_product);
        int mockY = -4;
        square.transform.position = new Vector3(-UIManager.ScreenBound.x - 2, mockY, -1);
        _products.Add(square);
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;

        //Спавн квадратов
        if (_timeElapsed > _spawnCooldown)
        {
            _timeElapsed = 0.0f;
            
            GameObject square = Instantiate(_product);
            int mockY = -4;
            square.transform.position = new Vector3(-UIManager.ScreenBound.x - 2, mockY, -1);
            _products.Add(square);
        }
        
        //Движ квадратов
        foreach (GameObject product in _products)
        {
            product.transform.Translate(Time.deltaTime * _productVelocity * Vector2.right);
        }
        
        //Удоление квадратов
        GameObject productToDelete = _products.FirstOrDefault();
        
        if (productToDelete != null && productToDelete.transform.position.x > UIManager.ScreenBound.x)
        {
            _products.RemoveAt(0);
            Destroy(productToDelete);
        }
    }
}
