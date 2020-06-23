using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject bobm;
    private float time = 1f;
    private float timer;
    public bool isPause = false;
    // Use this for initialization
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause)
            return;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            FireOpen();
        }
    }
    void FireOpen()
    {
        time = timer;
        spawn(false);
        if (Random.Range(0, 10) < 3)
            spawn(true);
    }
    void spawn(bool isBobm)
    {
        float x = Random.Range(-2.3f, 2.3f);
        float z = 8f;
        GameObject ins;
        if (isBobm)
            ins = Instantiate(bobm, transform.position + new Vector3(x, 0f, z), Random.rotation) as GameObject;
        else
            ins = Instantiate(fruits[Random.Range(0, fruits.Length)], transform.position + new Vector3(x, 0f, z), Random.rotation) as GameObject;
        float power = Random.Range(1.5f, 1.8f) * -Physics.gravity.y * 0.3f;
        var direction = new Vector3(-x * 0.05f * Random.Range(0.3f, 0.8f), 1, 0f);
        ins.GetComponent<Rigidbody>().velocity = direction * power;
        ins.GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * 0.1f, ForceMode.Impulse);

    }
}
