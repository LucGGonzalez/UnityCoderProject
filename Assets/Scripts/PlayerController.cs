using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float life=100,vel=5,horizontal,vertical;
    public Vector3 movePlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        RaiseLife();
        DamageLife();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
    }
   
   
    void MovePlayer()
    {
     horizontal= Input.GetAxis("Horizontal");
     vertical= Input.GetAxis("Vertical");
     
    transform.Translate(horizontal*vel*Time.deltaTime,0,vertical*vel*Time.deltaTime);
     }
    void DamageLife()
    {
        if(transform.position.z >50)
     {
        life= life--;
        Debug.Log("Te han hecho Daño-- Vida="+life);
     } 
    }
    void RaiseLife()
    {
           if(transform.position.z >150)
     {
        life= life++;
        Debug.Log("Te han curado-- Vida="+life);
     } 
    }
}
