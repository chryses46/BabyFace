using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BabyGame;

public class UIHandler : MonoBehaviour
{
    ColliderHandler ch;
    ScoreBoard sb;
    Animator anim;
    [SerializeField] Text highScore;
    [SerializeField] Text partText;
    [SerializeField] Text feedback;
    [SerializeField] Text score;
    [SerializeField] Image faceImage;
    [SerializeField] Sprite normalFace;
    [SerializeField] Sprite successFace;
    [SerializeField] Sprite failFace;
    private List<string> failMsg = new List<string>() 
    {
        "Try again!",
        "Not that one!",
        "Almost!",
        "Not quite!",
        "One more time!"
    };

    private List<string> successMsg = new List<string>()
    {
        "Good job!",
        "That's right!",
        "Great work!",
        "Awesome!",
        "Excellent!",
        "Fantastic!"
    };
    public string CurrentPartName {get; set;}
    private string PreviousMessage {get; set;}

    void Awake()
    {
        ch = GetComponent<ColliderHandler>();
        sb = GetComponent<ScoreBoard>();
        anim = faceImage.GetComponent<Animator>();
        GeneratePartName();
        SetFace(normalFace);
        ResetScore();
    }

    private void ResetScore()
    {
        sb.Score = 0;
        score.text = "Score: " + sb.Score;
    }

    private void SetFace(Sprite face)
    {
        faceImage.sprite = face;
    }

    public IEnumerator JudgementPhase(bool success)
    {
        if(success)
        {
            SendMessage(successMsg);
            ScoreIncrease();
            SetFace(successFace);
            anim.SetBool("playing", true);
            yield return new WaitForSeconds(1);
            anim.SetBool("playing", false);
            SetFace(normalFace);
            GeneratePartName();
            ClearMessage();
            ch.isTouched = false;
        }
        else
        {
            SendMessage(failMsg);
            SetFace(failFace);
            sb.SetHighScore();
            yield return new WaitForSeconds(1);
            SetFace(normalFace);
            ResetScore();
            ClearMessage();
            ch.isTouched = false;
        }
    }

    private void ScoreIncrease()
    {
        sb.Score += 1;
        if(sb.Score > sb.HighScore)
        {
            sb.HighScore = sb.Score;
            highScore.text = "High Score: " + sb.HighScore;
        }
        score.text = "Score: " + sb.Score; 
    }

    private void GeneratePartName()
    {
        string newPartName = CurrentPartName;

        while(newPartName == CurrentPartName)
        {
            newPartName = ch.parts[(int)Random.Range(0, ch.parts.Count)].gameObject.name;
        }

        CurrentPartName = newPartName;

        partText.text = "Touch the " + CurrentPartName;
    }

    private void SendMessage(List<string> list)
    {
        string newMessage = list[(int)Random.Range(0, list.Count)];

        while(PreviousMessage == newMessage)
        {
            newMessage = list[(int)Random.Range(0, list.Count)];
        }

        PreviousMessage = newMessage;
        feedback.text = newMessage;
    }

    private void ClearMessage()
    {
        feedback.text = null;
    }
}
