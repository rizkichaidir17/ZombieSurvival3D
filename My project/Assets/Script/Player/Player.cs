using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseCharacter
{


    public override void Move()
    {
        if (!isDead && currentHp > 0)
        {
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector3 movDirection = new Vector3(horizontalInput, 0, verticalInput);
            charController.Move(movDirection.normalized * movementSpeed * Time.deltaTime);

            if (movDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationtSpeed * Time.deltaTime);
                CharAnimator.SetBool("IsRun", true);
            }

            else
            {
                CharAnimator.SetBool("IsRun", false);
            }

        }
    }
   
    public override void Attack()
    {
        CharAnimator.SetTrigger("IsAttack");
    }

    #region Player Mati
    public override void Dead()
    {
        base.Dead();
        this.enabled = false;
        Time.timeScale = 0;
        UiManager.ins.gameOverPanel.SetActive(true);
    }
    #endregion
}
