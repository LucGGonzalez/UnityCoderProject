using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase serializable para poder desde el inspector asignar la cantidad de ruedas derecha e izquierda y si tienen motor o doblan
    [System.Serializable]
    public class MoveInfo {
    //collider de ruedas
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    //variables para saber si las ruedas tienen fuerza y manejo
    public bool motor;
    public bool manejo;
}
public class Pruebacontroller : MonoBehaviour
{   // Lista para poder recorrer y asignarle los objetos o parametros que el usuario quiera poner desde el inspector
    public List<MoveInfo> moveInfos; 
    //variables para asignar fuerza de motor y angulo de manejo
    public float torqueMaxMotor;
    public float anguloMaxManejo;
         
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

     private void Start()
    {
      
    }
         
    public void FixedUpdate()
    {   
        //avanzo cuando 
        float motor = torqueMaxMotor * Input.GetAxis("Vertical");
        float manejo = anguloMaxManejo * Input.GetAxis("Horizontal");
        //por cada par de elementos de moveinfo asigno si manejan o avanzan o las dos cosas 
        foreach (MoveInfo moveInfo in moveInfos) {
            if (moveInfo.manejo) {
               
                moveInfo.leftWheel.steerAngle = manejo;
                moveInfo.rightWheel.steerAngle = manejo;
            }
            if (moveInfo.motor) {
                moveInfo.leftWheel.motorTorque = motor;
                moveInfo.rightWheel.motorTorque = motor;
                if(Input.GetKey(KeyCode.Space))
                {
                moveInfo.leftWheel.brakeTorque = motor;
                moveInfo.rightWheel.brakeTorque = motor;
                }
            }
            //cambio posicion y rotacion de las ruedas asignadas en moveInfo.
            CambiarPosicionRuedas(moveInfo.leftWheel);
            CambiarPosicionRuedas(moveInfo.rightWheel);
        } 
    }
}

