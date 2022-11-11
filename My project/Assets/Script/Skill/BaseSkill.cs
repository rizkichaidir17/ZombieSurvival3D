using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSkill : MonoBehaviour
{
    protected int level = 1;
    [SerializeField] protected float skillCooldown;
    [SerializeField] protected float skillActiveTime;
    public string skillName;
    public string skillDescription;
    public Image skillImage;
//    public Texture2D imageTexture;



    public abstract void ActivateSkill();
    public abstract void OnLevelUp();
}
