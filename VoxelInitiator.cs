using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelInitiator : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] materials;
    public int type;
    private Renderer myObject;

    void Start()
    {
        myObject = GetComponent<Renderer>();
        myObject.enabled = true;
        myObject.sharedMaterial = materials[type];
    }
    /*private void OnTriggerEnter(Collider other)
    {
        myObject = GetComponent<Renderer>();
        myObject.enabled = true;
        myObject.sharedMaterial = materials[3];
    }*/

    
}
