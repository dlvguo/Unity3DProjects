using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Onclick  :MonoBehaviour{

	public void Onrestart()
    {      
        SceneManager.LoadScene(0);
    }
}
