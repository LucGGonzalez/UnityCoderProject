using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGameobject : MonoBehaviour
{   //creamos la referencia al gameobject a instanciar(el objeto que tenga el script se va a instanciar)
    public GameObject ObjectToInstantiate;
    
    public float temporizador;
    public float tiempoFaltante;
    // Start is called before the first frame update
    void Start()
    {
      ResetTimer(); 
      
    }

    // Update is called once per frame
    void Update()
    {
    
    Temporizador();
    BulletInstantiate();
    }
   
   
    void BulletInstantiate()
    {   if(tiempoFaltante<=0)
    {   
        ObjectToInstantiate.transform.localScale=new Vector3(0.3f,0.3f,0.3f);
        //la instanciacion se hace en la posicion del objeto que tiene este script(SpawnBullet) y en su misma rotacion
        Instantiate(ObjectToInstantiate,transform.position,transform.rotation);
        ResetTimer();
    }
        //si se detecta la presion de la tecla espacio se instancia una copia del gameobject(sin limite:pueden ser mil)
      if(Input.GetKeyDown(KeyCode.Space))
      {
        
        ObjectToInstantiate.transform.localScale=new Vector3(2f,2f,2f);
        Instantiate(ObjectToInstantiate,transform.position,transform.rotation);
        
      } 
    
    }
    
    void Temporizador()
    {
      tiempoFaltante-=Time.deltaTime;
      
    }
   
   
    void ResetTimer()
    {
      tiempoFaltante=temporizador;
    }
}
