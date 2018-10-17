using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {
    public GameObject itCapsule;
    public float enemyMovementSpeed;
    public float enemyFleeSpeed;
    public float stoppingDistanceFromPlayer;
    public float retreatDistanceFromPlayer;
    public float runDistanceFromPlayer;
    public GameObject g0;
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject g4;
    public GameObject g5;
    public GameObject g6;
    public GameObject g7;
    public GameObject g8;
    GameObject[] gos;
    public Transform player;
    private Animator characterAnimator;
    public Rigidbody rb;
    private GameObject randomObj;
    private int randNum;
    NavMeshAgent _navMeshAgent;
    private bool cFlag;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cFlag = false;
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null) {
            Debug.Log("Nav mesh agent component is not attached to this object.");
        }
        gos = new GameObject[] { g0, g1, g3, g4, g5, g6, g7, g8 };
        randomObj = g4;
    }

    private void Awake()
    {
        characterAnimator = GetComponentInChildren<Animator>();        
    }

    void Update () {
        
        if (!Manager.itState)
        {
            itCapsule.SetActive(true);
        }
        else
        {
            itCapsule.SetActive(false);
        }
        
        if (!Manager.itState)
        {
            if (Vector3.Distance(transform.position, player.position) > stoppingDistanceFromPlayer)
            {
                _navMeshAgent.SetDestination(player.transform.position);
            }
            cFlag = false;
        }
        if (Manager.itState)
        {
            if (cFlag == false) {
                cFlag = true;
                randNum = Random.Range(0, 9);
                randomObj = gos[randNum];
            }

            if (transform.position.x == randomObj.transform.position.x && transform.position.z == randomObj.transform.position.z)
            {
                randNum = Random.Range(0, 9);
                randomObj = gos[randNum];
            }            
            _navMeshAgent.SetDestination(randomObj.transform.position);
        }
        float velFactor = 0;

        if (Manager.itState)
        {
            velFactor = 100000000;
        }
        else {
            velFactor = 1000;
        }

        characterAnimator.SetFloat("Speed", rb.velocity.magnitude * velFactor);
        
    }
}
