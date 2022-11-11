using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingProjectile : BaseProjectile
{
    public Transform rotateAround;
    public float targetDistance;
    Vector3 offset;
    Vector3 lookAt;
    public float angle;
    float sgrRange;
    public Vector3 axis = new Vector3(0, 1, 0);

    public override void Shoot()
    {
        
        angle += projectileSpeed * Time.deltaTime;
        if(offset != null)
        {
            offset = new Vector3(Mathf.Sin(angle) * targetDistance, 1, Mathf.Cos(angle) * targetDistance);
            
        }
        transform.position = rotateAround.position + offset;
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        { 
            Debug.Log("Enemy Hit");
            var enemy = other.gameObject.GetComponent<Zombie>();
            if (enemy != null)
            {
                enemy.TakDamage(projectileDamage);
            }
        }
    }
}
