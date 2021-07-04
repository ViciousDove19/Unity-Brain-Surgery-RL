using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class TargetTumor : Agent 
{
    public GameObject brainMriObject;
    List<int> positionindex = new List<int>();
    Vector3 tumorposition;

    public override void OnEpisodeBegin()
    {
        Debug.Log("hi");
        transform.position = Vector3.zero;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        tumorposition = brainMriObject.GetComponent<starterScript>().tumor_pos;
        sensor.AddObservation(tumorposition);
    }
    
    public override void OnActionReceived(ActionBuffers actions)
    {
        int MoveDirection = actions.DiscreteActions[0];

        if (MoveDirection == 0 && transform.position.z<8){
            transform.position += 2*Vector3.forward;
        }
        else if (MoveDirection == 1 && transform.position.z>0){
            transform.position += 2*Vector3.back;
        }
        else if (MoveDirection == 2 && transform.position.x>0){
            transform.position += 2*Vector3.left;
        }
        else if (MoveDirection == 3 && transform.position.x<8){
            transform.position += 2*Vector3.right;
        }
        else if (MoveDirection == 4 && transform.position.y<4){
            transform.position += 2*Vector3.up;
        }
        else if (MoveDirection == 5 && transform.position.y>0){
            transform.position += 2*Vector3.down;
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        
        
        if (Input.GetKeyDown(KeyCode.W)){
            discreteActions[0] = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S)){
            discreteActions[0] = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A)){
            discreteActions[0] = 2;
        }
        else if (Input.GetKeyDown(KeyCode.D)){
            discreteActions[0] = 3;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)){
            discreteActions[0] = 4;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
            discreteActions[0] = 5;
        } 
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<VoxelInitiator>().type == 0){
          //  SetReward(1f);
        //}
        //else if (other.GetComponent<VoxelInitiator>().type == 1){
         //   SetReward(-1f);
        //}
        if (other.GetComponent<VoxelInitiator>().type == 2){
            Debug.Log("gotcha");
            SetReward(2f);
            EndEpisode();
        }

    }
}
