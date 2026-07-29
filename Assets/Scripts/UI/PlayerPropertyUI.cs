using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerPropertyUI : MonoBehaviour
{
    public static PlayerPropertyUI Instance{get;private set;}

    private Image hpProgressBar;
    private TextMeshProUGUI hpText;

    private Image levelProgressBar;
    private TextMeshProUGUI levelText;

    private GameObject propertyGrid;
    private GameObject propertyTemplate;
    private Image weaponIcon;
    void Awake()
    {
        if(Instance!=null&&Instance!=this)
        {
            Destroy(gameObject);
            return;
        }
        Instance=this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpProgressBar=transform.Find("UI/HPProgressBar/ProgressBar").GetComponent<Image>();
        hpText=transform.Find("UI/HPProgressBar/Hp_Number").GetComponent<TextMeshProUGUI>();
        levelProgressBar=transform.Find("UI/LevelProgressBar/ProgressBar").GetComponent<Image>();
        levelText=transform.Find("UI/LevelProgressBar/Level_Number").GetComponent<TextMeshProUGUI>();
        propertyGrid=transform.Find("UI/Property_Grid").gameObject;
        propertyTemplate=transform.Find("UI/Property_Grid/Property_Template").gameObject;
        weaponIcon=transform.Find("UI/Weapon_Icon").GetComponent<Image>();
        propertyTemplate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerPropertyUI(PlayerProperty pp,PlayerAttack pa)
    {
        hpProgressBar.fillAmount=pp.hpValue/100f;
        hpText.text=pp.hpValue + "/100";
        levelProgressBar.fillAmount=pp.level*1.0f /pp.level;
        levelText.text=pp.level.ToString();

        ClearGrid();

        AddProperty("饥饿值："+pp.energyValue);
        AddProperty("精神值："+pp.mentalValue);

        foreach(var item in pp.propertyDict)
        {
            string propertyName="";
            switch(item.Key)
            {
                case PropertyType.HPValue:
                propertyName="生命值：";
                break;

                case PropertyType.EnergyValue:
                propertyName="饥饿值：";
                break;

                case PropertyType.MentalValue:
                propertyName="精神值：";
                break;
                case PropertyType.SpeedValue:
                propertyName="速度：";
                break;
                case PropertyType.AttackValue:
                propertyName="攻击力：";
                break;

                default:
                break;
            }
            int sum=0;
            foreach(var item1 in item.Value)
            {
                sum+=item1.propertyValue;
            }
            AddProperty(propertyName+sum);
        }
        if(pa.weaponIcon!=null)
        {
            weaponIcon.sprite=pa.weaponIcon;
        }
    }
    private void ClearGrid()
    {
        foreach(Transform child in propertyGrid.transform)
        {
            if(child.gameObject.activeSelf)
            {
                Destroy(child.gameObject);
            }
        }
    }
    private void AddProperty(string propertyStr)
    {
        GameObject go = GameObject.Instantiate(propertyTemplate);
        go.SetActive(true);
        go.transform.parent=propertyGrid.transform;
        go.transform.Find("Property").GetComponent<TextMeshProUGUI>().text=propertyStr;
    }
}
