using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {

    Vector3 rotate = new Vector3(0, 0, 30);
    public GameObject rott;
    private void Update()
    {
        rott.transform.Rotate(rotate * Time.deltaTime);
    }

}
