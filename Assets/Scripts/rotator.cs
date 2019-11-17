using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    Vector3 rotate = new Vector3(0, 0, 30);
    private void Update()
    {
        transform.Rotate(rotate * Time.deltaTime);
    }

}
