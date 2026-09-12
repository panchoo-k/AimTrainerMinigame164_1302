using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnfootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;
    private TargetShooter shooter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.Onfoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => motor.Jump();

        shooter = GetComponent<TargetShooter>();

        onFoot.Fire.performed += ctx => shooter.Shoot();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>()); 
    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
