using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //[SerializeField] private Transform target;
    [SerializeField] private TMP_Text scoreRoundText;
    [SerializeField] private TMP_Text scoreGameText;
    private int _roundScore;
    //[SerializeField] private Transform character;

    public void CountScore(int score)
    {
        if (score > _roundScore)
        {
            _roundScore = score;
            scoreRoundText.text = _roundScore.ToString();
        }
    }

    public void NextRound()
    {
        scoreGameText.text = (int.Parse(scoreGameText.text) + _roundScore).ToString();
        _roundScore = 0;
        scoreRoundText.text = "0";
    }

    public void NextGame()
    {
        _roundScore = 0;
        scoreRoundText.text = "0";
        scoreGameText.text = "0";
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
