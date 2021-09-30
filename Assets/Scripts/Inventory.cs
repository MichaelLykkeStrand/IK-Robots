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
            foreach (var invItem in itemList)
            {
                if(invItem.Name == item.Name)
                {
                    Item.Add(invItem, item);
                }
            }
            if (item.Amount != 0)
            {
                itemList.Add(item);
                OnItemAdded?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                OnItemAdded?.Invoke(this, EventArgs.Empty);
            }
        }
        else
        {
            itemList.Add(item);
            OnItemAdded?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Remove(Item item)
    {
        foreach (var invItem in itemList)
        {
            int amount = item.Amount;
            if (invItem.Name == item.Name)
            {
                if(amount - item.Amount < 0)
                {
                    amount = 0;
                }
                else
                {
                    amount -= item.Amount;
                }
                //invItem.Amount = amount;
                OnItemRemoved?.Invoke(this, EventArgs.Empty);
            }
        }

    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}