using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGameobject : MonoBehaviour
{   public GameObject ObjectToInstantiate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space))
      {
        Instantiate(ObjectToInstantiate,transform.position,transform.rotation);
      }  
    }
}
