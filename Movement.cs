using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject brainMriObject;
    List<int> positionindex = new List<int>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            //Debug.Log(brainMriObject[x,y,z]);

        if (Input.GetKeyDown(KeyCode.W) && transform.position.z<8){
            transform.position += 2*Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S) && transform.position.z>0){
            transform.position += 2*Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.A) && transform.position.x>0){
            transform.position += 2*Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && transform.position.x<8){
            transform.position += 2*Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y<4){
            transform.position += 2*Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y>0){
            transform.position += 2*Vector3.down;
        }
    }
}
