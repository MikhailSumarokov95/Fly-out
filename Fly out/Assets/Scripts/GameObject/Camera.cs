using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float damping = 1f;
    [SerializeField] private Vector3 offset = new Vector3(0, 3f, -4.5f);
    private Transform _target;
    private Rigidbody _targetRigidbody;

    private void LateUpdate()
    {
        if (_target == null) return;
        //float currentAngle = transform.eulerAngles.y;
        //float desiredAngle = _target.eulerAngles.y;
        //Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
        var currentPosition = transform.position;
        var desiredPosition = _target.position + (_target.rotation * offset);
        transform.position = Vector3.Slerp(currentPosition, desiredPosition, Time.deltaTime * damping * _targetRigidbody.velocity.magnitude);
        transform.LookAt(_target.transform);
    }

    public void SetTarget(GameObject target)
    {
        _target = target.transform.Find("TargetCamera");
        _targetRigidbody = target.GetComponent<Rigidbody>();
    }
}
