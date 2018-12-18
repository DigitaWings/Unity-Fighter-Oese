using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{

    public float speed;
    public float lifeTime;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Object.Destroy(this.gameObject);
    }
}
