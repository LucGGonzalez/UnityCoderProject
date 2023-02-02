using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{   //velocidad de la bala
    public float speed=10;
    //Direccion hacia adelante de la bala
    public Vector3 direction= Vector3.forward;
    //Daño de la bala (no aplicado a nada)
    public float damage;
    public Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {scale=gameObject.transform.localScale; 
        //movemos la bala en direccion "direction" a la velocidad de "speed" * time.deltatime
     transform.Translate(direction*speed*Time.deltaTime);   
    }
}
