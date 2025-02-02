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
    [SerializeField]
    public  List<int> SkillTreeListSkillObtainableStatus;


    public void ResetSkillTree()
    {
        SkillTreeListSkillObtainedStatus.Clear();
        SkillTreeListSkillObtainableStatus.Clear();
        for (int i = 0; i <= 76; i++)
        {
            SkillTreeListSkillObtainedStatus.Add(0);
            SkillTreeListSkillObtainableStatus.Add(0);
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

        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); 
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0"); SkillTreeListSkillPrerequsities.Add("0");
        SkillTreeListSkillPrerequsities.Add("0");


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
        }
    }

}
