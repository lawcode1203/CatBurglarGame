using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = getPlayer();
    }

    void informGameController(){
        GameObject gc = GameObject.Find("GameController");
        if (gc == null){
            Debug.Log("GameController not found");
            return;
        }
        else{
            gc.GetComponent<GameControlBehavior>().hits += 1;
        }
    }

    void Update()
    {
        Camera cam = GetComponent<Camera>();
        if (isVisibleFromCamera(cam, player))
        {
            informGameController();
        }
        else
        {
            // Do nothing
            bool nothing = true;
        }
    }

    private GameObject getPlayer()
    {
        return GameObject.Find("Player");
    }

    bool isVisibleFromCamera(Camera cam, GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

        foreach (Renderer renderer in renderers)
        {
            if (GeometryUtility.TestPlanesAABB(planes, renderer.bounds))
            {
                // Perform multiple raycasts to ensure player is fully visible
                Vector3[] pointsToCheck = new Vector3[]
                { // Points are: center, min, max, top left, top right, bottom left, bottom right
                    renderer.bounds.center,
                    renderer.bounds.min,
                    renderer.bounds.max,
                    new Vector3(renderer.bounds.min.x, renderer.bounds.min.y, renderer.bounds.max.z),
                    new Vector3(renderer.bounds.min.x, renderer.bounds.max.y, renderer.bounds.min.z),
                    new Vector3(renderer.bounds.max.x, renderer.bounds.min.y, renderer.bounds.min.z),
                    new Vector3(renderer.bounds.max.x, renderer.bounds.max.y, renderer.bounds.max.z)
                };

                bool visible = false;
                foreach (Vector3 point in pointsToCheck)
                {
                    Vector3 direction = (point - cam.transform.position).normalized;
                    float distance = Vector3.Distance(cam.transform.position, point);
                    if (!Physics.Raycast(cam.transform.position, direction, distance))
                    {
                        visible = true;
                        break;
                    }
                }

                if (visible)
                {
                    return true; 
                }
            }
        }
        return false; // Player is not within the frustum or is occluded
    }
}
