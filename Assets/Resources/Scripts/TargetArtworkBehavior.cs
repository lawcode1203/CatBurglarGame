using UnityEngine;

public class TargetArtworkBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isHidden = false;
    public bool reset = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        // If the artwork is near the player, it is hidden
        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 5.0f && !isHidden){
            GameObject.Find("GameController").GetComponent<GameControlBehavior>().artworkStolen();
            isHidden = true;
            // Hide the artwork
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }

        else if (reset){
            isHidden = false;
            // Show the artwork
            GetComponent<Renderer>().enabled = true;
            GetComponent<Collider>().enabled = true;

            reset = false;
        }
        
    }
}
