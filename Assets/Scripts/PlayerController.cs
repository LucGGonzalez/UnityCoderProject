using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vida=100,velocidad=5;
    private Vector3 direccion= Vector3.forward;
    
    // Start is called before the first frame update
    void Start()
    {
        RaiseVida();
        DamageVida();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
    }
   
   
    void MovePlayer()
    {
     transform.Translate(direccion*velocidad*Time.deltaTime);
      
    }
    void DamageVida()
    {
        if(transform.position.z >50)
     {
        vida= vida--;
        Debug.Log("Te han hecho Daño-- Vida="+vida);
     } 
    }
    void RaiseVida()
    {
           if(transform.position.z >150)
     {
        vida= vida++;
        Debug.Log("Te han curado-- Vida="+vida);
     } 
    }
}
