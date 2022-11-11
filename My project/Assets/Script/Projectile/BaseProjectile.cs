using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected int projectileDamage;

    public virtual void Shoot()
    {
        
    }

    public virtual void OnDestroyed()
    {
        gameObject.SetActive(false);
    }

    public virtual void Update()
    {
        Shoot();
    }
}
