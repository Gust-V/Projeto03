using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sPlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private sInventory inventory;
    private float playerSpeed = 3.0f;

    private bool aux = false;

    [SerializeField] private sUI_Inventory uI_Inventory;

    private void Awake()
    {
        inventory = new sInventory();
        uI_Inventory.SetInventory(inventory);
    }

    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
       
        
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move; 
            this.gameObject.transform.Rotate(25f, 0, 0, Space.World);
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnTriggerStay(Collider collider)
    {
        //Logica de adicionar noo inventario item coletado no cenario 
        sItemWorld itemWorld = collider.GetComponent<sItemWorld>();
        if (itemWorld != null && Input.GetKey(KeyCode.E) && aux == false )
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
            aux = true;
        }
        //

        //Logica abertura de porta e/ou utilizando determinado item
        else if (collider.tag == "Porta" && Input.GetKey(KeyCode.E))
        {
            foreach (sItem item in inventory.itemList)
            {
                if (item.itemType == sItem.ItemType.Chave)
                {
                    Destroy(collider.gameObject);
                }
            }
        }
        //

        //Colidir com inimigo = Para jogo
        else if (collider.tag == "Enemy")
        {
            //Fim de jogo
            Time.timeScale = 0;
        }
        //

        else if (collider.tag == "Trigger")
        {
            GameObject.Find("GameController").GetComponent<sGameController>().spawEnemy = true;
            GameObject.Find("GameController").GetComponent<sGameController>().triggerName = collider.name;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        aux = false;
    }
}
