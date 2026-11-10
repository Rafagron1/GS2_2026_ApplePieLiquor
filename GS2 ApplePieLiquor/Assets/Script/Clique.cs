using UnityEngine;

public class Clique : MonoBehaviour
{
    [SerializeField] private float money = 0;
    [SerializeField] private int buyers = 10;
    [SerializeField] private int coffee = 10;
    [SerializeField]private int buyersMax;
    [SerializeField]private int coffeeMax;
    public static int buyersRate = 10;
    public static int coffeeRate = 10;
    [SerializeField] private float refreshRate;
    [SerializeField] private float cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cooldown = refreshRate;
    }

    // Update is called once per frame
    void Update()
    {
        Refresh();
    }
    private void Refresh()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
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
            cooldown = refreshRate;
        }
    }
    public void Click()
    {
        if (buyers >= 1 && coffee >= 1)
        {
            money++;
            buyers--;
            coffee--;
        }
    }
}
