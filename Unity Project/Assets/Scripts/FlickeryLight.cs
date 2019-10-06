using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeryLight : MonoBehaviour
{
    public Light light;
    public float speed = 2f;
    public float multiplierKinda = 3f;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        light.intensity = Mathf.Sin(Time.time *speed) + multiplierKinda;
    }
}
