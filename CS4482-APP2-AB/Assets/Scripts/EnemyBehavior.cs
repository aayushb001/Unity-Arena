using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public GameObject itCapsule;
    public float enemyMovementSpeed;
    public float stoppingDistanceFromPlayer;
    public float retreatDistanceFromPlayer;
    public Transform player;
    float previous_x;
    float previous_z;
    private Animator characterAnimator;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        previous_x = transform.position.x;
        previous_z = transform.position.z;
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

        //if (!Manager.itState)
        //{
            if (Vector3.Distance(transform.position, player.position) > stoppingDistanceFromPlayer)
             {
                 transform.position = Vector3.MoveTowards(transform.position, player.position, enemyMovementSpeed * Time.deltaTime);
                 transform.LookAt(player.transform);
             }
             else if (Vector3.Distance(transform.position, player.position) < stoppingDistanceFromPlayer && Vector3.Distance(transform.position, player.position) > retreatDistanceFromPlayer)
             {
                 transform.position = this.transform.position;
                 transform.LookAt(player.transform);
             }
             else if (Vector3.Distance(transform.position, player.position) < retreatDistanceFromPlayer)
             {
                 transform.position = Vector3.MoveTowards(transform.position, player.position, -enemyMovementSpeed * Time.deltaTime);
                 transform.LookAt(player.transform);
             }
             
        //}
       /* if (Manager.itState)
        {
            if (Vector3.Distance(transform.position, player.position) < retreatDistanceFromPlayer)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, -enemyMovementSpeed * Time.deltaTime);
                //Look away
                transform.rotation = Quaternion.LookRotation(transform.position - player.position);
            }
            else if (Vector3.Distance(transform.position, player.position) >= retreatDistanceFromPlayer)
            {
                // IMPLEMENT RANDOM MOVEMENT
            }
        }*/
        //Select run animation or idle animation based on position change
        if (previous_x != transform.position.x || previous_z != transform.position.z)
        {
            characterAnimator.SetFloat("Speed", 1);
        }
        else {
            characterAnimator.SetFloat("Speed", 0);
        }
        previous_x = transform.position.x;
        previous_z = transform.position.z;
    }
}
