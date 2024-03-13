using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav_Move : MonoBehaviour
{
    public Camera cam; 
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) { //boton izquierdo 
            
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit)){
                agent.SetDestination(hit.point);
            }
        }
    }
}
