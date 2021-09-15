using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBodyPlayer;
    [SerializeField] private Vector3 _forwardDirection;
    [SerializeField] private float _speed;
    [SerializeField] private float _angle;
    [SerializeField] private float _distance;
    [SerializeField] private float _maxVectorLength = 2;

    private Vector3 _nextPosition;


    private void Start()
    {
        float rotationY = Mathf.Rad2Deg * Mathf.Asin(_forwardDirection.x / _forwardDirection.magnitude);
        transform.rotation = Quaternion.Euler(_angle, rotationY, transform.rotation.eulerAngles.z);

    }


    private void FixedUpdate()
    {
        _nextPosition = _rigidBodyPlayer.position + Vector3.ClampMagnitude(_rigidBodyPlayer.velocity, _maxVectorLength);
        _nextPosition += Vector3.up * Mathf.Cos(Mathf.Deg2Rad * _angle) * _distance;
        _nextPosition += _forwardDirection * Mathf.Sin(Mathf.Deg2Rad * _angle) * _distance;
        transform.position = Vector3.Lerp(transform.position, _nextPosition, _speed * Time.fixedDeltaTime);
    }
}
