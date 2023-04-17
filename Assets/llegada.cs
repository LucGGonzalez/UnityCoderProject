using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class llegada : MonoBehaviour
{
    public GameObject ganaste;
    public GameObject teGanaron;
    public GameObject reiniciar;
    Collider col;
    
   
    void Start()
    { 
        col=GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {  if(other.transform.position.z < col.transform.position.z)
            { 
                ganaste.SetActive(true);
                reiniciar.SetActive(true);
                Time.timeScale=0; 
                
            } 
           
        }
        if(other.CompareTag("NoJugador"))
        {  if(other.transform.position.z < col.transform.position.z)
            { 
                teGanaron.SetActive(true);
                reiniciar.SetActive(true);
                Time.timeScale=0; 
                
            } 
           
        }

    }
   
   
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("Ingame");
    }
}
