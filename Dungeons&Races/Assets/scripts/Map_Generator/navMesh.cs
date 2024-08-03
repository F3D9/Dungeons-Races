using NavMeshPlus.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navMesh : MonoBehaviour
{
    NavMeshSurface nav;

    // Start is called before the first frame update
    void Start()
    {
        enabled = true; 
        nav = GetComponent<NavMeshSurface>();
        Invoke("desactivar_script", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        actualizar();
        
    }

    public void actualizar()
    {
        nav.UpdateNavMesh(nav.navMeshData);
    }

    void desactivar_script()
    {
        enabled = false;
    }

    
}
