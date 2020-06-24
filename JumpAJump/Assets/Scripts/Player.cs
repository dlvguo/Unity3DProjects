using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private float _startTime;
    private Transform NowPos;
    private bool isOver = false;
    public GameObject partical;
    public Button ReStart;
    public Slider force;
    public float Factor;
    public Transform PPos;
    public new AudioSource audio;
    private bool isJump;
    ParticleSystem p;
    // Use this for initialization
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        NowPos = this.transform;
        p = new ParticleSystem();
        ReStart.gameObject.SetActive(false);
        partical.gameObject.SetActive(false);
        force.gameObject.SetActive(false);
        isJump = false;       
    }

    // Update is called once per frame
    void Update()
    {
        if (isJump)
        {
            force.value += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _startTime = Time.time;
            if (!isOver)
            {
                force.gameObject.SetActive(true);
                partical.gameObject.SetActive(true);
                audio.Play();
            }
            force.value = 0;
        }
        if (Input.GetMouseButton(0))
        {
            force.value += 1.75f*Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0))
        {
            force.gameObject.SetActive(false);
            partical.gameObject.SetActive(false);
            var time = Time.time - _startTime;
            if (!isOver)
                OnJump(time);
        }
    }
    void OnJump(float time)
    {
        var dir = (new Vector3(PPos.position.x - transform.position.x, 0, PPos.position.z - transform.position.z)).normalized;
        time = Mathf.Clamp(time, 0.25f, 0.75f);
        rigidbody.AddForce(new Vector3(dir.x, 1, dir.z) * time * Factor, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            NowPos = collision.transform;
            ScoreManger.Score++;
        }
        else
        {
            ReStart.gameObject.SetActive(true);
            isOver = true;
        }
    }
    public void Look()
    {
        if (PPos.position.x - NowPos.position.x == 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }

    }
}
