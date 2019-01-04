using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristianAngreb : MonoBehaviour
{

    public AudioManager manager;

    public KeyCode special;
    public KeyCode kick;
    public KeyCode punch;

    private float timeBTWattackpunch;
    public float starttimeBTWattackpunch;

    private float timeBTWattackkick;
    public float starttimeBTWattackkick;

    public LayerMask whatIsEnemy;
    public int damage;

    public Transform attackPosPunch;
    public float attackRangePunch;

    public Transform attackPosKick;
    public float attackRangeKick;

    public GameObject nerfprojectile;
    public Transform shotpoint;
    private float timeBtwNerf;
    public float startTimeBtwNerf;



    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBTWattackpunch <= 0)
        {
            if (Input.GetKey(punch))
            {
                manager.PlaySound("Punch");

                anim.ResetTrigger("punch");
                anim.SetTrigger("punch");
                Collider2D[] enemyToDamage = Physics2D.OverlapCircleAll(attackPosPunch.position, attackRangePunch, whatIsEnemy);
                for (int i = 0; i < enemyToDamage.Length; i++)
                {
                    enemyToDamage[i].GetComponent<Esben>().TakeDamage(damage);

                }
            }
            timeBTWattackpunch = starttimeBTWattackpunch;
        }
        else
        {
            timeBTWattackpunch -= Time.deltaTime;
        }

        if (timeBTWattackkick <= 0)
        {
            if (Input.GetKey(kick))
            {
                manager.PlaySound("Kick");
                anim.ResetTrigger("kick");
                anim.SetTrigger("kick");
                anim.ResetTrigger("kick");
                Collider2D[] enemyToDamage = Physics2D.OverlapCircleAll(attackPosKick.position, attackRangeKick, whatIsEnemy);
                for (int i = 0; i < enemyToDamage.Length; i++)
                {
                    enemyToDamage[i].GetComponent<Esben>().TakeDamage(damage);

                }
            }
            timeBTWattackkick = starttimeBTWattackkick;
        }
        else
        {
            timeBTWattackkick -= Time.deltaTime;
        }
        if (timeBtwNerf <= 0)
        {
            if (Input.GetKey(special))
            {
                manager.PlaySound("Nerf");
                anim.ResetTrigger("special");
                anim.SetTrigger("special");
                Instantiate(nerfprojectile, shotpoint.position, transform.rotation);
                timeBtwNerf = startTimeBtwNerf;
            }
        }
        else
        {
            timeBtwNerf -= Time.deltaTime;
        }


    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosPunch.position, attackRangePunch);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPosKick.position, attackRangeKick);


    }
}