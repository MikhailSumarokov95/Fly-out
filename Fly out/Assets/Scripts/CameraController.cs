using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offSetPosition = new Vector3(0, 3f, -4.5f);
    private Transform _targetFollow;

    private void LateUpdate()
    {
        if (_targetFollow != null)
        {
            transform.position = _targetFollow.position + offSetPosition;
            transform.rotation = _targetFollow.rotation;
        }
    }

    public void SetTargetFollow(GameObject target) => _targetFollow = target.transform;
}
