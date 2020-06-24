using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject []GObject;
    public bool isIns = false;
    // Use this for initialization
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (isIns)
            return;
        var rand = Random.Range(0, 2);
        var srand = Random.Range(0, GObject.Length);
        var cubeObj = Instantiate(GObject[srand], new Vector3(transform.position.x + (rand == 0 ? Random.Range(2f, 4f) : 0), transform.position.y, transform.position.z + (rand == 0 ? 0 : Random.Range(2f, 4f))), Quaternion.identity) as GameObject;
        collision.gameObject.GetComponent<Player>().PPos = cubeObj.transform;
        collision.gameObject.GetComponent<Player>().Look();
        isIns = true;
    }
}
