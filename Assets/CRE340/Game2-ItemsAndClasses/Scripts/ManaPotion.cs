using UnityEngine;

public class ManaPotion : Item
{
    public int manaRestoreAmount;
    public int minRestoreAmount = 20;
    public int maxRestoreAmount = 50;

    public ManaPotion()
    {
        itemName = "Mana Potion";
        description = "A potion that restores mana.";
    }

    private void Start()
    {
        manaRestoreAmount = Random.Range(minRestoreAmount, maxRestoreAmount);
        Debug.Log($"Mana Potion: Random restore amount set to {manaRestoreAmount}.");
    }

    public override void DisplayInfo()
    {
        Debug.Log($"{itemName}: Restores {manaRestoreAmount} mana points.");
    }
}
