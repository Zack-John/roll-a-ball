using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    void Update()
    {
        // rotate pickups
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
