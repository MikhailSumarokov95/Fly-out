using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanCharacter : MonoBehaviour
{
    private float _waitSecond;
    private float _timerWait;

    private void Start()
    {
        _waitSecond = Random.Range(0, 3);    
    }

    private void Update()
    {
        _timerWait += Time.deltaTime * Time.timeScale;
        if (_timerWait > _waitSecond) GetComponent<Animator>().SetBool("Start", true);
    }
}
