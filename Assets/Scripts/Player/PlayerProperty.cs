using UnityEngine;
using System.Collections.Generic;
public class PlayerProperty : MonoBehaviour
{
    public Dictionary<PropertyType,List<Property>> propertyDict;
    public int hpValue=100;
    public int energyValue=100;
    public int mentalValue=100;
    public int level=1;
    public int currentExp=0;

    
    void Awake()
    {
        propertyDict=new Dictionary<PropertyType,List<Property>>();
        propertyDict.Add(PropertyType.SpeedValue,new List<Property>());
        propertyDict.Add(PropertyType.AttackValue,new List<Property>());

        AddProperty(PropertyType.SpeedValue,5);
        AddProperty(PropertyType.AttackValue,20);

        EventCenter.OnEnemyDied+=OnEnemyDied;
    }

    public void UseDrug(ItemSO itemSO)
    {
        foreach(Property p in itemSO.propertyList)
        {
            AddProperty(p.propertyType,p.propertyValue);
        }
    }

    void AddProperty(PropertyType pt,int value)
    {   
        switch(pt)
        {
            case PropertyType.HPValue:
            hpValue+=value;
            return;
            case PropertyType.EnergyValue:
            energyValue+=value;
            return;
            case PropertyType.MentalValue:
            mentalValue+=value;
            return;
        }
        List<Property> list;
        propertyDict.TryGetValue(pt,out list);
        list.Add(new Property(pt,value));
    }
    void RemoveProperty(PropertyType pt,int value)
    {
        switch(pt)
        {
            case PropertyType.HPValue:
            hpValue-=value;
            return;
            case PropertyType.EnergyValue:
            energyValue-=value;
            return;
            case PropertyType.MentalValue:
            mentalValue-=value;
            return;
        }
        List<Property> list;
        propertyDict.TryGetValue(pt,out list);

        list.Remove(list.Find(x=>x.propertyValue==value));
    }
    public void OnEnemyDied(Enemy enemy)
    {
        this.currentExp+=enemy.exp;
        if(currentExp>=level*30)
        {
            currentExp-=level*30;
            level++;
        }
        PlayerPropertyUI.Instance.UpdatePlayerPropertyUI();
    }
}
