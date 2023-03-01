using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Clase serializable para poder desde el inspector asignar la cantidad de ruedas derecha e izquierda y si tienen motor o doblan
    [System.Serializable]
    public class MoveInfo {
    //collider de ruedas
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    //variables para saber si las ruedas tienen fuerza y manejo
    public bool motor;
    public bool manejo;
    public bool frenodeMano;
    
    
}
public class Pruebacontroller : MonoBehaviour
{   // Lista para poder recorrer y asignarle los objetos o parametros que el usuario quiera poner desde el inspector
    public TextMeshProUGUI textoKmph;
    public AudioSource emisor;    
    public Camera Camara1;
    public Camera Camara2;
    public List<MoveInfo> moveInfos; 
    //variables para asignar fuerza de motor y angulo de manejo
    public float torqueMaxMotor;
    public float anguloMaxManejo;
    float radiorueda= 0.35f;// radio de la rueda
    
    float rpmRueda; // rpm de la rueda
    float circunFerencia; //circunferencia de la rueda
    float velocidadkmh; // velocidad en km por hora
     public TextMeshProUGUI tiempo;
    private float tiempoPartida;
    private float tiempoLLegada;
    public bool tempActivo;
    private int soloparaswitch=2;
    public AudioClip acelera;
    public AudioClip idle;
    
    
    
       
         
  
     void CambiarCamara()
    {
        if(Input.GetKey(KeyCode.Z))
        {
           Camara1.enabled=false;
           Camara2.enabled=true;
           soloparaswitch=1;
           
           
           }
            if(Input.GetKey(KeyCode.X))
            {
                Camara1.enabled=true;
                Camara2.enabled=false;
                soloparaswitch=2;
                
            }
            switch (soloparaswitch)
            {   
                case 1:
                Debug.Log("Camara1");
                break;
                case 2:
                Debug.Log("Camara2");
                break;
                
            }
         
            
        
    }
    public void ObtenerRpmKmh(WheelCollider collider)
    {
        rpmRueda=collider.rpm;
        //Debug.Log(rpmRueda);
        circunFerencia = 2.0f * 3.14f * radiorueda; // Encontrar la circunferencia 2 Pi R
        velocidadkmh = Mathf.Abs( (circunFerencia * rpmRueda)/60); // calcular km por hora
       // Debug.Log("Kilometros por hora="+velocidadkmh);
    }
    // Funcion para aplicar la posicion del wheel collider a las ruedas
    public void CambiarPosicionRuedas(WheelCollider collider)
    {
       
                                
        //inicializo la variable ruedas con el transform del collider
        Transform ruedas = collider.transform;
        
        //variables para almacenar la info de getworldpose 
        Vector3 position;
        Quaternion rotation;
        //Investigue un poco y encontre que el Getworldpose me devuelve a variables tipo vector3 y quaternion la posicion y rotacion del collider
        collider.GetWorldPose(out position, out rotation);
        //Le asigno la posicion y rotacion devueltas por getworldpose a las ruedas 
        ruedas.transform.position = position;
        ruedas.transform.rotation = rotation;
        
    }
     void MoveryDoblar(){
        //por cada  elemento de moveinfo asigno el comportamiento de las ruedas
        //avanzo cuando 
        float motor = torqueMaxMotor * Input.GetAxis("Vertical");
        float manejo = anguloMaxManejo * Input.GetAxis("Horizontal");
        foreach (MoveInfo moveInfo in moveInfos) {
            if (moveInfo.manejo) {
               
                moveInfo.leftWheel.steerAngle = manejo;
                moveInfo.rightWheel.steerAngle = manejo;
            }
            if (moveInfo.motor) {
                moveInfo.leftWheel.motorTorque = motor;
                moveInfo.rightWheel.motorTorque = motor;
                  
            }
          
         
            //cambio posicion y rotacion de las ruedas asignadas en moveInfo.
            CambiarPosicionRuedas(moveInfo.leftWheel);
            CambiarPosicionRuedas(moveInfo.rightWheel);
            ObtenerRpmKmh(moveInfo.leftWheel);
            
        } 
        }

        void InitTextoContador()
    {
        textoKmph.text= "Velocidad: "+ Mathf.Abs(velocidadkmh).ToString("000")+"Km por hora";
       
    }
        void EmpezarTemporizador()
        {
        if(tempActivo)
        {
            tiempoPartida+=Time.deltaTime;
            
            tiempo.text=tiempoPartida.ToString("0000")+" Segundos";
            }
        }

     private void Start()
    {   
      
      tempActivo=false;
      tiempoPartida=0;
      tiempo.text=tiempoPartida.ToString("0000")+" Segundos";
      Camara1.enabled=true;
      Camara2.enabled=false;
      emisor=GetComponent<AudioSource>();
      InitTextoContador();
      emisor.loop=true;
      emisor.clip=idle;
      emisor.Play();
    }
    private void Update()
    {   if(tempActivo)
        {
            EmpezarTemporizador();
        }  
      if(Input.GetKeyDown(KeyCode.W))
      {
        emisor.loop=true;
        emisor.clip=acelera;
        emisor.Play();
      }
      if(Input.GetKeyUp(KeyCode.W))
      {
        emisor.loop=true;
      emisor.clip=idle;
      emisor.Play();
      }
      CambiarCamara(); 
      InitTextoContador(); 

    }
         
    public void FixedUpdate()
    {   
       MoveryDoblar(); 
        
        
        
        
      
        
 
    
         
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Llegada"))
        {
          tempActivo=true;  
        }
    }
    private void OnCollisionEnter(Collision other)
     {      

            
        
     }
}

