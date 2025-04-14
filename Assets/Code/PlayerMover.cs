using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 2f;
    public Transform cameraTransform;
    public Animator animator;

    [Header("跳跃设置")]
    public float JumpGravity = 500f;
    public float jumpForce = 10f;
    public float groundCheckDistance = 0.1f;

    private Rigidbody rb;
    private Vector2 inputVector;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    void Update()
    {
        // 地面检测
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance + 0.1f);

        // 设置动画参数 IsGrounded
        if (animator != null)
        {
            animator.SetBool("IsGrounded", isGrounded);
        }

        // 跳跃
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);

            // 设置动画触发器 Jump
            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }
    }

    void FixedUpdate()
    {
        // 摄像机方向移动
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 direction = forward * inputVector.y + right * inputVector.x;
        direction.Normalize();

        // 移动速度设置
        Vector3 velocity = direction * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        // 设置动画 Speed（控制 Idle / Run）
        if (animator != null)
        {
            animator.SetFloat("Speed", direction.magnitude);
        }
    }
}


