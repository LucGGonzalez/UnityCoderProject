using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float life=100,vel=10,horizontal,vertical,velRotacion=5;
    public Camera main;
    public Camera Camara1;
    public Camera Camara2;
    public AudioSource emisor;

   
  
    
    // Start is called before the first frame update
    void Start()
    {   
        emisor=GetComponent<AudioSource>();
        main.enabled=true;
        Camara1.enabled=false;
        Camara2.enabled=false;
        RaiseLife();
        DamageLife();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
        CambiarCamara();
        
    }
   
    void CambiarCamara()
    {
        if(Input.GetKey(KeyCode.Z))
        {
           Camara1.enabled=true;
           Camara2.enabled=false;
           main.enabled=false;
           
           }
            if(Input.GetKey(KeyCode.X))
            {
                Camara1.enabled=false;
                Camara2.enabled=true;
                main.enabled=false; 
            }
            if(Input.GetKey(KeyCode.C))
            {
               Camara1.enabled=false;
                Camara2.enabled=false;
                main.enabled=true;  
            }
            
        
    }
    void MovePlayer()
    {
     horizontal= Input.GetAxis("Horizontal");
     vertical= Input.GetAxis("Vertical");
     
    transform.Translate(0,0,vertical*vel*Time.deltaTime);
    transform.Rotate(0,horizontal*velRotacion*Time.deltaTime,0);
    
    if(Input.GetButtonDown("Vertical"))
        {emisor.Play();}  
    if(Input.GetButtonUp("Vertical"))
        {emisor.Stop();} 
    
    
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
