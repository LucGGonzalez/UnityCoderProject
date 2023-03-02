using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycastcompetidor : MonoBehaviour
{
    Vector3 back;
    RaycastHit hit;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update() {
        Debug.DrawLine(transform.position,transform.position-back, Color.black,1000f);
    }
    void FixedUpdate()
    {   
        back= new Vector3(0f,0f,20f);
         
       if(Physics.Raycast(transform.position,transform.position-back,out hit, 1f))
       {Debug.Log(hit.transform.tag);   
      if(hit.transform.tag =="Player")
      {
      transform.Translate(2,0,0);
      }
    }   
    }
}
