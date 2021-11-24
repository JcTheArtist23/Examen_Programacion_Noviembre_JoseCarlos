using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System;

public class BoxSelection : MonoBehaviour
{//Declaramos las variables


    //Controlador del menu
    
    //Para poder hacer una animación
    public Animator anim;

    //Para que funcione el raycast
    private NavMeshAgent agente;
    private Vector3 initialPoint;
    private bool isReturningInitialPoint;
    private bool isMenuClicked;
    private int menuOption;
    
    //para que inicie un contador
    public float contador=5;
    private Text cuentaAtras;
    public bool puedeCambiarDeNivel;

    //Inicialicamos el programa
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        isMenuClicked = false;
        cuentaAtras = GetComponent<Text>();
        puedeCambiarDeNivel = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*100, Color.cyan);
        RaycastHit hit;
        
        if(Input.GetMouseButtonDown(0) && isMenuClicked == false)
        {
                if(Physics.Raycast(ray, out hit) == true)
                {
                    var selection = hit.transform;
                    if(selection.CompareTag("Cubo1") || selection.CompareTag("Esfera") || selection.CompareTag("Cubo2"))
                    {
                        agente.destination = hit.point;
                        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                        Debug.Log(hit.transform.gameObject.tag);
                       
                        if (selection.CompareTag("Cubo1"))
                        {
                            contador--;
                         if(selection.CompareTag("Cubo1") && contador==0)
                            {
                                SceneManager.LoadScene(1);
                            }
                        }
                        if (selection.CompareTag("Esfera"))
                        {
                            
                            contador--;
                            if(selection.CompareTag("Esfera") && contador==0)
                            {
                                SceneManager.LoadScene(2);
                            }
                        }
                        if (selection.CompareTag("Cubo2"))
                        {
                            
                            contador--;
                            if(selection.CompareTag("Cubo2") && contador==0)
                            {
                                SceneManager.LoadScene(3);
                            }
                            
                            
                            
                        }
                    } 
                }     
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5.0f);
        puedeCambiarDeNivel = true;
    }
    
}
