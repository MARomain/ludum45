using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camscript : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        float[] distances = new float[32];
        distances[0] = 10f; //smaller than your camera clipping planes's far value
        Camera.main.layerCullDistances = distances;
        Camera.main.layerCullSpherical = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cam.layerCullSpherical);

    }
}
