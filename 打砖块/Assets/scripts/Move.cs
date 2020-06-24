using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour {
    public float xpos,ypos,zpos;
    public float movespeed;
    public float value;
    // Use this for initialization
	void Start () {
        xpos = transform.position.x;
        ypos = transform.position.y;
        zpos = transform.position.z;	}
	
	// Update is called once per frame
	void Update () {
        xpos = Input.GetAxisRaw("Horizontal")*movespeed+transform.position.x;
        xpos=Mathf.Clamp(xpos, -value, value);
        transform.position = new Vector3(xpos, ypos, zpos);

	}
}
