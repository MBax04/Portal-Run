using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [Header("Stuff")]
    [SerializeField]
    private float smoothSpeed = 0.2f;
    public Vector3 offset;
    public bool freezeY;
    public bool freezeX;
    public float frozenX;
    public float frozenY;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        if (freezeX == true)
        {
            transform.position = new Vector3(frozenX, smoothPosition.y, -10);
        }
        else if (freezeY == true)
        {
            transform.position = new Vector3(smoothPosition.x, frozenY, -10);
        }
        else
        {
            transform.position = smoothPosition;
        }
    }
}
