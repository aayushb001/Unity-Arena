using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Animator characterAnimator;
    private CharacterController characterController;

    [SerializeField] //Can be edited in the inspector
    private float moveSpeed = 0.1f;
    [SerializeField]
    private float rotationRate = 150f;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
        characterAnimator = GetComponentInChildren<Animator>();
    }

    void Update () {
        float moveAxis = Input.GetAxis("Vertical");
        float turnAxis = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * moveAxis * moveSpeed);
        transform.Rotate(0, turnAxis * rotationRate * Time.deltaTime, 0);
        var movement = new Vector3(turnAxis, 0, moveAxis);   
        characterAnimator.SetFloat("Speed", movement.magnitude);
    }
    
}
