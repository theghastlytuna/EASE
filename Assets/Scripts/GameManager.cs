using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{

    [SerializeField] LayerMask layerMask;
    private GameObject currentLookTarget = null;
    private GameObject previousLookTarget = null;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Spherecast out from player view
        RaycastHit hit;
        if (Physics.SphereCast(Player.instance.hmdTransform.position, 0.2f, Player.instance.hmdTransform.forward, out hit))
        {
            //Debug.Log(hit.transform.name);

            //if we look at something that is triggered by looking, notify the object
            if (hit.transform.gameObject.GetComponent<LookAtTrigger>() != null)
            {
                currentLookTarget = hit.transform.gameObject;
                hit.transform.gameObject.GetComponent<LookAtTrigger>().Activate();

                //if we just started looking at this object, tell the old object we aren't looking anymore (if it exists)
                if (!currentLookTarget.Equals(previousLookTarget))
                {
                    if (previousLookTarget != null)
                        previousLookTarget.GetComponent<LookAtTrigger>().Deactivate();

                    previousLookTarget = currentLookTarget;

                    Debug.Log("New Target: " + currentLookTarget.name);
                }
                else if (currentLookTarget.Equals(previousLookTarget))
                {

                }
            }
            //if we look at a regular object, let the previous object know
            else
            {
                if (previousLookTarget != null)
                    previousLookTarget.GetComponent<LookAtTrigger>().Deactivate();

                previousLookTarget = null;

            }
        }
        //if we aren't looking at anything, let the previous object know
        else
        {
            if (previousLookTarget != null)
                previousLookTarget.GetComponent<LookAtTrigger>().Deactivate();

            previousLookTarget= null;
        }

    }
}
