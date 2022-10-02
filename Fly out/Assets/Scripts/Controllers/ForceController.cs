using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using ToxicFamilyGames.AdsBrowser;

public class ForceController : MonoBehaviour
{
    [SerializeField] private TMP_Text magnitudePowerForceText;
    [SerializeField] private TMP_Text magnitudeAngleForceText;
    [SerializeField] private float _factorChanges = 1;
    public UnityEvent<float, float> onChoiceForceFinished;
    private InputController _inputControler;
    private bool _isChoicePowerForceFinished;
    private bool _isChoiceAngleForceFinished;
    private bool _isChoicePowerForceStarted;
    private bool _isChoiceAngleForceStarted;
    private float _magnitudePowerForce;
    private float _magnitudeAngleForce;

    private void Update()
    {
        if (_isChoicePowerForceStarted)
        {
            _magnitudePowerForce += Time.deltaTime * _factorChanges;
            magnitudePowerForceText.text = Mathf.PingPong(_magnitudePowerForce, 1).ToString();
        }
        else if (_isChoiceAngleForceStarted)
        {
            _magnitudeAngleForce += Time.deltaTime * _factorChanges;
            magnitudeAngleForceText.text = Mathf.PingPong(_magnitudeAngleForce, 1).ToString();
        }
    }

    public void RefreshValue()
    {
        magnitudeAngleForceText.text = "0";
        magnitudePowerForceText.text = "0";
        _isChoicePowerForceFinished = false;
        _isChoiceAngleForceFinished = false; 
        _isChoicePowerForceStarted = false;
        _isChoiceAngleForceStarted = false;
        _magnitudeAngleForce = 0;
        _magnitudePowerForce = 0;
    }

    public void FollowActionInputController()
    {
        if (_inputControler == null) ChoiceInputController();
        _inputControler.onStartChoiceForce += StartChoiceForce;
        _inputControler.onStopChoiceForce += StopChoiceForce;
    }

    public void DontFollowActionInputController()
    {
        _inputControler.onStartChoiceForce -= StartChoiceForce;
        _inputControler.onStopChoiceForce -= StopChoiceForce;
    }

    private void ChoiceInputController()
    {
        if (YandexSDK.instance.isMobile()) _inputControler = FindObjectOfType<InputControllerMobile>();
        else _inputControler = FindObjectOfType<InputControllerPC>();
    }

    private void StartChoiceForce()
    {
        if (!_isChoicePowerForceFinished) _isChoicePowerForceStarted = true;
        else if (!_isChoiceAngleForceFinished) _isChoiceAngleForceStarted = true;
    }

    private void StopChoiceForce()
    {
        if (!_isChoicePowerForceFinished)
        {
            _isChoicePowerForceStarted = false;
            _isChoicePowerForceFinished = true;
        }
        else if (!_isChoiceAngleForceFinished)
        {
            _isChoiceAngleForceStarted = false;
            _isChoiceAngleForceFinished = true;
            onChoiceForceFinished?.Invoke(float.Parse(magnitudePowerForceText.text), float.Parse(magnitudeAngleForceText.text));
        }
    }
}
