using UnityEngine;
using System;
using System.Collections.Generic;
[CreateAssetMenu]
public class ItemScriptObject : ScriptableObject
{
    public int id;
    public string itemName;
    public ItemType itemType;
    public string description;
    public List<ItemProperty> itemProperties;
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
    public ItemPropertyType propertyName;
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
