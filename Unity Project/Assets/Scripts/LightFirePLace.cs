using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFirePLace : MonoBehaviour
{

    public GameObject light;
    public GameObject fire;
    public GameManager gameManager;
    public bool lit;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerGameManagerCallBacks>() != null)
        {
            if(lit == false)
            {
                gameManager.fireUp++;
                lit = true;
            }
            
        }
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(lit)
        {
            light.SetActive(true);
            fire.SetActive(true);
        }
        else
        {
            light.SetActive(false);
            fire.SetActive(false);
        }
    }
}
