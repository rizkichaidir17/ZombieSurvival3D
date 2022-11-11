using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : BaseCharacter
{

    public Transform posisiPlayer;
    public Player targetPlayer;
    public float attackSpeed;
    float currentAttackSpeed;


    private void Awake()
    {
        posisiPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        currentAttackSpeed = attackSpeed;
    }

   public override void Move()
    {
        if(!isDead)
        { 
            if (targetPlayer != null && !targetPlayer.isDead)
            { 
                if(Vector3.Distance(posisiPlayer.position, transform.position) >= attackDistance)
                {
                    Vector3 movDir = targetPlayer.transform.position - transform.position;
                    charController.Move(movDir.normalized * movementSpeed * Time.deltaTime);
                    Quaternion toRotation = Quaternion.LookRotation(movDir.normalized, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationtSpeed * Time.deltaTime);
                    CharAnimator.SetBool("IsRun", true);
                
                }
                else
                {
                    Attack();
                }
            

            }
            else
            {
                FindTarget();
            }
        }
    }

    public void FindTarget()
    {
        if (targetPlayer != null) return;
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    
    public override void Attack()
    {
        if(currentAttackSpeed > 0)
        {
            currentAttackSpeed -= Time.deltaTime;
            CharAnimator.SetBool("IsRun", false);
        }
        else
        {
            currentAttackSpeed = attackSpeed;
            targetPlayer.TakDamage(damage);
            CharAnimator.SetTrigger("IsAttack");
            CharAnimator.SetBool("IsRun", false);
        }
        
    }


    public override void Dead()
    {
        SkillManager.instance.AddExp(25);
        this.enabled = false;
        CharAnimator.SetTrigger("IsDead");
        Invoke("Destroy", 2);
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
