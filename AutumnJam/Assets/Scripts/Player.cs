using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera Cam;
    public float distance;

    public GameEvent onObserveSoup;
    public GameEvent onObserveCheese;

    public Transform soupTransform;
    public Transform cheeseTransform;

    private Vector3 DesiredLocationR;
    private Vector3 DesiredLocationL;

    void Start()
    {
        DesiredLocationR = soupTransform.position;
        DesiredLocationL = cheeseTransform.position;
    }
    // move the camera left and right with A and D keys
    private void Move()
    {
        Vector3 currentLocation = Cam.transform.position;
        Vector3 DesiredLocation = new Vector3(0,0,-10);

        if (Input.GetKey(KeyCode.D))
        {
            DesiredLocation = new Vector3(DesiredLocationR.x, DesiredLocationR.y, -10);
            onObserveSoup.TriggerEvent();
            Cam.transform.position = Vector3.Lerp(currentLocation, DesiredLocation, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            DesiredLocation = new Vector3(DesiredLocationL.x, DesiredLocationL.y, -10);
            onObserveCheese.TriggerEvent();
            Cam.transform.position = Vector3.Lerp(currentLocation, DesiredLocation, Time.deltaTime);
        }
        
    }

    private void alternateMove()
    {
        Vector3 currentLocation = Cam.transform.position;
        Vector3 DesiredLocation = new Vector3(0, 0, -10);
        if (Input.GetKeyDown(KeyCode.H))
        {
            DesiredLocation = new Vector3(DesiredLocationR.x, DesiredLocationR.y, -10);
            onObserveSoup.TriggerEvent();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            DesiredLocation = new Vector3(DesiredLocationL.x, DesiredLocationL.y, -10);
            onObserveCheese.TriggerEvent();
        }
        Cam.transform.position = Vector3.Lerp(currentLocation, DesiredLocation, Time.deltaTime * 5f);
    }

    void Update()
    {
        Move();
        //alternateMove();
    }
}
