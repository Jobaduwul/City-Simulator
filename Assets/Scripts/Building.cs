using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Building : MonoBehaviour
{
    public int level = 1; // Default level of the building
    public float baseIncomeRate = 1f; // Base income rate per second
    public float incomeRatePerLevel = 1f; // Additional income rate per level
    public int buildingCost = 10; // One-time building cost
    public int initialUpgradeCost = 10; // Initial upgrade cost
    public int upgradeCostIncrease = 5; // Upgrade cost increase per level

    public GameManager gameManager; // Reference to the GameManager script
    public TMP_Text buttonText; // Reference to the button text (TextMeshPro)

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the GameManager reference is set
        if (gameManager == null)
        {
            Debug.LogError("GameManager reference is not set for the building: " + gameObject.name);
            return;
        }

        // Ensure the ButtonText reference is set
        if (buttonText == null)
        {
            Debug.LogError("ButtonText reference is not set for the building: " + gameObject.name);
            return;
        }

        // Generate the initial button text
        UpdateButtonText();
    }

    // Method to update the button text
    void UpdateButtonText()
    {
        buttonText.text = "Upgrade to Level " + (level + 1) + "\nCost: $" + CalculateUpgradeCost();
    }

    // Method to calculate the cost of upgrading the building
    int CalculateUpgradeCost()
    {
        return initialUpgradeCost + (upgradeCostIncrease * (level - 1));
    }

    // Method to build or upgrade the building
    public void BuildOrUpgrade()
    {
        // If the player has enough money, build or upgrade the building
        if (gameManager.moneyData.money >= buildingCost && (gameManager.moneyData.money >= CalculateUpgradeCost() || level == 1))
        {
            // Deduct the building or upgrade cost from the player's money
            if (level == 1)
                gameManager.moneyData.SubtractMoney(buildingCost);
            else
                gameManager.moneyData.SubtractMoney(CalculateUpgradeCost());

            // Increase the building level
            level++;

            // Update the button text after building or upgrading
            UpdateButtonText();

            // Log the build or upgrade information
            if (level == 2)
                Debug.Log("Building built to level " + level + ". New income rate: " + CalculateIncomeRate());
            else
                Debug.Log("Building upgraded to level " + level + ". New income rate: " + CalculateIncomeRate());

            // Activate the building
            gameObject.SetActive(true);

            // Increase the rate of income in the GameManager
            gameManager.moneyData.moneyPerSecond += 1f; // Adjust this value as needed
        }
        else
        {
            Debug.Log("Insufficient funds to build or upgrade the building!");
        }
    }


    // Method to calculate the income rate based on the building level
    float CalculateIncomeRate()
    {
        return baseIncomeRate + (incomeRatePerLevel * (level - 1));
    }

}
