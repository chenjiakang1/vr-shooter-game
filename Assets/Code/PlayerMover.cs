using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 2f;  // 玩家移动速度
    public Transform cameraTransform;  // 摄像机变换
    public Animator animator;  // 动画控制器

    [Header("跳跃设置")]
    public float JumpGravity = 500f;  // 跳跃重力
    public float jumpForce = 10f;  // 跳跃初速度
    public float groundCheckDistance = 0.3f;  // 地面检测距离
    private Rigidbody rb;  // 刚体
    private Vector2 inputVector;  // 玩家输入向量
    private bool isGrounded;  // 玩家是否在地面上

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;  // 防止刚体旋转
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();  // 获取移动输入
    }

    void Update()
    {
        // 使用射线检测来判断是否在地面上
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        // 跳跃逻辑
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))  // 如果按下空格并且在地面上
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);  // 给刚体添加向上的速度
        }
    }

    void FixedUpdate()
    {
        // 计算基于摄像机方向的移动
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 direction = forward * inputVector.y + right * inputVector.x;
        direction.Normalize();

        // 使用刚体 velocity 控制移动，避免墙角挤偏
        Vector3 velocity = direction * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);  // 控制刚体的速度

        // 动画控制（只使用 Speed）
        if (animator != null)
        {
            animator.SetFloat("Speed", direction.magnitude);
        }
    }
}



