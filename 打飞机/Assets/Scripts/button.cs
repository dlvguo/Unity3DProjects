using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class button : MonoBehaviour
{
    public enum type
    {
        stop,
        con,
        restart,
        quit
    }

    public type choic;

    public Button Stop;
    public button Continue;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        if (choic == type.stop)
        {
            Time.timeScale = 0;
            Continue.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (choic == type.restart)
        {
            Mangage.score = 0;
            SceneManager.LoadScene("StartSense");
        }
        else if (choic == type.quit)
            Application.Quit();
        else
        {
            Time.timeScale = 1;
            Stop.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
   
}
