using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Inventory/Item", order = 1)]
public class ItemObject : ScriptableObject
{
    [Header("Тип объекта")]
    public ItemType itemType;
    [Header("Объект")]
    public GameObject gameObject;
    [Header("Картинка")]
    public Sprite sprite;
    [Header("Название")]
    public string name;
    [Header("О предмете")]
    [TextArea] public string aboutItem;
    [Header("Складывание")]
    public bool isStack;
    [Header("Максимальное складывание")]
    public int maxStack;
}

public enum ItemType { Tool, Food, Trash }

public class FoodItem : ItemObject
{
    [Header("Кол-во восполняемого HP")]
    public float addHealth;
}
