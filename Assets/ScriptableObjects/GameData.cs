using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class GameData : ScriptableObject
{
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



}
