using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorProjectile : BaseProjectile
{
    public BaseCharacter target;

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
        /*Vector3 ground = transform.position;
        ground.y = 0;*/

        Vector3 goPos = target.transform.position - transform.position;

        transform.position += goPos.normalized * projectileSpeed * Time.deltaTime;

        if (transform.position.y <= 0)
        {
            OnDestroyed();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Zombie enemy = other.gameObject.GetComponent<Zombie>();
        if (enemy != null && !enemy.isDead) enemy.TakDamage(projectileDamage);
    }
}
