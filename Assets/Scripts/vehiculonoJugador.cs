using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehiculonoJugador : VehiculoJugador
{
    public GameObject jugador;
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
        Debug.Log("Persiguiendo al jugador");
    }
}
