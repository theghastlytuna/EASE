using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JordanController : MonoBehaviour
{
    public Animator Jordanimator;
    public BoxCollider InvisibleWall;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    bool walking;
    Transform target;

    public void Idle()
    {
        Jordanimator.Play("Idle");
        InvisibleWall.enabled = true;
        walking = false;
    }

    public void WalkTo(Transform location)
    {
        InvisibleWall.enabled = false;
        Jordanimator.Play("Walk");
        walking = true;
        target = location;
    }

    void Start()
    {
        Jordanimator.SetFloat("Velocity", movementSpeed); 
    }

    void Update()
    {
        if(walking)
        {
            Vector3 dir = target.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            transform.position += dir.normalized * movementSpeed * Time.deltaTime;

            if(dir.magnitude < 0.1f)
            {
                Idle();
            }
        }

    }

    void Reset()
    {
        Jordanimator = GetComponent<Animator>();
        InvisibleWall = GetComponent<BoxCollider>();
    }
}
