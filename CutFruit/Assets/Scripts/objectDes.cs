using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDes : MonoBehaviour {

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
