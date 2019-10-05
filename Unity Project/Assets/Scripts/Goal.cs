using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public bool goalTouched = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerGameManagerCallBacks>() != null)
        {
            goalTouched = true;
        }
    }
}
