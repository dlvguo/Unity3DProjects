using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public Camera c;
    private Vector3 offect;
    public float moveSpeed=5f;
    public float cmoveSpeed = 1f;    
    public float rotateSpeed = 1f;
    public Transform pointPos;
    private void Awake()
    {
        c = this.GetComponent<Camera>();    
    }
    // Use this for initialization
    void Start () {
        offect = transform.position - pointPos.position;        
	}
	
	// Update is called once per frame
	void Update () {        
        c.fieldOfView += -Input.GetAxisRaw("Mouse ScrollWheel")*moveSpeed;
        if (Input.GetMouseButton(1))
        {            
            var xaxis = Input.GetAxisRaw("Mouse X");
            var yaxis = Input.GetAxisRaw("Mouse Y");
            transform.RotateAround(pointPos.position,Vector3.up,xaxis);
            transform.RotateAround(pointPos.position, transform.right, yaxis);
            offect = transform.position - pointPos.position;
        }
        if (transform.position - pointPos.position != offect)
        {
            transform.position = Vector3.Lerp(transform.position, pointPos.position+offect, Time.deltaTime * cmoveSpeed);
        }        
	}
}
