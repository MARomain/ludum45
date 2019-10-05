using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool timerPlay = false;
    public float timeLeft = 20f;
    public PlayerGameManagerCallBacks player;
    public Goal goal;
    public Transform startTransform;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerPlay == true)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = (timeLeft).ToString("1");
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
        //reset la position du joueur
        player.transform.position = startTransform.position;
        player.transform.rotation = startTransform.rotation;

        //DisableMovementInputs

        //Tant qu'il ne clique pas sur une touche la game ne commence pas
        while (player.anyKey == false)
        {
            yield return null;
        }
    }

    private IEnumerator GamePlaying()
    {
        //EnableMovementInputs

        //Lancement du timer
        timerPlay = true;

        while (goal.goalTouched == false)
        {
            if (timeLeft <= 0f)
                yield return null;
        }
    }

    private IEnumerator DidYouWin()
    {
        //si le joueur a gagné
        if(goal.goalTouched == true)
        {
            Debug.Log("YOU WON");
            yield return null; // peut être l'amener dans une autre coroutine "ecran de fin"
        }
        else
        {
            Debug.Log("Start over again");
            yield return null; // a voir si y'a un certains nombre de try et après une défaite
        }

    }
}
