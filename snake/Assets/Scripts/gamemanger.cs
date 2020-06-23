using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanger : MonoBehaviour
{

    public static List<Vector3> Q = new List<Vector3>();
    public static int bodynum = 0;
    public GameObject food;
    public GameObject d;
    public Text score;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("creatfood", 0f, 5f);
    }
    void creatfood()
    {
        float x, y;
        x = Random.Range(-45f, 45f);
        y = Random.Range(-18.5f, 18.5f);
        d = Instantiate(food, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
        Destroy(d, 15f);
    }
    // Update is called once per frame
    void Update()
    {
        score.text = "Score :" + (bodynum * 10).ToString();

    }
}
