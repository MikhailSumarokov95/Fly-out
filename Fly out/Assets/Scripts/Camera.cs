using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float damping = 1;
    [SerializeField] private Vector3 offset = new Vector3(0, 3f, -4.5f);
    private GameObject _target;

    private void LateUpdate()
    {
        if (_target == null) return;
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = _target.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
        //Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = _target.transform.position + (_target.transform.rotation * offset);
        transform.LookAt(_target.transform);
    }

    public void SetTarget(GameObject target) => _target = target;
}
