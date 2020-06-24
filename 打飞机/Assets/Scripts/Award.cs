using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour {
    public int type;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -4.5f)
            Destroy(gameObject);
	}
}
