using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int count = PlayerPrefs.GetInt("tmpCount", 0);
        gameObject.GetComponent<TextMeshProUGUI>().text = count.ToString();
        count++;
        PlayerPrefs.SetInt("tmpCount", count);
    }
    
}
