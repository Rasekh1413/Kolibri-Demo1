using UnityEngine;

// experimental camera follow script, just for test. it's instead of using cinemachine for now, but it may be used in the future if we want to have more control over the camera movement.
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float fixedY = 0f;

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = new Vector3(
            target.position.x,
            fixedY,
            transform.position.z
        );
    }
}
