using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class LookAtTrigger : VRTrigger
{
    [SerializeField] float triggerTime = 0f;
    [SerializeField] UnityEvent lookTrigger;
    [SerializeField] UnityEvent resetTrigger;

    bool counting = false;
    bool triggered = false;
    float countedTime = 0f;

    private void FixedUpdate()
    {
        if (counting && triggered == false)
        {
            countedTime += Time.fixedDeltaTime;
            Debug.Log("Time Stared at:" + countedTime);


            if (countedTime > triggerTime) 
            { 
                lookTrigger.Invoke();
                Debug.Log("Event Invoked");
                counting = false;
                countedTime = 0f;
                triggered = true;
            }
        }
    }
    
    public override void Activate()
    {
        if (triggerTime > 0)
        {
            counting = true;
            Debug.Log("Counting enabled");
        }
        else
        {
            lookTrigger.Invoke();
        }
    }

    public override void Deactivate()
    {
        counting = false;
        countedTime = 0f;
        resetTrigger.Invoke();
        Debug.Log("Reset Triggered");
        triggered = false;
    }
}
