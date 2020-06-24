using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {
    public button a;
    public button b;
	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(transform.parent.gameObject);
            a.gameObject.SetActive(true);
            b.gameObject.SetActive(true);
        }
          
    }
}
