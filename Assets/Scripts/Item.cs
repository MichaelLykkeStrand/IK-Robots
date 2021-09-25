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

    public bool IsStackable { get => isStackable; set => isStackable = value; }
    public string DisplayName { get => displayName; set => displayName = value; }
    public string Name { get => name;}
    public int Amount { get => amount; set => amount = value; }
}
