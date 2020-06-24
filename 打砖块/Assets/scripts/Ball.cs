using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float ballspeed ;
    public Rigidbody rb;
    private bool ballinpaly=false;
    public GameObject ball;
	// Use this for initialization
	void Start() {
        rb =GetComponent<Rigidbody>();
        ball = GameObject.Find("qiu");
           }
	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("zhuantou"))
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "gameover")
        {
            Destroy(ball.gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && ballinpaly == false)
        {
            transform.parent = null;
            ballinpaly = true;
            rb.AddForce(new Vector3(45, 45,0)*ballspeed);
        }
  
	}
}
     