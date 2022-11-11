using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : BaseProjectile
{
    public BaseCharacter target;
    [SerializeField] float jarakTarget;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Zombie>();
    }

    public override void Shoot()
    {
        if(target == null)
        {
            OnDestroyed();
            return;
        }
        Vector3 goPos = target.transform.position - transform.position;
        goPos.y = 0;
        transform.position += goPos.normalized * projectileSpeed * Time.deltaTime;
        if (goPos.sqrMagnitude < jarakTarget)
        {
            OnDestroyed();
            target.TakDamage(projectileDamage);
        }
    }
}

