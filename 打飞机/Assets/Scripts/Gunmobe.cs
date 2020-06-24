using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunmobe : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.up * speed * Time.deltaTime);
        if (transform.position.y > 4.2)
            Destroy(gameObject);
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Enemy")
        {
            other.gameObject.SendMessage("BeHit");
            Destroy(gameObject);
        }
    }
}
