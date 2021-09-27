using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Item
{

    private bool isStackable = false;
    private string name;
    private string displayName;
    private int amount;
    private int stackSize = 64;


    Item(String name)
    {
        this.name = name;
        this.displayName = name;
    }

    Item(String name, String displayName)
    {
        this.name = name;
        this.displayName = displayName;
    }

    Item(String name, String displayName, int stackSize)
    {
        this.name = name;
        this.displayName = displayName;
        this.stackSize = stackSize;

    }


    public bool IsStackable { get => isStackable; set => isStackable = value; }
    public string DisplayName { get => displayName; set => displayName = value; }
    public string Name { get => name;}
    public int Amount { 
        get => amount; 
    }

    public static void Add(Item item1, Item item2)
    {
        if (item1.name != item2.name) return;
        int newAmount = item1.Amount + item2.Amount;
        int overflow = newAmount - item1.stackSize;
        if (overflow < 0) overflow = 0;
        if (newAmount > item1.stackSize) newAmount = item1.stackSize;
        item1.amount = newAmount;
        item2.amount = overflow;
    }
}
