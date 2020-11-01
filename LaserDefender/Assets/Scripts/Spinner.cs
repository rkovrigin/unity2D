using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float speedOfSpin = 100f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Spin " + Time.deltaTime);
        transform.Rotate(0, 0, speedOfSpin*Time.deltaTime);
    }
}
