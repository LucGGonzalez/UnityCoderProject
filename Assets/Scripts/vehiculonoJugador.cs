using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vehiculonoJugador : VehiculoJugador
{
    public Transform objetivo;
    NavMeshAgent noJugador;
    private void Awake()
     {
      noJugador=GetComponent<NavMeshAgent>();
    }
    void Start()
    {
      PerseguirJugador();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PerseguirJugador()
    {
       noJugador.destination=objetivo.position; 
    }
}
