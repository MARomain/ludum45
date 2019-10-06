using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFirePLace : MonoBehaviour
{

    public GameObject light;
    public GameObject fire;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerGameManagerCallBacks>() != null)
        {
            light.SetActive(true);
            fire.SetActive(true);
        }
    }
}
