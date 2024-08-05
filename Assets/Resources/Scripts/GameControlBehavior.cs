using UnityEngine;
using TMPro;

public class GameControlBehavior : MonoBehaviour
{
    public bool isSecuritySystemTriggered;
    public bool isArtworkStolen = false;
    public bool isPlayerEscaped = false;
    public int hits = 0;

    // Get the text component from the canvas TextMeshPro in the scene
    public TextMeshProUGUI textMesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMesh = GameObject.Find("ScreenText").GetComponent<TextMeshProUGUI>();
        isSecuritySystemTriggered = false;
        textMesh.text = "Goal: Steal the Red Artwork\nDon't get caught by the cameras or the guard!";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hits > 100){
            isSecuritySystemTriggered = true;
            Debug.Log("Security system triggered");
            textMesh.text = "Security System Triggered!";
            // Pause for 2 seconds
            Invoke("reset", 2.0f);
        }
        
    }

    public void artworkStolen(){
        isArtworkStolen = true;
        textMesh.text = "Good work stealing the artwork!\nNow get out and return to the exit!";
    }

    public void playerEscaped(){
        Debug.Log("Player escaped");
        textMesh.text = "You win!";
        Invoke("endGame", 3.0f);
        Application.Quit();
    }

    void endGame(){
        // End the running scene
        Application.Quit();
    }

    public void reset(){
        Debug.Log("Game reset");
        isSecuritySystemTriggered = false;
        isArtworkStolen = false;
        isPlayerEscaped = false;
        hits = 0;
        GameObject player = GameObject.Find("Player");
        GameObject exit = GameObject.Find("Exit");
        GameObject target = GameObject.Find("Target Artwork");
        // Vector3(0.1454568f,1.3f,46.39f);
        player.transform.position = new Vector3(0.1454568f,1.3f,46.39f);
        // Get the script of the target artwork and set reset to true
        target.GetComponent<TargetArtworkBehavior>().reset = true;
        textMesh.text = "Goal: Steal the Red Artwork\nDon't get caught by the cameras or the guard!";

    }
}
