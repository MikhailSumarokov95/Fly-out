using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody pointAddForce;
    [SerializeField] private float factorForce = 500f;
    public float PowerStartForce { get; set; }
    public float AngleStartForce { get; set; }
    public float AngleTurnCarY { get; set; }


    private void Start()
    { 
        var vectorForce = new Vector3(Mathf.Cos(AngleStartForce * Mathf.PI / 2) * Mathf.Sin(AngleTurnCarY * Mathf.Deg2Rad),
        Mathf.Sin(AngleStartForce * Mathf.PI / 2),
        Mathf.Cos(AngleStartForce * Mathf.PI / 2) * Mathf.Cos(AngleTurnCarY * Mathf.Deg2Rad)) * PowerStartForce * factorForce;
        pointAddForce.AddForce(vectorForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target") GetComponent<Rigidbody>().isKinematic = true;
    }
}
