using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour {
    // Use this for initialization
    public int type;
	void Start () {
        type = gamemanger.bodynum;
        gamemanger.Q.Add(transform.position);
        InvokeRepeating("move", 0.5f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    void move()
    {
        transform.position = gamemanger.Q[type - 1];
        gamemanger.Q[type] = transform.position;

    }
}
