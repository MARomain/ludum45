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
    public AudioSource audioSource;
    public AudioClip mainMusic;
    public AudioClip winMusic;
    public GameObject UIWin;
    public GameObject UILose;
    public GameObject StartUI;
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

        StartUI.SetActive(false);
        //EnableMovementInputs

        //Lancement du timer
        timerPlay = true;
        audioSource.clip = mainMusic;
        audioSource.Play();

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

            StartCoroutine(YouWonScreen());

            yield return new WaitForSecondsRealtime(999999999999999999f);

        }
        else
        {
            StartCoroutine(YouLoseScreen());
            yield return new WaitForSecondsRealtime(999999999999999999f);


            //écran "You have to light all the fire in less then a minute
            //bouton "start over ?"
            //bouton "quit"
        }


    }

    private IEnumerator YouWonScreen()
    {
        Debug.Log("YOU WON");
        audioSource.Stop();
        audioSource.clip = winMusic;
        audioSource.Play();
        UIWin.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        timerPlay = false;
        yield return new WaitForSecondsRealtime(999999999999999999f);

    }

    private IEnumerator YouLoseScreen()
    {
        Debug.Log("Start over again");
        audioSource.Stop();
        UILose.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        timerPlay = false;


        yield return new WaitForSecondsRealtime(999999999999999999f);
    }

    public void ResetVariables()
    {
        player.anyKey = false;
        timeLeft = timeMax;
        timerText.text = timeLeft.ToString("F1");
        goal.goalTouched = false;
        timerPlay = false;
        fireUp = 0;
        UIWin.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        for (int i = 0; i < fires.Length; i++)
        {
            fires[i].lit = false;
        }
    }
}
