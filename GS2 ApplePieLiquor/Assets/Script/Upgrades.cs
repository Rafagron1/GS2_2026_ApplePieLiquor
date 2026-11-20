using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [System.Serializable]
    public class upgradeLevel
    {
        public int cost;
        public GameObject storeUpgrade;
    }
    [Header("ButtonUpgrade")]
    [SerializeField] upgradeLevel[] level;
    [SerializeField] Button buttonUpgrade;
    [SerializeField] Text buttonText;
    [SerializeField] private string upgradeText;
    private int currentLvl;
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        UpdateStore();
    }

    public void UpgradeBuyersOvertime()
    {
        if (currentLvl >= level.Length) return;
        int cost = level[currentLvl].cost;
        if (!Clique.SpendMoney(cost)) return;
        currentLvl++;
        UpgradeCheck();
        if (currentLvl == 0)
        {
            Clique.buyersRate = 10;

        }
        else
        {
            Clique.buyersRate = currentLvl * 25;
        }
    }
    public void UpgradeCoffeeOvertime()
    {
        if (currentLvl >= level.Length) return;
        int cost = level[currentLvl].cost;
        if (!Clique.SpendMoney(cost)) return;
        currentLvl++;
        UpgradeCheck();
        if (currentLvl == 0)
        {
            Clique.coffeeRate = 10;

        }
        else
        {
            Clique.coffeeRate = currentLvl * 25;
        }
    }
    public void UpgradeMoneyOvertime()
    {
        if (currentLvl >= level.Length) return;
        int cost = level[currentLvl].cost;
        if (!Clique.SpendMoney(cost)) return;
        currentLvl++;
        UpgradeCheck();
            Clique.moneyIncome = currentLvl * 5;
    }
    public void UpgradeMoneyForClick()
    {
        if (currentLvl >= level.Length) return;
        int cost = level[currentLvl].cost;
        if (!Clique.SpendMoney(cost)) return;
        currentLvl++;
        UpgradeCheck();
        if (currentLvl ==0 )
        {
            Clique.currentCoffeCost = 1;
        }
        else
        {
            Clique.currentCoffeCost = currentLvl * 5;
        }
    }
    public void UpgradeBuyerBonus()
    {
        if (currentLvl >= level.Length) return;
        int cost = level[currentLvl].cost;
        if (!Clique.SpendMoney(cost)) return;
        currentLvl++;
        UpgradeCheck();
        Clique.buyersBonus = currentLvl * 0.05;
    }
    public void UpgradeCoffeeBonus()
    {
        if (currentLvl >= level.Length) return;
        int cost = level[currentLvl].cost;
        if (!Clique.SpendMoney(cost)) return;
        currentLvl++;
        UpgradeCheck();
        Clique.coffeeBonus = currentLvl * 0.05;
    }
    private void UpgradeCheck()
    {

        UpdateStore();
        audioSource.Play();
    }
    private void UpdateStore()
    {
        for (int i = 0; i < level.Length; i++)
        {
            if (level[i].storeUpgrade != null)
            {
                level[i].storeUpgrade.SetActive(i == currentLvl);
            }
        }
        if (currentLvl < level.Length)
        {
            buttonText.text = upgradeText + (currentLvl + 1) + " - Cost: " + level[currentLvl].cost;
        }
        else
        {
            buttonText.text = upgradeText + "Max Level";
            buttonUpgrade.interactable = false;
        }
    }
}
