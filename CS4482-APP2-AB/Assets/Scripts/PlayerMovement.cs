using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Animator characterAnimator;

    [SerializeField] //Can be edited in the inspector
    private float moveSpeed = 0.1f;
    [SerializeField]
    private float strafeSpeed = 0.15f;
    [SerializeField]
    private float rotationRate = 150f;

    private void Awake() {
        characterAnimator = GetComponentInChildren<Animator>();
    }

    void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 1 * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -1 * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1 * rotationRate * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1 * rotationRate * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * 1 * strafeSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.right * 1 * strafeSpeed);
        }
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            characterAnimator.SetFloat("Speed", new Vector3(1, 0, 1).magnitude);
        }
        else
        {
            characterAnimator.SetFloat("Speed", new Vector3(0, 0, 0).magnitude);
        }     
        
    }
    
}
