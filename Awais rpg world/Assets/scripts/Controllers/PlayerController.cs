using UnityEngine.EventSystems;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{

    public interactable focus;

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; // Settign cam to the main camera
        motor = GetComponent<PlayerMotor>();//Getting the player Motor Compnnent
    }

    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //If we press left mouse
        if (Input.GetMouseButtonDown(0)) //Left mouse button
        {
            //we create a rey
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            //if the ray hits
            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //move our player to what we hit
                Debug.Log("we hit " + hit.collider.name + " " + hit.point); //This is a debug log

                motor.MoveToPoint(hit.point); //This moves the player to the selected point
                //stop focusing on any object
                RemoveFocus();
            }
        }


        if (Input.GetMouseButtonDown(1)) //right mouse button
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //Check if we hit an interactable
                interactable interactable = hit.collider.GetComponent<interactable>();
                //If we did set it as our focus
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        motor.StopFollowingTarget();
    }
}
