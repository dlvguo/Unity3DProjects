using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed=1f;
    public GameObject explode;
    public string name=null;
    public float maxLiftTime = 2f;
    private float instanceTime = 0;    
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, maxLiftTime);
        instanceTime = 0f;
    }	
	// Update is called once per frame
	void Update () {        
        transform.Translate(Vector3.forward * speed);
        instanceTime += Time.deltaTime;        
	}
    void OnCollisionEnter(Collision collider)
    {
        var exp= Instantiate(explode, transform.position, Quaternion.identity) as GameObject;
        Destroy(this.gameObject, maxLiftTime);
        Destroy(exp, maxLiftTime);
        var tank = collider.gameObject.GetComponent<Tank>();
        if (tank != null)
        {
            var att = GetAtt();
            tank.BeAttacked(att,name);
        }
    }
    private float GetAtt()
    {
        float att = 100 - instanceTime * 40;
        return att < 1 ? 1 : att;
    }
}
