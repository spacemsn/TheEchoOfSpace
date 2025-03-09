using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class InventoryCharacter : MonoBehaviour
{
    public static InventoryCharacter instance;

    [SerializeField] private List<ItemCell> inventory = new List<ItemCell>();
    [SerializeField] private GameObject inventoryPanel;
    public List<ItemCell> Inventory => inventory;
    private int sizeInventory = 30;

    [Header("Для подбора предметов")]
    [SerializeField] GameObject _camera;
    [SerializeField] float distance;

    [Header("Панель взаимодействия")]
    [SerializeField] GameObject buttonPanel;

    private void Awake()
    {
        UpdatePanel();
    }

    private void Start()
    {
        if (instance == null) instance = this;
        else { Destroy(instance.gameObject); instance = this; }
    }

    private void Update()
    {
        PickUp();
    }

    public void AddItem(ItemCell newItem)
    {
        ItemCell addItem = new ItemCell { item = newItem.item, count = newItem.count };
        if (Inventory.Count == 0)
        {
            inventory.Add(addItem); AddPanel(addItem);
        }
        else if(inventory.Count < sizeInventory)
        {
            bool itemCheck = false;
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].item == newItem.item && inventory[i].count + addItem.count < addItem.item.maxStack)
                {
                    inventory[i].count += addItem.count;
                    itemCheck = true;
                    break;
                }
            }
            if (itemCheck == false)
            {
                inventory.Add(addItem); AddPanel(addItem);
            }
        }
        else { Debug.Log("Инвентарь полон!"); }
    }

    public bool RemoveItem(ItemCell removeItem)
    {
        bool callBack = false;
        for (int i = 0; i < inventory.Count; ++i)
        {
            if (inventory[i].count < removeItem.count) 
            { 
                callBack = false; break; 
                // Если предметов не хватает сказать об этом пользователю
            }
            if (inventory[i].count > removeItem.count)
            { 
                inventory[i].count -= removeItem.count; callBack = true; break; 
            }
            if (inventory[i].count == removeItem.count) 
            { 
                inventory.RemoveAt(i); callBack = true; break; 
            }

            if(i == inventory.Count - 1 && inventory[i].item != removeItem.item)
            {
                callBack = false; break;
            }
        }

        return callBack;
    }

    public void AddPanel(ItemCell newItem)
    {
        GameObject itemCell = new GameObject("ItemCell");
        itemCell.transform.SetParent(inventoryPanel.transform);
        itemCell.AddComponent<Image>().sprite = newItem.item.sprite;
    }
    public void UpdatePanel()
    {
        if (inventory.Count != 0)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                AddPanel(inventory[i]);
            }
        }
    }    

    public void PickUp()
    {
        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, distance))
        {
            if (hit.transform.gameObject.GetComponent<Interaction>())
            {
                buttonPanel.gameObject.SetActive(true);
                hit.transform.gameObject.GetComponent<Outline>().SelectedObject(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<Interaction>().GiveItem();
                }
            }
            else { buttonPanel.gameObject.SetActive(false); }
        }
    }
}

[Serializable]
public class ItemCell
{
    public ItemObject item;
    public int count;
}
