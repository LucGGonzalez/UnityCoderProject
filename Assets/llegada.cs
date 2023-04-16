using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class llegada : MonoBehaviour
{
    public GameObject ganaste;
    public GameObject teGanaron;
    
   
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {   
            ganaste.SetActive(true);
        }
    }
}
