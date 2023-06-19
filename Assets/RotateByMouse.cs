using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    public float anglePerSecond;
    public float angleOverDistance;
    public Transform cameraHolder;
    public float minPitch;
    public float maxPitch;
    public float pitch;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UpdateYaw()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float yaw = mouseX * anglePerSecond * Time.deltaTime;
        transform.Rotate(0, yaw, 0);
        //float yaw1 = mouseY * anglePerSecond * Time.deltaTime;
        //transform.Rotate(-yaw1, 0, 0);
    }
    void UpdatePitch()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaPitch = -mouseY * angleOverDistance;
        pitch = Mathf.Clamp(pitch + deltaPitch, minPitch, maxPitch);
        cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateYaw();
        UpdatePitch();


    }
}
