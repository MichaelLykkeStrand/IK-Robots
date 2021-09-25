using System;
using System.Collections.Generic;

public class Inventory
{
    private List<Item> itemList;
    public event EventHandler OnItemAdded;
    public event EventHandler OnItemRemoved;
    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void Add(Item item)
    {
        if (item.IsStackable)
        {
            bool inInventory = false;
            foreach (var invItem in itemList)
            {
                if(invItem == item)
                {
                    invItem.amount += item.amount;
                }
            }

            if (!inInventory)
            {
                itemList.Add(item);
                OnItemAdded?.Invoke(this, EventArgs.Empty);
            }
        }
        
    }

    public void Remove(Item item)
    {
        OnItemRemoved?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}