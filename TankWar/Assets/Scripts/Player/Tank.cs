using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    public enum CtrlType
    {
        none,
        player,
        couputer
    }
    public CtrlType ctrlType = CtrlType.player;
    //轮子
    private Transform wheels;
    //履带
    private Transform tracks;
    //轮轴
    public List<AxleInfo> axleInfos;
    //马力/最大马力
    private float motor = 0;
    public float maxMotorTorque = 100;
    //制动//最大制动
    private float brakeTorque = 0;
    public float maxBrakeTorque = 100;
    //转向角//最大转向角
    private float steering = 0;
    public float maxSteeringAngle = 100;
    //马达音效果
    public AudioSource motorAudioSource;
    public AudioClip motorClip;
    //打炮效果
    public AudioSource shootAudioSource;
    public AudioClip shootClip;
    //炮台
    public Transform BulletSend;
    public Transform turret;
    public GameObject Bullet;
    private bool isSend = false;
    public float sendTime = 1f;
    //坦克血量
    public float hp = 100;
    public float maxHp = 100;
    public Slider hpSlider;
    //AI
    private AI ai;    
    // Use this for initialization
    void Start()
    {
        //获取轮子
        wheels = transform.Find("Wheels");
        //获取履带
        tracks = transform.Find("tracks");
        motorAudioSource = gameObject.AddComponent<AudioSource>();
        motorAudioSource.spatialBlend = 1;
        shootAudioSource = gameObject.AddComponent<AudioSource>();
        shootAudioSource.spatialBlend = 1;
        shootAudioSource.loop = false;
        shootAudioSource.clip = shootClip;
        isSend = false;
        sendTime = 1f;
        if (ctrlType == CtrlType.couputer)
        {
            ai = gameObject.AddComponent<AI>();
            ai.tank = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayCtrl();
        MotorSound();
        foreach (var axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            if (axleInfos[1] != null&&axleInfo==axleInfos[1])
            {
                WheelsRotation(axleInfos[1].leftWheel);
                TrackMove();
            }
            if (true)
            {
                axleInfo.leftWheel.brakeTorque = brakeTorque;
                axleInfo.rightWheel.brakeTorque = brakeTorque;
            }
        }
    }
    //玩家控制
    public void PlayCtrl()
    {
        if (ctrlType != CtrlType.player)
            return;
        hpSlider.value = hp / maxHp;
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        brakeTorque = 0;
        foreach (var axleInfo in axleInfos)
        {
            if (axleInfo.leftWheel.rpm > 5 && motor < 0 || axleInfo.leftWheel.rpm < -5 && motor > 0)
            {
                brakeTorque = maxBrakeTorque;
                break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isSend)
        {
            SendBullet();
            shootAudioSource.Play();
        }
        turret.transform.eulerAngles += new Vector3(0f, Input.GetAxisRaw("q"), 0f);
        turret.transform.eulerAngles += new Vector3(0f, -Input.GetAxisRaw("e"), 0f);
    }
    //轮子旋转
    public void WheelsRotation(WheelCollider collider)
    {
        if (wheels == null)
            return;
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        foreach (Transform wheel in wheels)
        {
            wheel.rotation = rotation;
        }
    }
    //履带gundogn
    public void TrackMove()
    {
        if (tracks == null)
            return;
        float offect = 0;
        if (wheels.GetChild(0) != null)
            offect = wheels.GetChild(0).localEulerAngles.x / 90f;
        foreach(Transform track in tracks)
        {
            MeshRenderer mr = track.gameObject.GetComponent<MeshRenderer>();
            if (!mr)
                continue;
            Material mtl = mr.material;
            mtl.mainTextureOffset = new Vector2(0, offect);
        }
    }
    //马达音效
    public void MotorSound()
    {
        if (motor != 0 && !motorAudioSource.isPlaying)
        {
            motorAudioSource.loop = true;
            motorAudioSource.clip = motorClip;
            motorAudioSource.Play();
        }
        else if (motor == 0)
        {
            motorAudioSource.Pause();
        }
    }
    //发射炮弹
    public void SendBullet()
    {
        isSend = true;
        var bullet= Instantiate(Bullet, BulletSend.gameObject.transform.position, BulletSend.gameObject.transform.rotation) as GameObject;
        bullet.GetComponent<Bullet>().name = ctrlType.ToString();
        Invoke("TimeCount", sendTime);
    }
    //子弹时间计数
    private void TimeCount()
    {
        isSend = false;
    }
    //坦克被击中
    public void BeAttacked(float att,string name)
    {
        if (hp <= 0)
            return;
        if (hp > 0)
        {
            hp -= att;
        }
        else
        {
            ctrlType = CtrlType.none;
        }
    }
}

