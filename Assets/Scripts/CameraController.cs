using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField] private float _speed;
    [SerializeField] private float _height = 30f;

    void Update()
    {
        Vector3 targPos = target.position;
        Vector3 transPos = transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targPos - transPos, Vector3.right),Time.deltaTime*_speed);
        var position= Vector3.Lerp(transPos, targPos, Time.deltaTime*_speed);
        position.y = _height;
        transform.position = position;
    }
}