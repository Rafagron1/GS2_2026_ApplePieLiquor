using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Clique : MonoBehaviour
{

    public static int money = 0;
    [SerializeField] private int buyers = 10;
    [SerializeField] private int coffee = 10;
    [SerializeField]private int buyersMax;
    [SerializeField]private int coffeeMax;
    public static double coffeeBonus;
    public static double buyersBonus;
    public static int currentCoffeCost;
    public static int moneyIncome;
    [SerializeField] private int moneyMade;
    public static int buyersRate;
    public static int coffeeRate;
    [SerializeField] private float refreshRate;
    [SerializeField] private float cooldown;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Text moneyText;
    [SerializeField] private Text coffeeText;
    [SerializeField] private Text buyersText;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

            cooldown = refreshRate;
            currentCoffeCost = 1;
        buyersRate = 10;
        coffeeRate = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        buyersMax = buyersRate * 10;
        coffeeMax = coffeeRate * 10;
        Refresh();
        moneyText.text = "Money: "+ money;
        coffeeText.text = "Coffee: " + coffee + "/" + coffeeMax;
        buyersText.text = "Buyers: " + buyers + "/" + buyersMax;
        
    }
    private void Refresh()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {

            RefreshCoffeeBuyers();
            MoneyIncome();
            moneyMade = 0;
            cooldown = refreshRate;

        }
    }
    public void Click()
    {
        audioSource.Play();
        if (buyers >= currentCoffeCost && coffee >= currentCoffeCost)
        {
            money += currentCoffeCost;
            buyers -= currentCoffeCost;
            coffee -= currentCoffeCost;
            moneyMade += currentCoffeCost;
        }
    }
    private void RefreshCoffeeBuyers()
    {
        coffee += (int)(moneyMade * coffeeBonus);
        buyers += (int)(moneyMade * buyersBonus);
        if (coffee <= coffeeMax - coffeeRate)
        {
            coffee += coffeeRate;
        }
        if (coffee > coffeeMax - coffeeRate)
        {
            coffee = coffeeMax;
        }
        if (buyers <= buyersMax - buyersRate)
        {
            buyers += buyersRate;
        }
        if (buyers > buyersMax - buyersRate)
        {
            buyers = buyersMax;
        }
    }
    private void MoneyIncome()
    {
        money += moneyIncome;
    }
    public static bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            return true;
        }
        return false;
    }
}
