using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{   public float giro;
    public float avanzo;
    
    
    [SerializeField]
    private  WheelCollider wheel1,wheel2,wheel3,wheel4;
    [SerializeField]Transform rueda1,rueda2,rueda3,rueda4;
    private float fuerzaFrenado=500f;
    private float actualFuerzaFrenado=0f;
    private float velocidad=600f;
    private float actualVelocidad=0;

    // Start is called before the first frame update
    void Start()
    {
       giro=0f;
       avanzo=0f;
    }

    // Update is called once per frame
    void Update()
    {   giro=Input.GetAxis("Horizontal");     
           
         avanzo= Input.GetAxis("Vertical"); 

      
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
            float rotacion=25;
            wheel.steerAngle=giro*rotacion;
            
         }
         void Girarmeshe(WheelCollider col, Transform trans)
         { Vector3 posicion;
        Quaternion rotacion;
        col.GetWorldPose(out posicion,out rotacion);
        trans.position=posicion;
        trans.rotation=rotacion;


         }
}
