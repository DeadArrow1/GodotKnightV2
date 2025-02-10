using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class GameData : ScriptableObject
{
    //VALUES FOR INITIALIZING PLAYER AND REFERENCE FOR BASE FOR CALCULATING BONUSES
    public int StartingMaxHealth = 100;
    public int StartingArmor = 10;
    public int StartingDamage = 30;
    public int StartingNeededXP = 100;

    //VALUES FOR INITIALIZING PLAYER AND REFERENCE FOR BASE FOR CALCULATING BONUSES
    public bool PlayerUpdateVisual = false;

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

    public int HealingPotionsCount;

    public int AreaLevel = 1;

    public bool showUsePrompt = false;
    //GAMEPLAY VALUES END

    [SerializeField]
    public List<int> SkillTreeListSkillObtainedStatus;

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
            skillTooltip = "Tooltip for skillID " + skillPointID;
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

        Skills.Add(new SkillPoint(0, "+20 Max HP", 20, 0, 0, 0, 0, 0));


        Skills.Add(new SkillPoint(1, "+10 Armor", 0, 0, 0, 0, 10, 0));
        Skills.Add(new SkillPoint(2, "+10 Damage", 0, 0, 10, 0, 0, 0));

        Skills.Add(new SkillPoint(3, "+30 Max HP", 30, 0, 0, 0, 0, 0));
        Skills.Add(new SkillPoint(4, "+30 Max HP", 30, 0, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(5, "+15 Armor", 0, 0, 0, 0, 15, 0));
        Skills.Add(new SkillPoint(6, "+15 Armor", 0, 0, 0, 0, 15, 0));

        Skills.Add(new SkillPoint(7, "+20 Damage", 0, 0, 20, 0, 0, 0));
        Skills.Add(new SkillPoint(8, "+20 Damage", 0, 0, 20, 0, 0, 0));

        Skills.Add(new SkillPoint(9, "+50 Max HP", 50, 0, 0, 0, 0, 0));
        Skills.Add(new SkillPoint(10, "+50 Max HP", 50, 0, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(11, "+20 Armor", 0, 0, 0, 0, 20, 0));
        Skills.Add(new SkillPoint(12, "+20 Armor", 0, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(13, "+25 Damage", 0, 0, 25, 0, 0, 0));
        Skills.Add(new SkillPoint(14, "+25 Damage", 0, 0, 25, 0, 0, 0));

        Skills.Add(new SkillPoint(15, "Potions heal 25% more", 0, 0, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(16, "+5 % Max HP", 0, 5, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(17, "+20 HP,+20 Armor", 20, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(18, "+20 Armor", 0, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(19, "+20 Damage,+20 Armor", 0, 0, 20, 0, 20, 0));

        Skills.Add(new SkillPoint(20, "+20 Damage", 0, 0, 20, 0, 0, 0));

        Skills.Add(new SkillPoint(21, "+5% Chance for enemies to drop health potion", 0, 0, 0, 0, 0, 0));
        
        Skills.Add(new SkillPoint(22, "Potions heal additional 25 % more", 0, 0, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(23, "+5 % Max HP", 0, 5, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(24, "+20 HP,+20 Armor", 20, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(25, "+20 Armor", 0, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(26, "+20 Armor", 0, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(27, "+20 Damage,+20 Armor", 0, 0, 20, 0, 20, 0));

        Skills.Add(new SkillPoint(28, "+20 Damage", 0, 0, 20, 0, 0, 0));

        Skills.Add(new SkillPoint(29, "+5% Chance for enemies to drop health potion", 0, 0, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(30, "Potions heal additional 25 % more", 0, 0, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(31, "+5 % Max HP", 0, 5, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(32, "+20 HP,+20 Armor", 20, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(33, "+20 Armor", 0, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(34, "+20 Armor", 0, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(35, "+20 Damage,+20 Armor", 0, 0, 20, 0, 20, 0));

        Skills.Add(new SkillPoint(36, "+20 Damage", 0, 0, 20, 0, 0, 0));

        Skills.Add(new SkillPoint(37, "+5% Chance for enemies to drop health potion", 0, 0, 0, 0, 0, 0));
        Skills.Add(new SkillPoint(38, "Potions heal additional 25 % more + 10 % of Max HP", 0, 0, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(39, "+5 % Max HP", 0, 5, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(40, "+20 HP,+20 Armor", 20, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(41, "+20 Armor", 0, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(42, "+20 Armor", 0, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(43, "+20 Damage,+20 Armor", 0, 0, 20, 0, 20, 0));

        Skills.Add(new SkillPoint(44, "+20 Damage", 0, 0, 20, 0, 0, 0));

        Skills.Add(new SkillPoint(45, "+5% Chance for enemies to drop health potion, potions now drop in pair", 0, 0, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(46, "+5 % Max HP", 0, 5, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(47, "+20 Armor", 0, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(48, "+20 Armor", 0, 0, 0, 0, 20, 0));

        Skills.Add(new SkillPoint(49, "+20 Damage", 0, 0, 20, 0, 0, 0));

        Skills.Add(new SkillPoint(50, "+100 HP", 100, 0, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(51, "+10 % HP", 0, 10, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(52, "+20 % Armor", 0, 0, 0, 0, 0, 20));

        Skills.Add(new SkillPoint(53, "50 Damage", 0, 0, 50, 0, 0, 0));

        Skills.Add(new SkillPoint(54, "50 Armor", 0, 0, 0, 0, 50, 0));

        Skills.Add(new SkillPoint(55, "+100 HP", 100, 0, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(56, "+100 HP,+10 % HP", 100, 10, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(57, "50 Armor", 0, 0, 0, 0, 50, 0));

        Skills.Add(new SkillPoint(58, "+20 % Armor", 0, 0, 0, 0, 0, 20));

        Skills.Add(new SkillPoint(59, "50 Damage", 0, 0, 50, 0, 0, 0));

        Skills.Add(new SkillPoint(60, "+100 HP,+10 % HP", 100, 10, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(61, "+50 HP,+50 Damage", 100, 0, 50, 0, 0, 0));
        Skills.Add(new SkillPoint(62, "+100 HP,+10 % HP", 100, 10, 0, 0, 0, 0));
        Skills.Add(new SkillPoint(63, "50 Armor", 0, 0, 0, 0, 50, 0));

        Skills.Add(new SkillPoint(64, "+20 % Armor", 0, 0, 0, 0, 0, 20));

        Skills.Add(new SkillPoint(65, "+50 Armor,+20 % Armor", 0, 0, 0, 0, 50, 20));

        Skills.Add(new SkillPoint(66, "50 Damage", 0, 0, 50, 0, 0, 0));

        Skills.Add(new SkillPoint(67, "+100 HP", 100, 0, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(68, "+10 % HP", 0, 10, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(69, "50 Armor", 0, 0, 0, 0, 50, 0));

        Skills.Add(new SkillPoint(70, "+50 Armor,+20 % Armor", 0, 0, 0, 0, 50, 20));

        Skills.Add(new SkillPoint(71, "50 Damage", 0, 0, 50, 0, 0, 0));

        Skills.Add(new SkillPoint(72, "+200 HP,+20 % HP", 100, 20, 0, 0, 0, 0));

        Skills.Add(new SkillPoint(73, "+100 % Armor", 0, 0, 0, 0, 0, 100));

        Skills.Add(new SkillPoint(74, "+50 % Damage", 0, 0, 0, 50, 0, 0));

        int currentCount = Skills.Count;
        for (int i = currentCount; i <= 74; i++)
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

        SkillTreeListSkillPrerequsities.Add("-1");//0
        SkillTreeListSkillPrerequsities.Add("-1");//1 
        SkillTreeListSkillPrerequsities.Add("-1");//2

        SkillTreeListSkillPrerequsities.Add("0");//3
        SkillTreeListSkillPrerequsities.Add("0");//4
        SkillTreeListSkillPrerequsities.Add("1");//5
        SkillTreeListSkillPrerequsities.Add("1");//6
        SkillTreeListSkillPrerequsities.Add("2");//7
        SkillTreeListSkillPrerequsities.Add("2");//8


        SkillTreeListSkillPrerequsities.Add("3");//9
        SkillTreeListSkillPrerequsities.Add("4");//10



        SkillTreeListSkillPrerequsities.Add("5");//11
        SkillTreeListSkillPrerequsities.Add("6");//12
        SkillTreeListSkillPrerequsities.Add("7");//13
        SkillTreeListSkillPrerequsities.Add("8");//14
        SkillTreeListSkillPrerequsities.Add("9");//15
        SkillTreeListSkillPrerequsities.Add("9,10");//16
        SkillTreeListSkillPrerequsities.Add("10,11");//17
        SkillTreeListSkillPrerequsities.Add("11,12");//18
        SkillTreeListSkillPrerequsities.Add("12,13");//19
        SkillTreeListSkillPrerequsities.Add("13,14");//20

        SkillTreeListSkillPrerequsities.Add("14");//21
        SkillTreeListSkillPrerequsities.Add("15");//22
        SkillTreeListSkillPrerequsities.Add("16");//23
        SkillTreeListSkillPrerequsities.Add("17");//24
        SkillTreeListSkillPrerequsities.Add("18");//25
        SkillTreeListSkillPrerequsities.Add("18");//26
        SkillTreeListSkillPrerequsities.Add("19");//27
        SkillTreeListSkillPrerequsities.Add("20");//28
        SkillTreeListSkillPrerequsities.Add("21");//29
        SkillTreeListSkillPrerequsities.Add("22");//30

        SkillTreeListSkillPrerequsities.Add("23");//31
        SkillTreeListSkillPrerequsities.Add("24");//32
        SkillTreeListSkillPrerequsities.Add("25");//33
        SkillTreeListSkillPrerequsities.Add("26");//34
        SkillTreeListSkillPrerequsities.Add("27");//35
        SkillTreeListSkillPrerequsities.Add("28");//36
        SkillTreeListSkillPrerequsities.Add("29");//37
        SkillTreeListSkillPrerequsities.Add("30");//38
        SkillTreeListSkillPrerequsities.Add("31");//39
        SkillTreeListSkillPrerequsities.Add("32");//40

        SkillTreeListSkillPrerequsities.Add("33");//41-50
        SkillTreeListSkillPrerequsities.Add("34");//42
        SkillTreeListSkillPrerequsities.Add("35");//43
        SkillTreeListSkillPrerequsities.Add("36");//44
        SkillTreeListSkillPrerequsities.Add("37");//45
        SkillTreeListSkillPrerequsities.Add("39");//46
        SkillTreeListSkillPrerequsities.Add("41");//47
        SkillTreeListSkillPrerequsities.Add("42");//48
        SkillTreeListSkillPrerequsities.Add("44");//49
        SkillTreeListSkillPrerequsities.Add("46");//50

        SkillTreeListSkillPrerequsities.Add("46");//51
        SkillTreeListSkillPrerequsities.Add("47,48");//52
        SkillTreeListSkillPrerequsities.Add("49");//53
        SkillTreeListSkillPrerequsities.Add("49");//54
        SkillTreeListSkillPrerequsities.Add("50,56");//55
        SkillTreeListSkillPrerequsities.Add("55,57");//56
        SkillTreeListSkillPrerequsities.Add("56,51");//57
        SkillTreeListSkillPrerequsities.Add("52");//58
        SkillTreeListSkillPrerequsities.Add("53,60");//59
        SkillTreeListSkillPrerequsities.Add("59,61");//60

        SkillTreeListSkillPrerequsities.Add("60,54");//61
        SkillTreeListSkillPrerequsities.Add("55");//62
        SkillTreeListSkillPrerequsities.Add("57");//63
        SkillTreeListSkillPrerequsities.Add("58");//64
        SkillTreeListSkillPrerequsities.Add("59");//65
        SkillTreeListSkillPrerequsities.Add("61");//66
        SkillTreeListSkillPrerequsities.Add("62");//67
        SkillTreeListSkillPrerequsities.Add("63");//68
        SkillTreeListSkillPrerequsities.Add("64");//69
        SkillTreeListSkillPrerequsities.Add("65");//70

        SkillTreeListSkillPrerequsities.Add("66");//71
        SkillTreeListSkillPrerequsities.Add("67,68");//72
        SkillTreeListSkillPrerequsities.Add("69");//73
        SkillTreeListSkillPrerequsities.Add("70,71");//74








        /*int currentCount = SkillTreeListSkillPrerequsities.Count;
        for (int i = 0; i <= 74 - currentCount; i++)
        {
            SkillTreeListSkillPrerequsities.Add("-1");
        }*/


    }

    public bool isDead;
    public void ResetPlayer()
    {
        isDead = false;
        showUsePrompt = false;
        _playerLevel = 1;
        _damage = StartingDamage;
        _maxHealth = StartingMaxHealth;
        _currentHealth = StartingMaxHealth;
        _armor = StartingArmor;

        _neededXP = StartingNeededXP;
        _currentXP = 0;
        SkillpointCount = 100;
        HealingPotionsCount = 3;
        AreaLevel = 1;

        DamageBonusFromEncounters=0;
        HealthBonusFromEncounters=0;
        ArmorBonusFromEncounters=0;

        CreateSkillPoints();
        ResetSkillTree();
        GeneratePrerequisities();


        Inventory.Clear();
        itemID = 0;
        //single image
        Inventory.Add(new Item(0,"Cavalier Helmet", ItemSlot.Helmet, "GameSIzeAssets/ArmorSets/Cavalier/Head", "GameSIzeAssets/ArmorSets/Cavalier/Head"));
        Inventory.Add(new Item(1,"Cavalier Chest", ItemSlot.Chest, "GameSIzeAssets/ArmorSets/Cavalier/Chest", "GameSIzeAssets/ArmorSets/Cavalier/Chest"));
        //single

        //pair
        Inventory.Add(new Item(2,"Cavalier Shoulders", ItemSlot.Shoulders, "GameSIzeAssets/ArmorSets/Cavalier/RightUpperArm", "GameSIzeAssets/ArmorSets/Cavalier/RightUpperArm"));
        Inventory.Add(new Item(3,"Cavalier Gauntlets", ItemSlot.Gauntlets, "GameSIzeAssets/ArmorSets/Cavalier/RightLowerArm", "GameSIzeAssets/ArmorSets/Cavalier/RightLowerArm"));

        Inventory.Add(new Item(4,"Cavalier Leggins", ItemSlot.Leggins, "GameSIzeAssets/ArmorSets/Cavalier/RightUpperLeg", "GameSIzeAssets/ArmorSets/Cavalier/RightUpperLeg"));


        Inventory.Add(new Item(5,"Cavalier Boots", ItemSlot.Boots, "GameSIzeAssets/ArmorSets/Cavalier/RightLowerLeg", "GameSIzeAssets/ArmorSets/Cavalier/RightLowerLeg"));

        //TEST DELETE LATER
        //Inventory.Add(new Item(6, "Cavalier Helmet2", ItemSlot.Helmet, "GameSIzeAssets/ArmorSets/Cavalier/Chest", "GameSIzeAssets/ArmorSets/Cavalier/Chest"));
    }

    public void DetectLevelUp()
    {
        if (CurrentXP >= NeededXP)
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
        int bonusDamagePercent = 100;
        int bonusHealth = 0;
        int bonusHealthPercent = 100;
        int bonusArmor = 0;
        int bonusArmorPercent = 100;
        for (int index = 0; index < SkillTreeListSkillObtainedStatus.Count; index++)
        {
            bonusHealth += Skills[index].bonusHP * SkillTreeListSkillObtainedStatus[index];
            bonusDamage += Skills[index].bonusDmg * SkillTreeListSkillObtainedStatus[index];
            bonusArmor += Skills[index].bonusArmor * SkillTreeListSkillObtainedStatus[index];


            bonusHealthPercent += Skills[index].bonusHPPercent * SkillTreeListSkillObtainedStatus[index];
            bonusDamagePercent += Skills[index].bonusDmgPercent * SkillTreeListSkillObtainedStatus[index];
            bonusArmorPercent  += Skills[index].bonusArmorPercent * SkillTreeListSkillObtainedStatus[index];
        }

        _damage = (int)Mathf.Round((float)((StartingDamage + bonusDamage+ DamageBonusFromEncounters) * bonusDamagePercent/100.0));
        _maxHealth = (int)Mathf.Round((float)((StartingMaxHealth + bonusHealth + HealthBonusFromEncounters) * bonusHealthPercent/100.0));
        _armor = (int)Mathf.Round((float)((StartingArmor + bonusArmor + ArmorBonusFromEncounters) * bonusArmorPercent/100.0));
    }

    //ENCOUNTER CONTROLS
    [System.Serializable]
    public class EncounterRewards
    {
        public string rewardName;
        public string description;
        public int bonusHP;
        public int bonusDmg;

        public int bonusArmor;


        public EncounterRewards(string RewardName, string Description, int BonusHP,  int BonusDmg,  int BonusArmor)
        {
            rewardName = RewardName;
            description = Description;
            bonusHP = BonusHP;
            bonusDmg = BonusDmg;
            bonusArmor = BonusArmor;
        }

    }


    public int DamageBonusFromEncounters;
    public int HealthBonusFromEncounters;
    public int ArmorBonusFromEncounters;

    public bool encounterStarted;
    public bool encounterEnded;
    public int countEnemiesInEncounter;
    public void resetEncounterSettings()
    {   
        encounterStarted=false;
        encounterEnded = false;
        countEnemiesInEncounter = 0;
        RolledRewards.Clear();
}
    [SerializeField]
    public List<EncounterRewards> EncounterRewardsOptions;

    public List<int> RolledRewards;

    public int SelectedRewardIndex;
    public void prepareEncounters()
    {
        EncounterRewardsOptions.Clear();
        EncounterRewardsOptions.Add(new EncounterRewards ("Tenacity", "+10 Health", 10,0,0)); //Add hp
        EncounterRewardsOptions.Add(new EncounterRewards("Power", "+10 Damage", 0,10,0)); //Add damage
        EncounterRewardsOptions.Add(new EncounterRewards("Protection", "+10 Armor", 0,0,10)); //Add armor

        EncounterRewardsOptions.Add(new EncounterRewards("BONUS HP", "reward0", 10, 0, 0)); //Add hp
        EncounterRewardsOptions.Add(new EncounterRewards("BONUS DMG", "reward1", 0, 10, 0)); //Add damage
        EncounterRewardsOptions.Add(new EncounterRewards("BONUS ARMOR", "reward2", 0, 0, 10)); //Add armor

    }


    #region Inventory

    public enum ItemSlot
    {
        Helmet,
        Shoulders,
        Gauntlets,
        Chest,
        Leggins,
        Boots,
        Undefined
    }

    int itemID=0;

    [System.Serializable]
    public class Item
    {
        public int uniqueID;
        public  string name;
        public  ItemSlot slot;
        public  string imagePath;
        public string imagePathInventory;

        public Item(int UniqueID,string Name, ItemSlot Slot, string ImagePath, string ImagePathInventory)
        {
            uniqueID = UniqueID;
            name = Name;
            slot = Slot;
            imagePath = ImagePath;
            imagePathInventory = ImagePathInventory;
        }      
    }
    #endregion
    [SerializeField]
    public List<Item> Inventory;

   
    /*[SerializeField]
    public List<Equipment> EquipmentItems;*/
}
