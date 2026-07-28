using UnityEngine;
using System.Collections.Generic;
public class PlayerProperty : MonoBehaviour
{
    public Dictionary<PropertyType,List<Property>> propertyList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        propertyList=new Dictionary<PropertyType,List<Property>>();
        propertyList.Add(PropertyType.HPValue,new List<Property>());
        propertyList.Add(PropertyType.EnergyValue,new List<Property>());
        propertyList.Add(PropertyType.MentalValue,new List<Property>());
        propertyList.Add(PropertyType.SpeedValue,new List<Property>());
        propertyList.Add(PropertyType.AttackValue,new List<Property>());

        AddProperty(PropertyType.HPValue,100);
        AddProperty(PropertyType.EnergyValue,100);
        AddProperty(PropertyType.MentalValue,100);
        

    }

    void AddProperty(PropertyType pt,int value)
    {
        List<Property> list;
        propertyList.TryGetValue(pt,out list);
        list.Add(new Property(pt,value));
    }
    void RemoveProperty(PropertyType pt,int value)
    {
        List<Property> list;
        propertyList.TryGetValue(pt,out list);

        list.Remove(list.Find(x=>x.propertyValue==value));
    }
}
