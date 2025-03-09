using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Inventory/Item", order = 1)]
public class ItemObject : ScriptableObject
{
    [Header("��� �������")]
    public ItemType itemType;
    [Header("������")]
    public GameObject gameObject;
    [Header("��������")]
    public Sprite sprite;
    [Header("��������")]
    public string name;
    [Header("� ��������")]
    [TextArea] public string aboutItem;
    [Header("�����������")]
    public bool isStack;
    [Header("������������ �����������")]
    public int maxStack;
}

public enum ItemType { Tool, Food, Trash }

public class FoodItem : ItemObject
{
    [Header("���-�� ������������� HP")]
    public float addHealth;
}
