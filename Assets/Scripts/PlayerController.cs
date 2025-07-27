using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction jumpAction;
    Rigidbody playerBody;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 0.1f;
 
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");        
    }

    
    void Update()
    {
        MovePlayer();

        if (jumpAction.IsPressed())
        {
            transform.position += new Vector3(0f, jumpPower, 0f);
        }

    }

    void MovePlayer()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(moveValue.x, 0f, moveValue.y) * moveSpeed * Time.deltaTime;
        
    }

    


}
