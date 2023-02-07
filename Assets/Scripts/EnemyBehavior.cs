using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{   public enum Estado
    {
        alerta,dormido,ataque
    }
    public Estado accion;
    public GameObject jugador;
    AudioSource clip;
    public float distancia;
    
    // Start is called before the first frame update
    void Start()
    { 
      clip =GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {distancia=  Vector3.Distance(jugador.transform.position,transform.position);
     AccionEnemiga(accion); 
    }

private void AccionEnemiga(Estado accion)
{
    switch (accion)
    {
        case Estado.dormido:
        //clip.Play();
        break;
        case Estado.alerta:
        //clip.Play();
        MirarJugador();
        break;
        case Estado.ataque:
        //clip.Play();
        MirarJugador();
        SeguirJugador();
        break;
        
    }
}
    private void MirarJugador()
    {
        Quaternion nuevaRotacion= Quaternion.LookRotation(jugador.transform.position-transform.position);
        transform.rotation=Quaternion.Lerp(transform.rotation,nuevaRotacion,5f*Time.deltaTime);
    }
    private void SeguirJugador()
    {   if (Vector3.Distance(jugador.transform.position,transform.position)>2)
    {
       transform.position= Vector3.Lerp(transform.position,jugador.transform.position,1f*Time.deltaTime);
       
       }else
       {
        transform.position=transform.position;
       }
    }
}
