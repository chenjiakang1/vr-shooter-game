using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("灵敏度")]
    public float mouseSensitivity = 100f;

    [Header("角色根节点（水平旋转）")]
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 隐藏并锁定鼠标
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 垂直旋转（摄像机上下）
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 防止翻过头

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 水平旋转（角色整体旋转）
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

