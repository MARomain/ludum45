using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeryLight : MonoBehaviour
{
    public Light light;
    public float multiplier = 2f;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        light.intensity = Mathf.Sin(Time.time *multiplier) +1.5f;
    }
}
