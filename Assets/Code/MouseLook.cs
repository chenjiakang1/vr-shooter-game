using UnityEngine;
#if UNITY_XR_MANAGEMENT
using UnityEngine.XR;
#endif

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // ✅ 检测是否是 VR（如 Quest 系列），如果是就禁用本脚本
#if UNITY_XR_MANAGEMENT
        if (XRSettings.isDeviceActive)
        {
            string deviceName = XRSettings.loadedDeviceName.ToLower();
            if (deviceName.Contains("oculus") || deviceName.Contains("meta") || deviceName.Contains("quest"))
            {
                Debug.Log("MouseLook disabled on VR headset: " + deviceName);
                this.enabled = false;
                return;
            }
        }
#endif
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (Mathf.Abs(mouseX) > 0.01f)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
