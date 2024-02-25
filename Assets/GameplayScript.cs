using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayScript : MonoBehaviour
{
    public List<Transform> Positions = new List<Transform>();
    public JordanController JordanController;

    float timer = 5f;
    bool tester = true;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && tester)
        {
            tester = false;
            JordanController.WalkTo(Positions[0]);
        }
    }
}
