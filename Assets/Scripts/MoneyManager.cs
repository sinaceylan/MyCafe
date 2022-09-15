using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int moneyTotal = 0;

    private void OnEnable()
    {
        TriggerManager.OnMoneyCollected += IncreaseMoney;
    }
    private void OnDisable()
    {
        TriggerManager.OnMoneyCollected -= IncreaseMoney;
    }

    void IncreaseMoney()
    {
        moneyTotal += 100;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = moneyTotal.ToString()+" $";
    }
}
