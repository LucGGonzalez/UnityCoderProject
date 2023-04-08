using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movimiento : MonoBehaviour
{   public float giro;
    public float avanzo;
    
    
    [SerializeField]
    private  WheelCollider wheel1,wheel2,wheel3,wheel4;
    [SerializeField]Transform rueda1,rueda2,rueda3,rueda4;
    private float fuerzaFrenado=500f;
    private float actualFuerzaFrenado=0f;
    private float velocidad=500f;
    private float actualVelocidad=0;
    public TextMeshProUGUI textoKmph;
    public AudioSource emisor;    
    public Camera Camara1;
    public Camera Camara2;
    float radiorueda= 0.33f;// radio de la rueda
    
    float rpmRueda; // rpm de la rueda
    float circunFerencia; //circunferencia de la rueda
     public TextMeshProUGUI tiempo;
    private float tiempoPartida;
    private float tiempoLLegada;
    public bool tempActivo;
    public AudioClip acelera;
    public AudioClip idle;
    float velocidadR;
    public GameObject menuPrincipal;
    
    [SerializeField]private bool pausaactiva;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=0; 
          pausaactiva=false;
         emisor=GetComponent<AudioSource>();
          emisor.loop=true;
          emisor.clip=idle;
          emisor.Play();
        tempActivo=false;
      tiempoPartida=0;
      tiempo.text=tiempoPartida.ToString("0000")+" Segundos";
      Camara1.enabled=true;
      Camara2.enabled=false;
      
      InitTextoContador();
      
      
    }

    // Update is called once per frame
    void Update()
    {   giro=Input.GetAxis("Horizontal");     
           
         avanzo= Input.GetAxis("Vertical");
          
           if(tempActivo)
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
      CambiarPausa();
      

      
    }
    private void FixedUpdate() 
    {
      if(Input.GetKey(KeyCode.Space))
      {
        actualFuerzaFrenado=fuerzaFrenado;
        
      }else
      {
        actualFuerzaFrenado=0f;
      }
      wheel1.brakeTorque=actualFuerzaFrenado;
      wheel2.brakeTorque=actualFuerzaFrenado;
      wheel3.brakeTorque=actualFuerzaFrenado;
      wheel4.brakeTorque=actualFuerzaFrenado;
        Girarmeshe(wheel1,rueda1);
        Girarmeshe(wheel2,rueda2);
        Girarmeshe(wheel3,rueda3);
        Girarmeshe(wheel4,rueda4);
      
       if(avanzo!=0f || giro!=0f)
       { if(avanzo!=0f)
           {
             Moverrueda(wheel1);
             ObtenerRpmKmh(wheel1); 
             Moverrueda(wheel2);
             Moverrueda(wheel3);
             Moverrueda(wheel4);
             
           }
         if(giro!=0f)
        {
            GirarRueda(wheel1);
            GirarRueda(wheel2);
            
           // Girarmeshe(wheel1,rueda1);
           //  Girarmeshe(wheel2,rueda2);
             
        }
        }

       
    }
        void Moverrueda(WheelCollider wheel)
        {
         
            
            wheel.motorTorque=avanzo*velocidad;
            
           
        
         }
         void GirarRueda(WheelCollider wheel)
         { 
            float rotacionizq=25;
            float rotacionder=25;
        if(giro > 0)
          { 
            wheel1.steerAngle=giro*rotacionizq;
            wheel2.steerAngle=giro*rotacionder+2;
            
          }
        if(giro < 0)
          {  wheel1.steerAngle=giro*rotacionizq-2;
            wheel2.steerAngle=giro*rotacionder;
          }  
            
         }
         void Girarmeshe(WheelCollider col, Transform trans)
         { Vector3 posicion;
        Quaternion rotacion;
        col.GetWorldPose(out posicion,out rotacion);
        trans.position=posicion;
        trans.rotation=rotacion;


         }
         void CambiarCamara()
    {
        if(Input.GetKey(KeyCode.Z))
        {
           Camara1.enabled=false;
           Camara2.enabled=true;
           
           
           
           }
            if(Input.GetKey(KeyCode.X))
            {
                Camara1.enabled=true;
                Camara2.enabled=false;
                
                
            }
           
         
    }
      public void ObtenerRpmKmh(WheelCollider collider)
    {   
        rpmRueda=collider.rpm;
        //Debug.Log(rpmRueda);
        circunFerencia = 2.0f *( 3.14f * radiorueda); // Encontrar la circunferencia 2 Pi R
        velocidadR = Mathf.Abs( (circunFerencia * rpmRueda)/60); // calcular km por hora
       // Debug.Log("Kilometros por hora="+velocidadkmh);
    }
     void InitTextoContador()
    {
        textoKmph.text= "Velocidad: "+ Mathf.Abs(velocidadR).ToString("000")+"Km por hora";
       
    }
     void EmpezarTemporizador()
        {
        if(tempActivo)
        {
            tiempoPartida+=Time.deltaTime;
            
            tiempo.text=tiempoPartida.ToString("0000")+" Segundos";
            }
        }
        public void SalirJuego()
        {
          Application.Quit();
        }
        public void JugarJuego()
        {
          menuPrincipal.SetActive(false);
          Time.timeScale=1; 
          pausaactiva=false;
          
          
          

        }
        void CambiarPausa()
        {
          if(Input.GetKeyDown(KeyCode.Escape))
          {
            if(pausaactiva==true)
            {
              ResumirJuego();
            }else
            {
              PausarJuego();
            }
          }
        }
        void PausarJuego()
        {
          menuPrincipal.SetActive(true);
          pausaactiva=true;
          Time.timeScale=0; 
          emisor.Stop(); 
        }
        void ResumirJuego()
        {
          menuPrincipal.SetActive(true);
          Time.timeScale=1; 
          pausaactiva=false;
          emisor.loop=true;
          emisor.clip=idle;
          emisor.Play();
        }
}
