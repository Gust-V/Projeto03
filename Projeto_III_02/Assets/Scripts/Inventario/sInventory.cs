using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class sInventory
{
    public event EventHandler OnItemListChanged;

    public List<sItem> itemList;
    
    public sInventory()
    {
        itemList = new List<sItem>();

        //AddItem(new sItem { itemType = sItem.ItemType.Chave, amount = 1 });
        Debug.Log(itemList.Count);
    }

    public void AddItem(sItem item)
    {
        itemList.Add(item);
        Debug.Log(itemList[itemList.Count - 1].itemType);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<sItem> GetItemList()
    {
        return itemList;
    }
}
