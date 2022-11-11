using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActiveSkill : BaseSkill
{

    private float _currentCoolDown;


    public override void ActivateSkill()
    {
        
    }

    public override void OnLevelUp()
    {
        print(this);
        level++;
    }

    public void ReduceCoolDown()
    {
        if(_currentCoolDown > 0)
        {
            _currentCoolDown -= Time.deltaTime;
        }
        else
        {
            _currentCoolDown = skillCooldown;
            ActivateSkill();
        }
    }

    public virtual void Update()
    {
        ReduceCoolDown();
    }


}
