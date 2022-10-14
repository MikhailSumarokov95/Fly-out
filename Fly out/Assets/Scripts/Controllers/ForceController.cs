using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ForceController : MonoBehaviour
{
    [SerializeField] private TMP_Text magnitudePowerForceText;
    [SerializeField] private TMP_Text magnitudeAngleForceText;
    [SerializeField] private float _factorChanges = 1;
    public UnityEvent<float, float> onChoiceForceFinished;
    private InputController _inputControler;
    private float _magnitudePowerForce;
    private float _magnitudeAngleForce;
    private bool _isBanedCoroutineSelectForce;
    private bool _isPausedSelectForce;

    private void Start()
    {
        _inputControler = FindObjectOfType<InputController>();
    }

    private void Update()
    {
        if (_inputControler.TouchDownForSelectForce && !_isBanedCoroutineSelectForce)
            StartCoroutine("SelectForce");
    }

    public void PauseSelectPower(bool value) => _isPausedSelectForce = value;

    public void ResetPower()
    {
        _magnitudePowerForce = 0;
        _magnitudeAngleForce = 0;
        magnitudePowerForceText.text = "0";
        magnitudeAngleForceText.text = "0";
        _isBanedCoroutineSelectForce = false;
        _isPausedSelectForce = false;
        StopCoroutine("SelectForce");
    }

    private IEnumerator SelectForce()
    { 
        _isBanedCoroutineSelectForce = true;
        while (!_inputControler.TouchUpForSelectForce)
        {
            if (_isPausedSelectForce) yield return null;
            _magnitudePowerForce += Time.deltaTime * _factorChanges;
            magnitudePowerForceText.text = Mathf.PingPong(_magnitudePowerForce, 1).ToString();
            yield return null;
        }

        yield return new WaitUntil(() => _inputControler.TouchDownForSelectForce);

        while (!_inputControler.TouchUpForSelectForce)
        {
            if (_isPausedSelectForce) yield return null;
            _magnitudeAngleForce += Time.deltaTime * _factorChanges;
            magnitudeAngleForceText.text = Mathf.PingPong(_magnitudeAngleForce, 1).ToString();
            yield return null;
        }
        onChoiceForceFinished?.Invoke(_magnitudePowerForce, _magnitudeAngleForce);
    }
}
