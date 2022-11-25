using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI responseText;

    public GameObject canvasQuestions;
    public string aimQuest;
    public string [] questionsArray;
    public string[] responseCorrect;
    public string[] tagArray;
    public int numQuestion = 0;
    public int numSound = 0;

    public GameObject[] compareObjectsArray;
    public AudioClip[] soundsGame;
    public AudioSource audioPlayer;
    public bool isCourutineActive = true;

    public Image imageBackgroundQuestionCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
         //   DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }



    }

    private void Start()
    {
        questionText.text = "Welcome to the Best Business Place";
        audioPlayer.clip = soundsGame[numSound];
        audioPlayer.Play();
        Invoke("SetTextQuestionPoint", 5f);

    }


    public void SetTextQuestionPoint()
    {
        questionsArray = new string[] { "There are two meetings rooms", "There is an internet connection, a pc and a printer place", "There is a big CEO DESK", "There is a big-screen tv", "There is a relaxation room" };
        tagArray = new string[] {"TwoOffice","PaperPrintAndPC","CeoDesk", "BigScreentTV","RelaxationRoom"};
        questionText.text = questionsArray[numQuestion];
        NextSound();
        aimQuest = tagArray[numQuestion];
    }

    public void Setinstrucctions()
    {


    }

    public void nextQuestionPoint()
    {
            numQuestion = numQuestion + 1;
        if (numQuestion != 5)
        {
            //   compareObjectsArray[numQuestion - 1 ].SetActive(false);
            compareObjectsArray[numQuestion - 1].GetComponent<Collider>().enabled = false;
            compareObjectsArray[numQuestion - 1].tag = "Untagged";
            questionText.text = questionsArray[numQuestion];
            NextSound();
            aimQuest = tagArray[numQuestion];
            compareObjectsArray[numQuestion].SetActive(true);
            compareObjectsArray[numQuestion].GetComponent<Collider>().enabled = true;

        }
        else
        {
        compareObjectsArray[numQuestion - 1].GetComponent<Collider>().enabled = false;
            QuestionsToResponse();
        }

    }

    public void QuestionsToResponse()
    {

        //GameObject.Find(aimQuest).SetActive(false);
        canvasQuestions.SetActive(true);
        numQuestion = 0;
        questionText.text = "Look the questions and response";
        NextSound();
        questionsArray = new string[] {"Is there a coffe shop station?", "Are there any large windows?", "Is there a drinks machine?","Are there any plants or flowers?","Is there a bookcase?" };
        responseCorrect = new string[] {"Yes","Yes", "Yes", "Yes", "Yes"};
        Invoke("NextSound",2f);
        responseText.text = questionsArray[numQuestion];

    }

    public void NextResponse()
    {
        if (numQuestion < 4)
        {
            numQuestion = numQuestion + 1;
            NextSound();
            responseText.text = questionsArray[numQuestion];
        }
        else
        {
            questionText.text = "Congratulations";
            responseText.text = "Congratulations";
            NextSound();
            StartCoroutine(GameManager.instance.ResetLevel());
        }
     
    }


    public void buttonResponse(string buttonResponse)
    {
        switch (buttonResponse)
        {
            case "Yes":
                ResponseColorBackground(buttonResponse);
                NextResponse();
                break;
            case "No":
                ResponseColorBackground(buttonResponse);

                NextResponse();
                break;
            case "I dont know":
                ResponseColorBackground(buttonResponse);

                NextResponse();
                break;       
        }
    }

    public IEnumerator waitLerp(GameObject lerp)
    {
        isCourutineActive = false;

        Outline[] outs = lerp.GetComponentsInChildren<Outline>();
        foreach (Outline ots in outs)
        {
            ots.enabled = true;
        }

        
        yield return new WaitForSeconds(3f);

        foreach (Outline ots in outs)
        {
            ots.enabled = false;
        }

        isCourutineActive = true;
        nextQuestionPoint();

    }
   


    public void NextSound()
    {

        numSound = numSound + 1;
        print("Este es el numero del audio " + numSound);
        audioPlayer.clip = soundsGame[numSound];
        audioPlayer.Play();
    }

    public void ResponseColorBackground(string response)
    {
        if (responseCorrect[numQuestion].Equals(response))
        {
            imageBackgroundQuestionCanvas.color = Color.green;

        }
        else if (response.Equals("I dont know"))
        {
            imageBackgroundQuestionCanvas.color = Color.yellow;



        }
        else
        {
            imageBackgroundQuestionCanvas.color = Color.red;
        }
    }




}
