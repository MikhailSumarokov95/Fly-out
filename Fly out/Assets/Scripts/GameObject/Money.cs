using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int[] rewardForPositionInGame;
    [SerializeField] private int[] rewardForPositionInRound;
    [SerializeField] private TMP_Text moneyText;

    public int PlayerPositionInLeaderBoard { get; set; } 

    private void Start()
    {
        moneyText.text = PlayerPrefs.GetInt("money", 0).ToString();
    }

    public void RewardingForGame()
    {
        if (PlayerPositionInLeaderBoard >= rewardForPositionInGame.Length
            || PlayerPositionInLeaderBoard < 1) return;
        ChangeAmountMoney(rewardForPositionInGame[PlayerPositionInLeaderBoard - 1]);
    }

    public void RewardingForRound()
    {
        if (PlayerPositionInLeaderBoard >= rewardForPositionInRound.Length
            || PlayerPositionInLeaderBoard < 1) return;
        ChangeAmountMoney(rewardForPositionInRound[PlayerPositionInLeaderBoard - 1]);
    }

    public void Rewarding(int reward) => ChangeAmountMoney(reward);

    private void ChangeAmountMoney(int value)
    {
        var money = PlayerPrefs.GetInt("money", 0) + value;
        PlayerPrefs.SetInt("money", money);
        moneyText.text = money.ToString();
    }
}
