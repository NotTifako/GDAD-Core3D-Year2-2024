using UnityEngine;

public class FunPotion : Item
{
    public int funAmount;
    public int minFunAmount = 10;
    public int maxFunAmount = 104;

    public FunPotion()
    {
        itemName = "Fun Potion";
        description = "This is a really fun potion!";
    }

    void Start()
    {
        funAmount = Random.Range(minFunAmount, maxFunAmount);
        Debug.Log($"Fun Potion: Random fun amount set to {funAmount}");
    }

    public override void DisplayInfo()
    {
        Debug.Log($"{itemName}: {funAmount} added to this experience!");
    }
}
