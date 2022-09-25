using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using ToxicFamilyGames.AdsBrowser;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text magnitudePowerForceText;
    [SerializeField] private TMP_Text magnitudeAngleForceText;
    //public UnityEvent<float> onChoicePowerFinished;
    //public UnityEvent<float> onChoiceAngleFinished;
    private IEnumerator _choicePowerCoroutine;
    private IEnumerator _choiceAngleCoroutine;
    private bool _isChoicePowerForceFinished;
    private bool _isChoiceAngleForceFinished;
    private InputControler _inputControler;

    private void Start()
    {
        _choicePowerCoroutine = ChoiceMagnitude(magnitudePowerForceText);
        _choiceAngleCoroutine = ChoiceMagnitude(magnitudeAngleForceText);
        FollowActionInputControler();
    }

    public void StartChoiceForce()
    {
        if (!_isChoicePowerForceFinished) StartCoroutine(_choicePowerCoroutine);
        else if (!_isChoiceAngleForceFinished) StartCoroutine(_choiceAngleCoroutine);
    }

    public void StopChoiceForce()
    {
        if (!_isChoicePowerForceFinished)
        {
            StopCoroutine(_choicePowerCoroutine);
            _isChoicePowerForceFinished = true;
            //onChoicePowerFinished?.Invoke(float.Parse(magnitudePowerForceText.text));
        }

        else if (!_isChoiceAngleForceFinished)
        {
            StopCoroutine(_choiceAngleCoroutine);
            _isChoiceAngleForceFinished = true;
            //onChoiceAngleFinished?.Invoke(float.Parse(magnitudeAngleForceText.text));
        }
    }

    public void RefreshValue()
    {
        magnitudeAngleForceText.text = "0";
        magnitudePowerForceText.text = "0";
        _isChoicePowerForceFinished = false;
        _isChoiceAngleForceFinished = false;
    }

    private void FollowActionInputControler()
    {
        if (YandexSDK.instance.isMobile()) _inputControler = FindObjectOfType<InputControlerMobile>();
        else _inputControler = FindObjectOfType<InputControlerPC>();
        _inputControler.onStartChoiceForce += StartChoiceForce;
        _inputControler.onStopChoiceForce += StopChoiceForce;
    }

    private IEnumerator ChoiceMagnitude(TMP_Text scaleText) // привязать к реальному времени 
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
