using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vehiculonoJugador : MonoBehaviour
{
    public Transform[] objetivo=new Transform[15];
    private int objetivoActual;
  
    
    private NavMeshAgent noJugador;
    private void Awake()
     {
     
      

    }
    void Start()
    {
      noJugador=GetComponent<NavMeshAgent>();
      objetivoActual=0;
      noJugador.SetDestination(objetivo[objetivoActual].position);
      //Debug.Log(objetivo.Length);
      
    }

    // Update is called once per frame
    void Update()
    {
      
       PerseguirJugador();   
    }
    public void PerseguirJugador()
    
    { //Debug.Log(noJugador.remainingDistance);
      //Debug.Log(noJugador.stoppingDistance);
     if (noJugador.remainingDistance < noJugador.stoppingDistance)
     {
      objetivoActual++;
      //Debug.Log(objetivo[objetivoActual]);
      if(objetivoActual>=objetivo.Length)
      {
        objetivoActual=0;
      }
      noJugador.SetDestination(objetivo[objetivoActual].position);
      
     }
     
     }
    
}
