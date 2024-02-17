using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class TouchTrigger : VRTrigger
{
    [SerializeField] UnityEvent touchTrigger;

    


    public override void Activate()
    {
        touchTrigger.Invoke();
    }

}
