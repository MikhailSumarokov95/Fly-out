using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using ToxicFamilyGames.AdsBrowser;

public class ForceController : MonoBehaviour
{
    [SerializeField] private TMP_Text magnitudePowerForceText;
    [SerializeField] private TMP_Text magnitudeAngleForceText;
    public UnityEvent<float, float> onChoiceForceFinished;
    private IEnumerator _choicePowerCoroutine;
    private IEnumerator _choiceAngleCoroutine;
    private bool _isChoicePowerForceFinished;
    private bool _isChoiceAngleForceFinished;
    private InputController _inputControler;

    private void Awake()
    {
        _choicePowerCoroutine = ChoiceMagnitude(magnitudePowerForceText);
        _choiceAngleCoroutine = ChoiceMagnitude(magnitudeAngleForceText);
    }

    public void RefreshValue()
    {
        magnitudeAngleForceText.text = "0";
        magnitudePowerForceText.text = "0";
        _isChoicePowerForceFinished = false;
        _isChoiceAngleForceFinished = false;
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
        StopAllCoroutines();
    }

    private void ChoiceInputController()
    {
        if (YandexSDK.instance.isMobile()) _inputControler = FindObjectOfType<InputControllerMobile>();
        else _inputControler = FindObjectOfType<InputControllerPC>();
    }

    private void StartChoiceForce()
    {
        if (!_isChoicePowerForceFinished) StartCoroutine(_choicePowerCoroutine);
        else if (!_isChoiceAngleForceFinished) StartCoroutine(_choiceAngleCoroutine);
    }

    private void StopChoiceForce()
    {
        if (!_isChoicePowerForceFinished)
        {
            StopCoroutine(_choicePowerCoroutine);
            _isChoicePowerForceFinished = true;
        }

        else if (!_isChoiceAngleForceFinished)
        {
            StopCoroutine(_choiceAngleCoroutine);
            _isChoiceAngleForceFinished = true;
            onChoiceForceFinished?.Invoke(float.Parse(magnitudePowerForceText.text), float.Parse(magnitudeAngleForceText.text));
        }
    }

    private IEnumerator ChoiceMagnitude(TMP_Text scaleText)
    {
        var amountValueChange = 0.02f;
        var magnitude = 0f;
        var isValueIncrease = true;
        while (true)
        {
            if (isValueIncrease)
            {
                if (magnitude < 1f) magnitude += amountValueChange;
                else isValueIncrease = false;
            }

            else
            {
                if (magnitude > 0f) magnitude -= amountValueChange;
                else isValueIncrease = true;
            }
            scaleText.text = Mathf.Abs(magnitude).ToString();
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
