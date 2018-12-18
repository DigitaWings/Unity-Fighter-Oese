using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Attack : MonoBehaviour
{

    public KeyCode special;
    public KeyCode kick;
    public KeyCode punch;

    private float timeBTWattack;
    public float starttimeBTWattack;

    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBTWattack <= 0)
        {
            if (Input.GetKey(punch))
            {
                Collider2D[] enemyToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemyToDamage.Length; i++)
                {
                    enemyToDamage[i].GetComponent<Christian>().TakeDamage(damage);

                }
            }
            timeBTWattack = starttimeBTWattack;
        }
        else
        {
            timeBTWattack -= Time.deltaTime;
        }
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);

    }
}
