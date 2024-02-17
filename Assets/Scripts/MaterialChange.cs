using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class MaterialChange : MonoBehaviour
{
    Material baseMat;
    [SerializeField] Material altMat;

    // Start is called before the first frame update
    void Start()
    {
        baseMat = gameObject.GetComponent<Renderer>().material;
    }

    public void Change(int input)
    {
        if (input == 0)
        {
            gameObject.GetComponent<Renderer>().material = baseMat;
        }
        else if (input == 1)
        {
            gameObject.GetComponent<Renderer>().material = altMat;
        }
    }

}
