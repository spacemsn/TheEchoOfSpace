using UnityEngine;

public class Interaction : MonoBehaviour
{
    public ItemCell item;

    public void GiveItem()
    {
        InventoryCharacter.instance.AddItem(item);
    }
}
