using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starterScript : MonoBehaviour
{
    public GameObject[,,] brain = new GameObject[5,5,3];
    public GameObject brainVoxel;

    public Vector3 tumor_pos;
    // Start is called before the first frame update
    void Start()
    {
        int tumor_seed = Random.Range(0,75);
        for(int k=0; k<3; k++)
        {
            for(int j = 0; j<5; j++)
            {
                for(int i = 0; i < 5; i++)
                {
                    int seed = Random.Range(0,2);
                    GameObject brainVoxelObject;
                    brainVoxelObject = Instantiate(brainVoxel,new Vector3(i * 2, k * 2, j * 2), Quaternion.identity);
                    if((25*k+5*j+i)==tumor_seed){
                        brainVoxelObject.GetComponent<VoxelInitiator>().type = 2;
                        tumor_pos = new Vector3(i * 2, k * 2, j * 2);
                    }
                    else{
                        brainVoxelObject.GetComponent<VoxelInitiator>().type = seed;
                    }
                    brain[i,j,k] = brainVoxelObject;
                    //Debug.Log(brain[i,j,k].GetComponent<VoxelInitiator>().type);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
