using UnityEngine;
using UnityEngine.UI;

public abstract class BaseCharacter : MonoBehaviour
{
    public CharacterController charController;
    public Animator CharAnimator;
    [SerializeField] protected float movementSpeed = 10;
    [SerializeField] protected float rotationtSpeed = 1;
    [SerializeField] protected float attackDistance = 1;
    [SerializeField] protected int baseHp = 100;
    [SerializeField] protected int damage;
    [SerializeField] protected int currentHp;
   
    [HideInInspector]public bool isDead = false;

    [SerializeField] protected Image imageHealthBar;
    [SerializeField] protected GameObject healthBarObj;


    public void OnEnable()
    {
        currentHp = baseHp;
        HealthBar();
        isDead = false;
    }

    public abstract void Move();
    public virtual void TakDamage(int damage)
    {
       
        currentHp -= damage;
        HealthBar();
        if (currentHp <= 0)
        {
            currentHp = 0;
            if (!isDead)
            {
                isDead = true;
                Dead();
            }
        }
    }

    public virtual void HealthBar()
    {
        imageHealthBar.fillAmount = Mathf.Clamp((float)currentHp / (float)baseHp, 0, 1f);
    }

    public virtual void Heal(int healAmount)
    {
        currentHp += healAmount;
        if (currentHp > baseHp) currentHp = baseHp;
    }

    public virtual void Dead()
    {
        CharAnimator.SetBool("IsDead", true);
        CharAnimator.SetBool("IsRun", false);
    }

    public abstract void Attack();



    // Update is called once per frame
    void Update()
    {
        Move();
        healthBarObj.transform.LookAt(Camera.main.transform.position);
    }
}
