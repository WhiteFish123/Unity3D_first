using UnityEngine;
using System;
using System.Collections.Generic;
[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public int id;
    public string itemName;
    public ItemType itemType;
    public string description;
    public List<ItemProperty> propertyList;
    public Sprite itemIcon;
    public GameObject itemPrefab;
}
public enum ItemType
{
    Weapon,
    Consumable
}
[Serializable]
public class ItemProperty
{
    public ItemPropertyType propertyType;
    public int propertyValue;
}
public enum ItemPropertyType
{
    HPValue,
    EnergyValue,
    MentalValue,
    SpeedValue,
    AttackValue,
}
