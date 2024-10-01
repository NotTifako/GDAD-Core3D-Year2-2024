using UnityEngine;

public class Item : MonoBehaviour
{
    protected string itemName;
    protected string description;

    public Item()
    {
        itemName = "Generic Item";
        description = "A generic item.";
        Debug.Log("1st Item Constructor Called");
    }

    public Item(string newItemName, string newDescription)
    {
        itemName = newItemName;
        description = newDescription;
        Debug.Log("2nd Item Constructor Called");
    }

    public virtual void DisplayInfo()
    {
        Debug.Log($"{itemName}: {description}");
    }

    public void SayHello()
    {
        Debug.Log("Hello, I am an item.");
    }
}