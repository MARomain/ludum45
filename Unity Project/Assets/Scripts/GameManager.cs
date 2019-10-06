using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool timerPlay = false;
    public float timeLeft = 20f;
    public float timeMax = 20f;
    public LightFirePLace[] fires;
    public int fireUp;
    public int goalNumber = 6;
    public PlayerGameManagerCallBacks player;
    public Goal goal;
    public Transform startTransform;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeMax;

        StartCoroutine(GameLoop());
    }

    // Update is called once per frame
    void Update()
    {
        if(timerPlay == true)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = timeLeft.ToString("F1");
        }
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(GameStart());

        yield return StartCoroutine(GamePlaying());

        yield return StartCoroutine(DidYouWin());

        StartCoroutine(GameLoop());
    }

    private IEnumerator GameStart()
    {
        Debug.Log("GameStart");

        ResetVariables();

        //reset la position du joueur
        player.transform.position = startTransform.position;

        //DisableMovementInputs

        //Tant qu'il ne clique pas sur une touche la game ne commence pas
        while (player.anyKey == false)
        {
            yield return null;
        }
    }

    private IEnumerator GamePlaying()
    {
        Debug.Log("GamePlaying");

        //EnableMovementInputs

        //Lancement du timer
        timerPlay = true;

        while (fireUp < goalNumber)
        {
            yield return null;
            if (timeLeft <= 0f)
            {
                timerPlay = false;
                yield break;
            }
        }
    }

    private IEnumerator DidYouWin()
    {
        Debug.Log("DidYouWin?");

        //si le joueur a gagné
        if (fireUp >= goalNumber)
        {
            Debug.Log("YOU WON");
            yield return null; // peut être l'amener dans une autre coroutine "ecran de fin"

            //écran de fin "YOU WON IN X SECOND
            //bouton "press here to restart"
            //bouton "press here to close"
        }
        else
        {
            Debug.Log("Start over again");
            yield return null; // a voir si y'a un certains nombre de try et après une défaite
            
            //écran "You have to light all the fire in less then a minute
            //bouton "start over ?"
            //bouton "quit"
        }

    }

    public void ResetVariables()
    {
        player.anyKey = false;
        timeLeft = timeMax;
        timerText.text = timeLeft.ToString("F1");
        goal.goalTouched = false;
        timerPlay = false;
        fireUp = 0;

        for (int i = 0; i < fires.Length; i++)
        {
            fires[i].lit = false;
        }
    }
}
