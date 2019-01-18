using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.PlaySound("Music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
