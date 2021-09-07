using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sGameController : MonoBehaviour
{
    
    public GameObject enemyP;
    public Transform spawPoint;

    public bool spawEnemy = false;

    public string triggerName;

    private bool auxTrigger01;

    void Start()
    {
        sItemWorld.SpawnItemWorld(new Vector3(5, 3, 0), new sItem { itemType = sItem.ItemType.Chave, amount = 1 });
        sItemWorld.SpawnItemWorld(new Vector3(5, 0, 0), new sItem { itemType = sItem.ItemType.Batata, amount = 1 });
    }

    // Update is called once per frame
    void Update()
    {
        SpawEnemy();
    }

    public void SpawEnemy()
    {
        if (spawEnemy == true)
        {
            if (triggerName == "01" && auxTrigger01 == false)
            {
                spawPoint = GameObject.Find("SpawEnemyPoints").transform.GetChild(0);
                Instantiate(enemyP, spawPoint.transform.position, spawPoint.rotation);
                spawEnemy = false;
                auxTrigger01 = true;
            }
            else if (triggerName == "02")
            {
                spawPoint = GameObject.Find("SpawEnemyPoints").transform.GetChild(1);
                Instantiate(enemyP, spawPoint.transform.position, spawPoint.rotation);
                spawEnemy = false;
            }
        }
    }
}
