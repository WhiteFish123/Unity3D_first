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
    public List<Property> propertyList;
    public Sprite itemIcon;
    public GameObject itemPrefab;
}
public enum ItemType
{
    Weapon,
    Consumable
}
[Serializable]
public class Property
{
    public PropertyType propertyType;
    public int propertyValue;

    public Property()
    {
        
    }
    public Property(PropertyType propertyType,int value)
    {
        this.propertyType=propertyType;
        this.propertyValue=value;
    }
}
public enum PropertyType
{
    HPValue,
    EnergyValue,
    MentalValue,
    SpeedValue,
    AttackValue,
}
