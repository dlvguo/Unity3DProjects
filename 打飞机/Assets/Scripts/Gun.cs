using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float rate = 0.3f;
    public float nowrate;
    public GameObject bullet;
	// Use this for initialization
    void Start()
    {
        openfire();
    }
	public void fire()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    public void openfire()
    {   
        InvokeRepeating("fire", 1, rate);
    }
    public void closefire()
    {
        CancelInvoke();
    }
}
