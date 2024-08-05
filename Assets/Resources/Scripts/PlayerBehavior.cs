using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float movementSpeed = 0.06f;
    public float rotationSpeed = 0.17f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // On left key, move head left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, -rotationSpeed, 0));
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotationSpeed, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Move player forward in the direction facing
            rb.MovePosition(rb.position + transform.forward * movementSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position - transform.forward * movementSpeed);
        }

        fixRotation();
    }

    void fixRotation()
{
    // If the player has fallen over, fix their rotation
    Vector3 currentRotation = rb.rotation.eulerAngles;
    
    // Set x and z to 0, keep y as is
    Vector3 fixedRotation = new Vector3(0, currentRotation.y, 0);
    rb.MoveRotation(Quaternion.Euler(fixedRotation));
    
    // Zero out forces and velocities
    rb.linearVelocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;
}

}

