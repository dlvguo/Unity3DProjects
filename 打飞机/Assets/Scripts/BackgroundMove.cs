using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {
    public float moveSpeed=8.0f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        Vector3 position = transform.position;
        if (position.y <= -8.52f)
            transform.position = new Vector3(position.x, position.y + 8.52f*2, 0);
	}
}
