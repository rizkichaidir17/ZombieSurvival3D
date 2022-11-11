using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Doozy.Runtime.UIManager.Components;

public class SkillBottonUI : MonoBehaviour
{
    public UIButton button;
    public BaseSkill skillToAdd;
    public TMP_Text label;
    public void Init()
    {
        button.AddBehaviour(Doozy.Runtime.UIManager.UIBehaviour.Name.PointerClick).Event.AddListener(() => SkillManager.instance.AddSkill(skillToAdd));
        label.text = skillToAdd.name +  " Level Up";
    }
}
