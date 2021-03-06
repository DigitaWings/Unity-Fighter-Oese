﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nerfprojectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsEnemy;
    public int damage;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsEnemy);
        if (hitInfo.collider !=null)
        {
            if (hitInfo.collider.CompareTag("Esben"))
            {
                Debug.Log("NERF HIT");
                hitInfo.collider.GetComponent<Esben>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        transform.Translate(transform.right * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Object.Destroy(this.gameObject);
    }
}
