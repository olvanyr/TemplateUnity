
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float timeOffset;
    public Vector3 positionOffset;

    private Vector3 velocity;

    public static CameraFollow instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de CameraFollow dans la scéne");
            return;
        }

        instance = this;
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + positionOffset, ref velocity, timeOffset);
    }
}
