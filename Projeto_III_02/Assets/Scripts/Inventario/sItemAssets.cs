using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sItemAssets : MonoBehaviour
{
    public static sItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite chaveSprite;
    public Sprite batatSprite;
    public Sprite senhaSprite;
}
