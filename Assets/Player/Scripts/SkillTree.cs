using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Linq;

public class SkillTree : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    [SerializeField] private Button confirmButton;

    private List<int> CurrentlyObtainedSkills;

    private bool AudioEnabled = false;

    // Update is called once per frame
    void OnEnable()
    {
        Debug.Log("SkillTreeOnEnable called");

        //LOAD STATE OF SKILLS

        CurrentlyObtainedSkills = new List<int>(gameData.SkillTreeListSkillObtainedStatus);

        //DISPLAY CURRENT STATE OF SKILL TREE

        AudioEnabled = false;
        EvaluateSkills();
        SetToggles();
        AudioEnabled = true;
    }


    private void EvaluateSkills()
    {
        Transform parent = gameObject.transform;

        List<int> SkillPrerequisities = new List<int>();
        int index = 0;

        ShowConfirmButton();

        //SET TOGGLE,COLOR,DISABLED, ENABLED SKILLS
        foreach (Transform child in parent)
        {

            int obtained = CurrentlyObtainedSkills[index];


            Toggle toggle = (Toggle)child.gameObject.GetComponent("Toggle");


            #region Setting the sama color to selected so we LOSE selected
            var colors = toggle.colors;
            colors.selectedColor = colors.normalColor;
            toggle.colors = colors;
            #endregion



            #region loading prerequisities for this skill
            SkillPrerequisities.Clear();
            string[] sPrerequisities = gameData.SkillTreeListSkillPrerequsities[index].Split(",");

            foreach (string s in sPrerequisities)
            {
                SkillPrerequisities.Add(int.Parse(s));
            }
            #endregion

            //setting this skill to non interactable and then we will enable only if eligible
            toggle.interactable = false;

            bool SkillIsAvailable = true;
            foreach (int requiredSkillIndex in SkillPrerequisities)
            {
                if (requiredSkillIndex == -1)
                {

                }
                else if (CurrentlyObtainedSkills[requiredSkillIndex] == 1) 
                {


                }
                else
                {
                    SkillIsAvailable = false;
                    toggle.isOn = false;
                }

            }




            if (CurrentlyObtainedSkills[index] == 0 && SkillIsAvailable == true || CurrentlyObtainedSkills[index] == 1 && gameData.SkillTreeListSkillObtainedStatus[index] ==0)
            {
                toggle.interactable = true;
            }
            index++;
        }
    }

    private void SetToggles()
    {
        Transform parent = gameObject.transform;
        int index = 0;


        //SET TOGGLE,COLOR,DISABLED, ENABLED SKILLS
        foreach (Transform child in parent)
        {
            
            Toggle toggle = (Toggle)child.gameObject.GetComponent("Toggle");

            if (gameData.SkillTreeListSkillObtainedStatus[index] == 1 && toggle.isOn != true)
            {
                toggle.isOn = true;
            }
            if (gameData.SkillTreeListSkillObtainedStatus[index] == 0 && toggle.isOn != false)
            {
                toggle.isOn = false;
            }
            index++;
        }



    }
    public void ToggleChanged(Toggle skill)
    {
        int skillNumber = -1;

        string resultString = Regex.Match(skill.gameObject.name, @"\d+").Value;
        int.TryParse(resultString, out skillNumber);
        if (AudioEnabled)
        {
            var skillpointsound = gameObject.GetComponent<AudioSource>();
            skillpointsound.Play();
        }


        if (skillNumber > -1)
        {
            if (skill.isOn)
            {
                CurrentlyObtainedSkills[skillNumber] = 1;
                EvaluateSkills();
            }
            else 
            {
                CurrentlyObtainedSkills[skillNumber] = 0;
                EvaluateSkills();
            }
        }

    }

    private void ShowConfirmButton()
    {

        if (CurrentlyObtainedSkills.SequenceEqual(gameData.SkillTreeListSkillObtainedStatus))
        {
            confirmButton.gameObject.SetActive(false);
        }
        else
        {
            confirmButton.gameObject.SetActive(true);
        }

    }

    public void confirmSkillPoints()
    {
        if (AudioEnabled)
        {
            var skillpointsound = gameObject.GetComponent<AudioSource>();
            skillpointsound.Play();
        }
        gameData.SkillTreeListSkillObtainedStatus = new List<int>(CurrentlyObtainedSkills);
        EvaluateSkills();
    }
}
