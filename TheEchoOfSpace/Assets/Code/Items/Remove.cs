using UnityEngine;
using UnityEngine.Events;

public class Remove : MonoBehaviour
{
    public ItemCell Item;

    public UnityEvent itemRemoveEvent;
    public UnityEvent itemNotRemoveEvent;

    public void RemoveItem()
    {
        if(InventoryCharacter.instance.RemoveItem(Item) == true)
        {
            itemRemoveEvent.Invoke();
        }
        else
        {
            itemNotRemoveEvent.Invoke();
        }
    }
}
