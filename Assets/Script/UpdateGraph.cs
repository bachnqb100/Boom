using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class UpdateGraph : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AstarPath.active.Scan();
        }
    }
}
