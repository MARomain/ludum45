using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFogOnPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Enable fog
        RenderSettings.fog = true;
    }
}
