using UnityEngine;

public class GuardBehavior : MonoBehaviour
{
    public float movementSpeed = 0.06f;
    private bool isMoving = false;

    private GameObject currentCheckpoint = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving){
            
            // turn towards checkpoint
            transform.LookAt(currentCheckpoint.transform);
            
            // move towards checkpoint
            transform.position = Vector3.MoveTowards(transform.position, currentCheckpoint.transform.position, movementSpeed);

            // if close enough, move to next checkpoint
            if (Vector3.Distance(transform.position, currentCheckpoint.transform.position) < 0.1f){
                isMoving = false;
            }
        } else{
            GameObject[] checkpoints = getCheckpoints();
            // choose random checkpoint
            int index = Random.Range(0, checkpoints.Length);
            currentCheckpoint = checkpoints[index];
            isMoving = true;
        }
        
    }

    GameObject[] getCheckpoints(){
        return GameObject.FindGameObjectsWithTag("Checkpoints");
    }
}
