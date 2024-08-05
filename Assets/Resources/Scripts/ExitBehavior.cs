using UnityEngine;

public class ExitBehavior : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hideSelf();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isArtworkStolen()){
            revealSelf();
            // If player is in the exit, they win
            if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 6.0f){
                GameObject.Find("GameController").GetComponent<GameControlBehavior>().playerEscaped();
            }

        }
        else{
            hideSelf();
        }
        
    }

    void hideSelf(){
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    void revealSelf(){
        Debug.Log("Revealed");
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }

    bool isArtworkStolen(){
        return GameObject.Find("GameController").GetComponent<GameControlBehavior>().isArtworkStolen;
    }
}
