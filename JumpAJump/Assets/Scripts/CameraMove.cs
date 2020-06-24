using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public Transform pointPos;
    public Vector3 offect;
    public float speed=1f;
    public Transform Ground;
    public Vector3 offectG;
    // Use this for initialization
    private void Awake()
    {
      
    }
    void Start () {       
        offect = transform.position-pointPos.position;
        offectG = Ground.position-transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position - pointPos.position != offect)
        {
            transform.position = Vector3.Lerp(transform.position, offect + pointPos.position, Time.deltaTime * speed);
            Ground.position = new Vector3(transform.position.x+offectG.x,Ground.position.y,transform.position.z+offectG.z);
        }   
	}
}
