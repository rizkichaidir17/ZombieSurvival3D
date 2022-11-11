using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobOrb : ActiveSkill
{
    public RotatingProjectile projectile;
    public List<RotatingProjectile> spawnedProjectiles = new List<RotatingProjectile>();
    public int maxOrb;
    


   
    public override void ActivateSkill()
    {
        base.ActivateSkill();
        if(spawnedProjectiles.Count < maxOrb)
        {
            var obj = Instantiate(projectile);
            obj.rotateAround = transform;
            obj.transform.position = transform.position + Vector3.forward;
            spawnedProjectiles.Add(obj);

            if(spawnedProjectiles.Count > 0)
            {
                int i = 1;
                foreach (RotatingProjectile orb in spawnedProjectiles)
                {
                    orb.angle = 6.29f / spawnedProjectiles.Count * i;
                    i++;
                }
            }
        }
    }
    public override void OnLevelUp()
    {
        base.OnLevelUp();
        maxOrb += 1;
        //projectile.targetDistance += 1;
    }
}
