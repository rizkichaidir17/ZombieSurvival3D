using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMeteor : ActiveSkill
{
    [SerializeField] GameObject meteorMissile;
    [SerializeField] float scaleUp;

    public override void ActivateSkill()
    {
        
    }

    public override void OnLevelUp()
    {
        base.OnLevelUp();
        scaleUp += 0.2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var mm = Instantiate(meteorMissile);
            mm.transform.position = transform.position + new Vector3(0, 20, 0);
            mm.transform.localScale = new Vector3(mm.transform.localScale.x * scaleUp, mm.transform.localScale.y * scaleUp, mm.transform.localScale.z * scaleUp);
        }
    }
}
