using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public UnityEvent<int> OnHitTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") OnHitTarget?.Invoke(int.Parse(name));
    }
}
