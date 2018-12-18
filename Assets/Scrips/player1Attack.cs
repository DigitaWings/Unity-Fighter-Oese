using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Attack : MonoBehaviour
{

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

    public GameObject animeprojectile;
    public Transform shotpoint;
    private float timeBtwAnime;
    public float startTimeBtwAnime;



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
                anim.ResetTrigger("punch");
                anim.SetTrigger("punch");
                Collider2D[] enemyToDamage = Physics2D.OverlapCircleAll(attackPosPunch.position, attackRangePunch, whatIsEnemy);
                for (int i = 0; i < enemyToDamage.Length; i++)
                {
                    enemyToDamage[i].GetComponent<Christian>().TakeDamage(damage);

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
                anim.ResetTrigger("kick");
                anim.SetTrigger("kick");
                Collider2D[] enemyToDamage = Physics2D.OverlapCircleAll(attackPosKick.position, attackRangeKick, whatIsEnemy);
                for (int i = 0; i < enemyToDamage.Length; i++)
                {
                    enemyToDamage[i].GetComponent<Christian>().TakeDamage(damage);

                }
            }
            timeBTWattackkick = starttimeBTWattackkick;
        }
        else
        {
            timeBTWattackkick -= Time.deltaTime;
        }
        if(timeBtwAnime <= 0)
        {
            if (Input.GetKey(special))
            {
                Instantiate(animeprojectile, shotpoint.position, transform.rotation);
                timeBtwAnime = startTimeBtwAnime;
            }
        }
        else
        {
            timeBtwAnime -= Time.deltaTime;
        }
       

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosPunch.position,attackRangePunch);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPosKick.position, attackRangeKick);


    }
}
