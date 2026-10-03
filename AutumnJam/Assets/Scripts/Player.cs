using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera Cam;
    public float distance;

    // move the camera left and right with A and D keys
    private void Move()
    {
        Vector2 currentLocation = Cam.transform.position;
        Vector2 DesiredLocationR = new Vector2(currentLocation.y, currentLocation.x + distance);
        Vector2 DesiredLocationL = new Vector2(currentLocation.y, currentLocation.x - distance);
        Vector2 DesiredLocation = new Vector2(0,0);
        if (Input.GetKey(KeyCode.D))
        {
            DesiredLocation = DesiredLocationR;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            DesiredLocation = DesiredLocationL;
        }
        Cam.transform.position = Vector2.Lerp(currentLocation, DesiredLocation, Time.deltaTime);
    }
}
