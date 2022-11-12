using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMissle : ActiveSkill
{
    float coolDownTime;
    float activeTime;
    [SerializeField] HomingProjectile homeMissile;
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
        //if (targetEnemy != null) return;
        float disctanceToCloseEnemy = Mathf.Infinity;
        Zombie enemy = null;
        Zombie[] allEnemy = GameObject.FindObjectsOfType<Zombie>();

        foreach (Zombie currentEnemy in allEnemy)
        {
            if (currentEnemy.isDead) continue;
            Vector3 distanceToEnemy = (currentEnemy.transform.position - transform.position);
            if (distanceToEnemy.sqrMagnitude < disctanceToCloseEnemy)
            {
                disctanceToCloseEnemy = distanceToEnemy.sqrMagnitude;
                enemy = currentEnemy;
            }
        }
        targetEnemy = enemy;
        
        //if (targetEnemy != null) return;
        //var cekEmey = GameObject.FindGameObjectWithTag("Enemy");
        //if (cekEmey != null) targetEnemy = cekEmey.GetComponent<Zombie>();
    }

    public override void ActivateSkill()
    {
        if (targetEnemy == null) return;
        var prj = Instantiate(homeMissile);
        prj.transform.position = transform.position + Vector3.forward;
        prj.target = targetEnemy;
    }

    public override void OnLevelUp()
    {
        base.OnLevelUp();
        var prj = homeMissile.GetComponent<HomingProjectile>();
        prj.projectileDamage += 10;
    }
}
