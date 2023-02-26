using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static int counter;
    public static int money;
    public static int day = 2;

    public static Dictionary<string, bool> byedItems = new Dictionary<string, bool>{
        { "apples", false },
        { "sgushenka", false },
        { "salomon", false },
        { "nutella", false },
        { "starberry", true },
        { "sugar", true },
        { "upgrade", false }
};
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
