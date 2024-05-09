using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;
    public bool isSprinting;

    // Start is called before the first frame update
    void Awake()
    {
        
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        
        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.SprintStart.performed += ctx => SprintPressed();
        onFoot.SprintFinish.performed += ctx => SprintReleased();
    }

    void FixedUpdate()
    {

        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }

    private void SprintPressed()
    {
        isSprinting = true;
    }

    private void SprintReleased()
    {
        isSprinting = false;
    }

    
}
