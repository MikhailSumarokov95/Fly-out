using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float PowerStartForce { get; set; }
    public float AngleStartForce { get; set; }
    public float AngleTurnCarY { get; set; }

    private void Start()
    { 
        var vectorForce = new Vector3(Mathf.Cos(AngleStartForce * Mathf.PI / 2) * Mathf.Sin(AngleTurnCarY * Mathf.Deg2Rad),
        Mathf.Sin(AngleStartForce * Mathf.PI / 2),
        Mathf.Cos(AngleStartForce * Mathf.PI / 2) * Mathf.Cos(AngleTurnCarY * Mathf.Deg2Rad)) * PowerStartForce * 50;
        GetComponent<Rigidbody>().AddForce(vectorForce, ForceMode.Impulse);
    }
}