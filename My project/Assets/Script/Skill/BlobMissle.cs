using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMissle : ActiveSkill
{
    float coolDownTime;
    float activeTime;
    [SerializeField] GameObject homeMissile;
    public Zombie targetEnemy;
   
    enum AbilityState
    {
        ready,
        active,
        cooldown,
    }

    AbilityState state = AbilityState.ready;


    // Update is called once per frame
   public override void Update()
    {
        FindTarget();
        switch (state)
        {
            case AbilityState.ready:
                    ActivateSkill();
                    state = AbilityState.active;
                    activeTime = skillActiveTime;
               break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    coolDownTime = skillCooldown;
                }
                break;
            case AbilityState.cooldown:
                if (coolDownTime < 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }
    }
    public void FindTarget()
    {
        float disctanceToCloseEnemy = Mathf.Infinity;
        Zombie enemy = null;
        Zombie[] allEnemy = GameObject.FindObjectsOfType<Zombie>();

        foreach (Zombie currentEnemy in allEnemy)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy < disctanceToCloseEnemy)
            {
                disctanceToCloseEnemy = distanceToEnemy;
                enemy = currentEnemy;
            }
        }

        //if (targetEnemy != null) return;
        //var cekEmey = GameObject.FindGameObjectWithTag("Enemy");
        //if(cekEmey != null)targetEnemy = cekEmey.GetComponent<Zombie>();
    }

    public override void ActivateSkill()
    {
        if (targetEnemy != null)
            Instantiate(homeMissile, transform.position, Quaternion.identity);
    }

    public override void OnLevelUp()
    {
        base.OnLevelUp();
        skillActiveTime -= 1;

    }
}
