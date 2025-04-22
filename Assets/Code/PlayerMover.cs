using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [Header("移动设置")]
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> b783fc37acf99b0cc509bd5a2da119912d4f0ad2
    public float moveSpeed = 2f;
    public Transform cameraTransform;
    public Animator animator;

<<<<<<< HEAD
    [Header("跳跃设置")]
    public float JumpGravity = 500f;
    public float jumpForce = 10f;
    public float groundCheckDistance = 0.1f;

    private Rigidbody rb;
    private Vector2 inputVector;
    private bool isGrounded;
=======
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
>>>>>>> huyufei
=======
    private Rigidbody rb;
    private Vector2 inputVector;
>>>>>>> b783fc37acf99b0cc509bd5a2da119912d4f0ad2

    void Start()
    {
        rb = GetComponent<Rigidbody>();
<<<<<<< HEAD
<<<<<<< HEAD
        rb.freezeRotation = true;
=======
        rb.freezeRotation = true;  // 防止刚体旋转
>>>>>>> huyufei
=======

        // 限制刚体旋转，避免因碰撞而旋转角色
        rb.freezeRotation = true;
>>>>>>> b783fc37acf99b0cc509bd5a2da119912d4f0ad2
    }

    public void OnMove(InputAction.CallbackContext context)
    {
<<<<<<< HEAD
        inputVector = context.ReadValue<Vector2>();  // 获取移动输入
    }

    void Update()
    {
<<<<<<< HEAD
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
=======
        // 使用射线检测来判断是否在地面上
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        // 跳跃逻辑
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))  // 如果按下空格并且在地面上
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);  // 给刚体添加向上的速度
>>>>>>> huyufei
        }
=======
        inputVector = context.ReadValue<Vector2>();
>>>>>>> b783fc37acf99b0cc509bd5a2da119912d4f0ad2
    }

    void FixedUpdate()
    {
<<<<<<< HEAD
        // 摄像机方向移动
=======
        // 计算基于摄像机方向的移动
>>>>>>> b783fc37acf99b0cc509bd5a2da119912d4f0ad2
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 direction = forward * inputVector.y + right * inputVector.x;
        direction.Normalize();

<<<<<<< HEAD
<<<<<<< HEAD
        // 移动速度设置
        Vector3 velocity = direction * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        // 设置动画 Speed（控制 Idle / Run）
=======
        // 使用刚体 velocity 控制移动，避免墙角挤偏
        Vector3 velocity = direction * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);  // 控制刚体的速度

        // 动画控制（只使用 Speed）
>>>>>>> huyufei
=======
        // 使用刚体 velocity 控制移动，避免墙角挤偏
        Vector3 velocity = direction * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        // 动画控制（只使用 Speed）
>>>>>>> b783fc37acf99b0cc509bd5a2da119912d4f0ad2
        if (animator != null)
        {
            animator.SetFloat("Speed", direction.magnitude);
        }
    }
}
<<<<<<< HEAD


<<<<<<< HEAD
=======

>>>>>>> huyufei
=======
>>>>>>> b783fc37acf99b0cc509bd5a2da119912d4f0ad2
