using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sUI_Inventory : MonoBehaviour
{
    private sInventory inventory;
    private Transform itemSlotContainer;
    private Transform ItemslotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        ItemslotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }
    public void SetInventory(sInventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemchanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemchanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == ItemslotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float ItemSlotCellSize = 120f;
        foreach(sItem item in inventory.GetItemList()){
            RectTransform itemSlotRectTranform = Instantiate(ItemslotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTranform.gameObject.SetActive(true);
            itemSlotRectTranform.anchoredPosition = new Vector2(x * ItemSlotCellSize, y * ItemSlotCellSize);
            Image image = itemSlotRectTranform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            x++;
            if(x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
}
