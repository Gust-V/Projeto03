using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sItemWorld : MonoBehaviour
{
    public static sItemWorld SpawnItemWorld(Vector3 position, sItem item)
    {
        Transform transform = Instantiate(sItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        sItemWorld itemWorld = transform.GetComponent<sItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    private sItem item;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(sItem item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public sItem GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
