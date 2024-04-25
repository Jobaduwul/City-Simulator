using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Struct to represent overall money and rate
[System.Serializable]
public struct MoneyData
{
    public int money; // Player's current money
    public float moneyPerSecond; // Total amount of money earned per second

    // Method to add money to the total
    public void AddMoney(int amount)
    {
        money += amount;
    }

    // Method to subtract money from the total
    public void SubtractMoney(int amount)
    {
        money -= amount;
    }
}

public class GameManager : MonoBehaviour
{
    public MoneyData moneyData; // Overall money and rate data
    public TMP_Text moneyText; // Reference to the UI text for displaying money amount (TextMeshPro)
    public TMP_Text rateText; // Reference to the UI text for displaying current rate (TextMeshPro)

    // Start is called before the first frame update
    void Start()
    {
        // Start coroutine to update money per second
        StartCoroutine(UpdateMoneyPerSecond());
    }

    // Update is called once per frame
    void Update()
    {
        // Update UI texts
        moneyText.text = "$ " + moneyData.money.ToString();
        rateText.text = "$ " + moneyData.moneyPerSecond.ToString() + "/s";
    }

    // Coroutine to update money per second
    IEnumerator UpdateMoneyPerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            moneyData.AddMoney((int)(moneyData.moneyPerSecond)); // Add money per second to the total
        }
    }
}
