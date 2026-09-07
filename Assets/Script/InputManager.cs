using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnfootActions onfoot;

    private PlayerMotor motor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        onfoot = playerInput.Onfoot;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void FixUpdate()
    {
        motor.ProcessMove(onfoot.Movement.ReadValue<Vector2>()); 
    }
    private void OnEnable()
    {
        onfoot.Enable();
    }
    private void OnDisable()
    {
        onfoot.Disable();
    }
}
