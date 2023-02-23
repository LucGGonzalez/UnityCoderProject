using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerviejo : MonoBehaviour
{
    
    public Camera main;
    public Camera Camara1;
    public Camera Camara2;
    public AudioSource emisor;
    public float speed=1000f;
    public float horizontalInput;
    public float verticalInput;
    public Vector3 velRotation= new Vector3(0,50,0);
    private Rigidbody rb;
    

   
  
    
    // Start is called before the first frame update
    void Start()
    {   
        emisor=GetComponent<AudioSource>();
        main.enabled=true;
        //Camara1.enabled=false;
        //Camara2.enabled=false;
        rb=GetComponent<Rigidbody>();
        
        
        
        
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
        horizontalInput=Input.GetAxis("Horizontal");
        verticalInput=Input.GetAxis("Vertical");
      
      
      
        rb.AddForce(Vector3.forward*verticalInput*speed*Time.deltaTime,ForceMode.Force);
        //transform.Translate(Vector3.right*horizontalInput*speed*Time.deltaTime);
        //transform.Rotate(Vector3.up, velRotation*horizontalInput*Time.deltaTime);
        
        Quaternion deltaRotation = Quaternion.Euler(velRotation *horizontalInput* Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    
        //if(Input.GetButtonDown("Vertical"))
        //{emisor.Play();}  
        //if(Input.GetButtonUp("Vertical"))
        //{emisor.Stop();} 
    
    
     }
    
    
}
