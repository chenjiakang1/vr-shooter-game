using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 2f;
    public float jumpForce = 20f;                // 跳跃力度
    public Transform cameraTransform;
    public Animator animator;

    private Rigidbody rb;
    private Vector2 inputVector;
    private bool isGrounded = true;             // 是否在地面
    private bool jumpRequested = false;         // 是否请求跳跃

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // 限制刚体旋转，避免因碰撞而旋转角色
    }

    // 接收移动输入
    public void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    // 接收跳跃输入
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) // 确保只在按下瞬间跳跃
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 给刚体一个向上的力
            isGrounded = false; // 设置为跳跃状态
        }
    }

    // 在 FixedUpdate 中处理物理计算
    void FixedUpdate()
    {
        // 计算基于摄像机方向的移动
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;  // 不考虑y轴的影响
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 direction = forward * inputVector.y + right * inputVector.x;
        direction.Normalize();

        // 使用刚体的 velocity 控制移动，避免墙角挤偏
        Vector3 velocity = direction * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);  // 保持y轴速度，避免跳跃时改变速度

        // 动画控制
        if (animator != null)
        {
            animator.SetFloat("Speed", direction.magnitude);
            animator.SetBool("IsGrounded", isGrounded);  // 给跳跃动画用
        }
    }

    // 碰撞检测，判断是否接触地面
    private void OnCollisionEnter(Collision collision)
    {
        // 简单判断：只要碰到地面（标签为 Ground），就认为落地了
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
