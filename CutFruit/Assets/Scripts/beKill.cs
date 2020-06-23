using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beKill : MonoBehaviour {
    public bool isKilled = false;
    public GameObject[] gameObjects;
    public void OnKill()
    {
        if(!isKilled)
        foreach (var item in gameObjects)
        {
            var ins = Instantiate(item, transform.position, Random.rotation) as GameObject;
            var insRig = ins.GetComponent<Rigidbody>();
            insRig.velocity = Random.onUnitSphere + Vector3.up;
            insRig.AddTorque(Random.onUnitSphere * 1.5f, ForceMode.Impulse);
        }
    }
}
