using System;
using System.Collections;
using System.Collections.Generic;
using Shooter;
using Shooter.Interface;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
public class Bot : BaseObjectScene,ISetDamage
{
    [SerializeField] private float _hp = 100;
    private bool _isDeath;
    public NavMeshAgent agent;

    private readonly float _timeWait = 3f;
    private List<Vector3> _wayPoints=new List<Vector3>();
    private int _wayCount;
    private float _curTimeout;
    private bool _isTarget;
    private float _StoppingDistance = 5;
    public Transform Target;
    private float _activedistance=50;
    private float _activeAngle=70;
    [Inject]
    private Weapons _weapons;
    [SerializeField]private Ammunition _amun;
    protected void Awake()
    {
        base.Awake();
        _isDeath = false;
        agent = GetComponent<NavMeshAgent>();
       // _weapons = GetTransform.Find("Gun").GetComponent<Weapons>();
    }
	
	private void Start ()
	{
	    GameObject[] tempWayPoints = GameObject.FindGameObjectsWithTag("WayPoints");
	    foreach (var tempWayPoint in tempWayPoints)
	    {
	        _wayPoints.Add(tempWayPoint.transform.position);
            
	    }
	}
	
	
	private void Update ()
	{
	    if (_isDeath || !Target) return;
	    float dis = Vector3.Distance(Position, Target.position);
	    if (dis < _activedistance)
	    {
	        if (Vector3.Angle(GetTransform.forward, Target.position - Position) <= _activeAngle)
	        {
	            if (!CheckBlocked())
	            {
	                _isTarget = true;
                    _weapons.Fire(_amun);
	            }
	        }
	    }
        if (_wayPoints.Count >= 2 && !_isTarget)
        {
            agent.stoppingDistance = 0;
            agent.SetDestination(_wayPoints[_wayCount]);
            if (!agent.hasPath)
            {
                _curTimeout += Time.deltaTime;
                if (_curTimeout > _timeWait)
                {
                    _curTimeout = 0;
                    GenerationWayPoints();
                }
            }
        }
        else if (_wayPoints.Count == 0 || _isTarget)
        {
            agent.stoppingDistance = _StoppingDistance;
            agent.SetDestination(Target.position);
        }
    }

    private bool CheckBlocked()
    {
        RaycastHit hit;
        Debug.DrawLine(Position,Target.position,Color.red);
        if (Physics.Linecast(Position, Target.position, out hit))
        {
            if (hit.transform == Target)
            {
                return false;
            }
        }
        return true;
    }

    private void GenerationWayPoints()
    {
        if (_wayCount < _wayPoints.Count - 1)
        {
            _wayCount++;
        }
        else
        {
            _wayCount = 0;
        }
    }

    public void ApplyDamage(float damage)
    {
        if (_hp > 0)
        {
            _hp -= damage;
        }
        if (_hp <= 0)
        {
            _hp = 0;
            _isDeath = true;
            Main.Instance.GetBotController.RemoveBotToList(this);
            agent.enabled = false;
            foreach (Transform child in GetComponentsInChildren<Transform>())
            {
                child.parent = null;
                Destroy(child.gameObject,10);
                if (!child.gameObject.GetComponent<Rigidbody>())
                {
                    child.gameObject.AddComponent<Rigidbody>();
                }
              
                Destroy(GetGameObject,10);
            }
        }
    }

   
}
