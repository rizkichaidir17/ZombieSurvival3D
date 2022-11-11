using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    protected int level = 1;
    [SerializeField] protected float skillCooldown;
    [SerializeField] protected float skillActiveTime;
    public string skillName;
    public string skillDescription;
   

    public abstract void ActivateSkill();
    public abstract void OnLevelUp();
}
