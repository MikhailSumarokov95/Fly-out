using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private TMP_Text score;
    [SerializeField] private Transform character;

    private void Start()
    {
        
    }

    //[ContextMenu("CountScore")]
    //public void CountScore() //Transform character
    //{
    //    var targetPosition = target.position;
    //    var distances = new List<float>();
    //    var positionBodyParts = GetPositionChild(character);
    //    foreach (Vector3 positionBodyPart in positionBodyParts)
    //    {
    //        distances.Add(Vector3.Magnitude(positionBodyPart - targetPosition));
    //    }
    //    var minDistance = FindMinValue(distances);
    //    score.text = ((target.localScale.x / 2 - minDistance) /
    //        (target.localScale.x / 200))
    //        .ToString();
    //}

    //private List<Vector3> GetPositionChild(Transform parent)
    //{
    //    List<Vector3> positionChild = new List<Vector3>();
    //    for (var i = 0; i < parent.childCount; i++)
    //    {
    //        positionChild.Add(parent.GetChild(i).position);
    //    }
    //    return positionChild;
    //}

    //private float FindMinValue(List<float> values)
    //{
    //    float minValues = float.MaxValue;
    //    foreach (float score in values)
    //    {
    //        if (score < minValues) minValues = score;
    //    }
    //    return minValues;
    //}
}
