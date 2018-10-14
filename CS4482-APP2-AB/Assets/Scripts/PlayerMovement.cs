using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Animator characterAnimator;
    private CharacterController characterController;

    [SerializeField] //Can be edited in the inspector
    private float moveSpeed = 350f;
    private float rotationSpeed = 5f;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
        characterAnimator = GetComponentInChildren<Animator>();
    }

    void Update () {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);

        characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);
        characterAnimator.SetFloat("Speed", movement.magnitude);

        if (movement.magnitude > 0) {
            Quaternion facingDirection = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, facingDirection, Time.deltaTime * rotationSpeed);
        }
    }
}
