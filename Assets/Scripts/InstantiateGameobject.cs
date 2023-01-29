using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGameobject : MonoBehaviour
{   //creamos la referencia al gameobject a instanciar(el objeto que tenga el script se va a instanciar)
    public GameObject ObjectToInstantiate;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    BulletInstantiate();
    }
   
   
    void BulletInstantiate()
    {
        //si se detecta la presion de la tecla espacio se instancia una copia del gameobject(sin limite:pueden ser mil)
      if(Input.GetKeyDown(KeyCode.Space))
      {
        //la instanciacion se hace en la posicion del objeto que tiene este script(SpawnBullet) y en su misma rotacion
        Instantiate(ObjectToInstantiate,transform.position,transform.rotation);
      }  
    }
}
