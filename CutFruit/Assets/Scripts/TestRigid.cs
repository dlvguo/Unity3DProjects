using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRigid : MonoBehaviour {
    public Rigidbody rigidbody;
    public float radious = 5f;
    public float power = 10f;
	// Use this for initialization
	void Start () {
        var explosionPos = transform.position;
        if (rigidbody)
        {
            rigidbody.AddForceAtPosition(Vector3.down * 10f, transform.position);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
