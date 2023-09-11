using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

	public UnityEvent OnMoveEvent;

    public TMPro.TextMeshProUGUI text;

    void Start() {
		if (OnMoveEvent == null)
			OnMoveEvent = new UnityEvent();
    }

    // void Update() {
    //     if (Time.time >= lastTimePerformed + 0.5f) horizontalMove = 0;
    //     controller.Move(horizontalMove * Time.deltaTime, jump);
    //     jump = false;
    // }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public void Jump(InputAction.CallbackContext context) {
        if (context.started) {
            jump = true;
            animator.SetBool("IsJumping", true);
            OnMoveEvent.Invoke();
        }
    }

    public void MoveXAxis(InputAction.CallbackContext context) {
        horizontalMove = context.ReadValue<Vector2>().x * runSpeed;
        if (Mathf.Abs(horizontalMove) > 0) OnMoveEvent.Invoke();
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    public void OnLanding() {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", false);
    }

    public void OnFalling() {
        animator.SetBool("IsFalling", true);
    }

    public float GetSpeed() {
        return horizontalMove;
    }
}
