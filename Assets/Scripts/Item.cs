using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Item
{
    private bool isStackable = false;
    private string name;
    public int amount;


    Item(String name)
    {
        this.name = name;
    }

    public bool IsStackable { get => isStackable; set => isStackable = value; }
}
