using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class GameData : ScriptableObject
{
    //VALUES FOR INITIALIZING PLAYER AND REFERENCE FOR BASE FOR CALCULATING BONUSES
    public int StartingMaxHealth=100;
    public int StartingArmor=10;
    public int StartingDamage=30;
    public int StartingNeededXP = 100;

    //VALUES FOR INITIALIZING PLAYER AND REFERENCE FOR BASE FOR CALCULATING BONUSES


    //GAMEPLAY VALUES
    #region PlayerHealth
    [SerializeField]
    private int _maxHealth;

    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }


    [SerializeField]
    private int _currentHealth;

    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }
    #endregion

    #region PlayerXP
    [SerializeField]
    private int _neededXP;

    public int NeededXP
    {
        get { return _neededXP; }
        set { _neededXP = value; }
    }


    [SerializeField]
    private int _currentXP;

    public int CurrentXP
    {
        get { return _currentXP; }
        set { _currentXP = value; }
    }
    #endregion

    #region damage
    [SerializeField]
    private int _damage;

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    #endregion damage

    #region Armor
    [SerializeField]
    private int _armor;

    public int Armor
    {
        get { return _armor; }
        set { _armor = value; }
    }
    #endregion

    #region PlayerLevel
    [SerializeField]
    private int _playerLevel;

    public int PlayerLevel
    {
        get { return _playerLevel; }
        set { _playerLevel = value; }
    }
    #endregion

    public int SkillpointCount;

    public int AreaLevel = 1;

    public bool showUsePrompt = false;
    //GAMEPLAY VALUES END

    [SerializeField]
    public  List<int> SkillTreeListSkillObtainedStatus;

    [System.Serializable]
    public class SkillPoint
    {
        public int skillPointID;
        public string skillTooltip;

        public int bonusHP;
        public int bonusHPPercent;

        public int bonusDmg;
        public int bonusDmgPercent;

        public int bonusArmor;
        public int bonusArmorPercent;

        public SkillPoint(int SkillPointID, string SkillTooltip, int BonusHP, int BonusHPPercent, int BonusDmg, int BonusDmgPercent, int BonusArmor, int BonusArmorPercent)
        {
            skillPointID = SkillPointID;
            skillTooltip = SkillTooltip;
            bonusHP = BonusHP;
            bonusHPPercent = BonusHPPercent;
            bonusDmg = BonusDmg;
            bonusDmgPercent = BonusDmgPercent;
            bonusArmor = BonusArmor;
            bonusArmorPercent = BonusArmorPercent;
        }

        public SkillPoint(int SkillPointID, int BonusHP, int BonusHPPercent, int BonusDmg, int BonusDmgPercent, int BonusArmor, int BonusArmorPercent)
        {
            skillPointID = SkillPointID;
            skillTooltip = "Tooltip for skillID "+ skillPointID;
            bonusHP = BonusHP;
            bonusHPPercent = BonusHPPercent;
            bonusDmg = BonusDmg;
            bonusDmgPercent = BonusDmgPercent;
            bonusArmor = BonusArmor;
            bonusArmorPercent = BonusArmorPercent;
        }

        public SkillPoint(int SkillPointID)
        {
            skillPointID = SkillPointID;
            skillTooltip = "Tooltip for skillID " + skillPointID;
            bonusHP = 0;
            bonusHPPercent = 0;
            bonusDmg = 0;
            bonusDmgPercent = 0;
            bonusArmor = 0;
            bonusArmorPercent = 0;
        }
    }

    [SerializeField]
    public List<SkillPoint> Skills;
    
    public void CreateSkillPoints()
    {
        Skills.Clear();

        Skills.Add(new SkillPoint(0,"+50 Max HP",50,0,0,0,0,0));



        int currentCount = Skills.Count;
        for (int i = currentCount-1; i <= 74 - currentCount; i++)
        {
            SkillPoint skillpoint = new SkillPoint(i);

            Skills.Add(skillpoint);
        }
    }

    public void ResetSkillTree()
    {
        SkillTreeListSkillObtainedStatus.Clear();
        for (int i = 0; i <= 74; i++)
        {
            SkillTreeListSkillObtainedStatus.Add(0);
           
        }
    }

    [SerializeField]
    public List<string> SkillTreeListSkillPrerequsities;
    public void GeneratePrerequisities()
    {
        SkillTreeListSkillPrerequsities.Clear();

        SkillTreeListSkillPrerequsities.Add("-1");
        SkillTreeListSkillPrerequsities.Add("-1"); //FIRST ROW
        SkillTreeListSkillPrerequsities.Add("-1");

        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("1");//SECOND ROW
        SkillTreeListSkillPrerequsities.Add("1");
        SkillTreeListSkillPrerequsities.Add("2");
        SkillTreeListSkillPrerequsities.Add("2");


        SkillTreeListSkillPrerequsities.Add("3");
        SkillTreeListSkillPrerequsities.Add("4");
        SkillTreeListSkillPrerequsities.Add("5");
        SkillTreeListSkillPrerequsities.Add("6");//THIRD ROW
        SkillTreeListSkillPrerequsities.Add("7");
        SkillTreeListSkillPrerequsities.Add("8");

        int currentCount = SkillTreeListSkillPrerequsities.Count;
        for (int i = 0; i <= 74-currentCount; i++)
        {
            SkillTreeListSkillPrerequsities.Add("-1");
        }


    }

    public void ResetPlayer()
    {

        showUsePrompt = false;
        _playerLevel = 1;
        _damage = StartingDamage;
        _maxHealth = StartingMaxHealth;
        _currentHealth = StartingMaxHealth;
        _armor = StartingArmor;

        _neededXP = StartingNeededXP;
        _currentXP = 0;
        SkillpointCount = 5;
         
        AreaLevel = 1;
        CreateSkillPoints();
        ResetSkillTree();
        GeneratePrerequisities();
    }

    public void DetectLevelUp()
    {
        if(CurrentXP>= NeededXP)
        {
            CurrentXP = CurrentXP - NeededXP;
            NeededXP = NeededXP * 2;
            SkillpointCount = SkillpointCount + 1;
            PlayerLevel += 1;
        }
    }

    public void RecalculateStats()
    {
        int bonusDamage = 0;
        int bonusDamagePercent = 1;
        int bonusHealth = 0;
        int bonusHealthPercent = 1;
        int bonusArmor = 0;
        int bonusArmorPercent = 1;
        for (int index=0;index < SkillTreeListSkillObtainedStatus.Count;index++)
        {
            
            bonusHealth += Skills[index].bonusHP;
            bonusHealthPercent += Skills[index].bonusHPPercent;

            bonusDamage += Skills[index].bonusDmg;
            bonusDamagePercent += Skills[index].bonusDmgPercent;

            bonusArmor += Skills[index].bonusArmor;
            bonusArmorPercent += Skills[index].bonusArmorPercent;
        }

        _damage = (StartingDamage + bonusDamage) * bonusDamagePercent;
        _maxHealth = (StartingMaxHealth + bonusHealth) * bonusHealthPercent;
        _armor = (StartingArmor + bonusArmor) * bonusArmorPercent;
    }
}
