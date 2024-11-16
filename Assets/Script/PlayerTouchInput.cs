using UnityEngine;

public class PlayerTouchInput : MonoBehaviour
{
    public Touche touch;

    float cameraAngle;
    float cameraAngleSpeed = 0.2f;

    public float y = 3;
    public float z = 4;

    public float up = 1;

    void Update()
    {
        cameraAngle += touch.TouchDist.x * cameraAngleSpeed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(cameraAngle, Vector3.up) * new Vector3(0, y, z);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * up - Camera.main.transform.position, Vector3.up);
    }
}
