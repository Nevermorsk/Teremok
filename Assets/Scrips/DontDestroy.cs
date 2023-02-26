using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static int counter;
    public static int money;
    private static TextMeshProUGUI text;

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        text = GameObject.FindGameObjectWithTag("money").GetComponent<TextMeshProUGUI>();
    }
    
    public void Update()
    {
        text.text = money + "�";
    }
}
