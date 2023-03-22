using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycastcompetidor : MonoBehaviour
{
   
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update() {
         Ray ray= new Ray(transform.position+new Vector3(0,0.7f,0),transform.forward*-30f);
         Ray ray2=new Ray(transform.position+new Vector3(0,0.7f,0),transform.forward*50f);
        RaycastHit hit;
        RaycastHit hit2;
        Debug.DrawRay(ray.origin,ray.direction*30,Color.green);
        Debug.DrawRay(ray2.origin,ray.direction*-30,Color.green);
        
            if(Physics.Raycast(ray, out hit)  )
            {
            if(hit.transform.gameObject.tag=="Player")
            {
            Debug.Log(hit.transform.tag); 
            transform.Translate(Vector3.right*10f *Time.deltaTime); 
            }
             }   
           if( Physics.Raycast(ray2,out hit2)){
            if(hit2.transform.gameObject.tag=="Player")
            {
            Debug.Log(hit2.transform.tag); 
            Debug.Log(hit2.point);
            transform.Translate(Vector3.forward*10f *Time.deltaTime); 
            }
           }
    }
    void FixedUpdate()
    {   
        
         
   
    }
}
