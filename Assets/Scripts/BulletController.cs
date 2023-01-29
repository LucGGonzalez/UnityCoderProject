using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{   public float speed=10;
    public Vector3 direction= Vector3.forward;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     transform.Translate(direction*speed*Time.deltaTime);   
    }
}
