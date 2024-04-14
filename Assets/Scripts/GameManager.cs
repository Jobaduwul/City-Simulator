using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int money = 0; // Player's current money
    public int ratePerSecond = 0; // Amount of money earned per second
    public TMP_Text moneyText; // Reference to the UI text for displaying money amount
    public TMP_Text rateText; // Reference to the UI text for displaying current rate

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EarnMoney());
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI text to display current money amount and rate
        moneyText.text = "$" + money.ToString(); // Format money to display with 2 decimal places
        rateText.text = "$" + ratePerSecond.ToString() + "/sec"; // Format rate similarly
    }

    // Coroutine to earn money gradually
    IEnumerator EarnMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); // Wait for 1 second
            money += ratePerSecond; // Increase money by the set rate
        }
    }
}
