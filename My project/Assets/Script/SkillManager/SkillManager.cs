using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Runtime.UIManager.Animators;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using TMPro;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public List<BaseSkill> availableSkills = new List<BaseSkill>();
    List<BaseSkill> currentActiveSkills = new List<BaseSkill>();
    Player player;

    public UIContainerUIAnimator container;

    public SkillBottonUI skillBottonUIPrefab;
    public Transform skillButtonSpawnTransform;

    [SerializeField] Image xpBar;
    [SerializeField] TMP_Text _xpText;

    int level = 1; 
    int currentExp = 0;
    int nextExpToLevelUp = 25;
    
    public void AddExp(int exp)
    {
        currentExp += exp;

        var nextexplevelup = nextExpToLevelUp * level;
        if (currentExp > nextexplevelup)
        {
            ShowAvaiilableSkills();
            currentExp = 0;
            level++;
        }
        xpBar.fillAmount = ((float)currentExp / (float)nextexplevelup);
        _xpText.text = ((float)currentExp + "/" + (float)nextexplevelup).ToString();
    }

    private void Awake()
    {
        
        instance = this;
        player = GameObject.FindObjectOfType<Player>();
        IniAvailableSkill();
       
    }

    // Start is called before the first frame update
       
    void Start()
    {
        _xpText.text = ((float)currentExp + "/" + nextExpToLevelUp).ToString();
        xpBar.fillAmount = 0;
        ShowAvaiilableSkills();
    }
    private void Update()
    {
       
    }
    private void IniAvailableSkill()

    {
        foreach (var sk in availableSkills)
        {
            var btn = Instantiate(skillBottonUIPrefab, skillButtonSpawnTransform);
            btn.skillToAdd = sk;
            btn.Init();
        }
    }

    public void AddSkill(BaseSkill skill)
    {
        var find = currentActiveSkills.Find(x => x.skillName == skill.skillName);
        if(find != null)
        {
            find.OnLevelUp();
        }
        else
        {
            var skillClone = Instantiate(skill, player.transform);
            currentActiveSkills.Add(skillClone);
        }
        HideAvailableSkills();
      

    }

    private void HideAvailableSkills()
    {
        container.Hide();
        Time.timeScale = 1;
    }

    private void ShowAvaiilableSkills()
    {
        container.Show();
        Time.timeScale = 0;
    }
}
