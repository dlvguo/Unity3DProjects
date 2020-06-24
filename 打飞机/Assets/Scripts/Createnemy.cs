using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createnemy : MonoBehaviour
{
    public GameObject enemy0prefab;
    public GameObject enemy1prefab;
    public GameObject enemy2prefab;
    public GameObject awardtype1;
    public GameObject awardtype0;

    public static  float enemy0rate = 2f;
    public static  float enemy1rate = 4f;
    public static  float enemy2rate = 7.0f;
    public static  float awardtype0rate = 10f;
    public static  float awardtype1rate = 20f; 
    public float x0pos, x1pos, x2pos,x3pos,x4pos;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("enemy0creat", 2f, enemy0rate);
        InvokeRepeating("enemy1creat", 5f, enemy1rate );
        InvokeRepeating("enemy2creat", 15f, enemy2rate );
        InvokeRepeating("award", 15f, awardtype0rate);
        InvokeRepeating("awardtype1creat", 40f, awardtype1rate);
    }

    // Update is called once per frame
    public void enemy0creat()
    {
        x0pos = Random.Range(-2f, 2.1f);
        Instantiate(enemy0prefab, new Vector3(x0pos, 4.0f, 0), Quaternion.identity);
    }
    public void enemy1creat()
    {
        x1pos = Random.Range(-2.02f, 2.02f);
        Instantiate(enemy1prefab, new Vector3(x1pos, 4.0f, 0), Quaternion.identity);
    }
    public void enemy2creat()
    {
        x2pos = Random.Range(-1.5f, 1.5f);
        Instantiate(enemy2prefab, new Vector3(x2pos, 4.0f, 0), Quaternion.identity);
    }
    public void award()
    {
        x3pos = Random.Range(-2.15f, 2.15f);
        Instantiate(awardtype0, new Vector3(x3pos, 3.5f, 0), Quaternion.identity);
    }
    public void awardtype1creat()
    {
        x4pos = Random.Range(-2.02f, 2.02f);
        Instantiate(awardtype1, new Vector3(x4pos, 3.5f, 0), Quaternion.identity);
    }
}
