using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sItem
{
    public enum ItemType
    {
        Chave,
        Senha,
        Batata,
    }

    public ItemType itemType;
    public string ItemName;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Chave:       return sItemAssets.Instance.chaveSprite;
            case ItemType.Batata:      return sItemAssets.Instance.batatSprite;
            case ItemType.Senha:       return sItemAssets.Instance.senhaSprite;
        }
    }
}
