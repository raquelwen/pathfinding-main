using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class Nav_TerrainModifier : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshModifier meshsurface;
    

    void Start()
    {
        meshsurface = GetComponent<NavMeshModifier>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //compruebo que lo que ha entrado es un agente
        if(other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            if (meshsurface.AffectsAgentType(agent.agentTypeID)) //copmruebo que el agente se ve afectado por este tipo de terreno
            {
                agent.speed /= NavMesh.GetAreaCost(meshsurface.area);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            if (meshsurface.AffectsAgentType(agent.agentTypeID)) //compruebo que el agente se ve afectado por este tipo de terreno
            {
                agent.speed *= NavMesh.GetAreaCost(meshsurface.area);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
