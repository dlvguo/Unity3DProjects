using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {   
    public Tank tank;
    public enum Staus
    {
        Patrol,
        Attack
    }
    private Staus staus = Staus.Patrol;

    //锁定坦克
    private GameObject target;
    //视野范围
    private float sightDsitance = 30f;
    //上一次搜寻时间
    private float lastSearchTargetTime = 0;
    //搜寻间隔
    private float searchTargetIntercal = 3f;


    // Use this for initialization
    void Start () {
		
	}
    // Update is called once per frame
    void Update()
    {
        if (tank.ctrlType != Tank.CtrlType.couputer)
            return;
        if (staus == Staus.Patrol)
        {
            PatrolStart();
        }
        else if (staus == Staus.Attack)
        {
            AttackStart();
        }
        TargetUpdate();
    }
    //搜寻目标
    void TargetUpdate()
    {
        float interval = Time.time - lastSearchTargetTime;
        if (interval < lastSearchTargetTime)
            return;
        lastSearchTargetTime = Time.time;
        if (target != null)
            HasTarget();
        else
            NoTarget();
    }
    public void ChangeStaus(Staus staus)
    {
        if (staus == Staus.Patrol)
        {
            PatrolStart();
        }
        else if (staus == Staus.Attack)
        {
            AttackStart();
        }
    }
    //巡逻开始
    public void PatrolStart()
    {

    }
    //攻击开始
    public void AttackStart()
    {

    }
    //巡逻中
    public void PatrotUpdate()
    {

    }
    //攻击中
    public void AttackUpdate()
    {

    }
    //已有目标的情况，判断是否丢失目标
    void HasTarget()
    {
        Tank targetTank = target.GetComponent<Tank>();
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position;
        if (targetTank.ctrlType == Tank.CtrlType.none)
        {
            Debug.Log("目标死亡");
            target = null;
        }
        else if (Vector3.Distance(pos, targetPos) > sightDsitance)
        {
            Debug.Log("距离过远，丢失目标");
            target = null;
        }
    }
    //没有目标
    void NoTarget()
    {
        float minHp = float.MaxValue;
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Tank");
        for (int i = 0; i < targets.Length; i++)
        {
            Tank tank = targets[i].GetComponent<Tank>();
            if (!tank|| targets[i] == gameObject||tank.ctrlType==Tank.CtrlType.none)
                continue;
            Vector3 pos = transform.position;
            Vector3 targetPos = targets[i].transform.position;
            if (Vector3.Distance(pos, targetPos) > sightDsitance)
                continue;
            if (minHp > tank.hp)
                target = tank.gameObject;
        }
        if (target != null)
            Debug.Log("获取目标" + target.name);
    }
}
