using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    private List<CheckpointSingle> checkpointList;
    public Transform lastCheckpointPos;
    private int nextCheckpointIndex;
    private int currentLap;
    public int lapToComplete;

    private void Awake()
    { 
        checkpointList = new List<CheckpointSingle>();
        Transform checkpointsTransform = transform.Find("Checkpoints");

        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);

            checkpointList.Add(checkpointSingle);
        }

        lastCheckpointPos = checkpointList[0].transform;
        nextCheckpointIndex = 0;
        currentLap = 1;
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle, Collider car)
    {
        if (currentLap <= lapToComplete)
        {
            if (checkpointList.IndexOf(checkpointSingle) == nextCheckpointIndex)
            {
                nextCheckpointIndex = (nextCheckpointIndex + 1) % checkpointList.Count;               
                lastCheckpointPos=checkpointSingle.transform;
                lastCheckpointPos.position = new Vector3(lastCheckpointPos.position.x, car.ClosestPoint(lastCheckpointPos.position).y, lastCheckpointPos.position.z);
                if (nextCheckpointIndex == 0)
                {
                    Debug.Log($"Lap {currentLap} finished");
                    currentLap++;
                    if(currentLap > lapToComplete)
                    {
                        //VÉGE
                    }
                }
            }
            else
            {
                Debug.Log("wrong checkpoint");
            }
        }
    }
}
