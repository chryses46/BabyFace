using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BabyGame;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class ColliderHandler : MonoBehaviour
{
    UIHandler ui;

    public List<Collider2D> parts = new List<Collider2D>();

    void Awake()
    {
        ui = GetComponent<UIHandler>();
    }

    public bool isTouched = false;

    void Update()
    {
        if(!isTouched)
        {
            CheckforTouch();
        }
    }

    private void CheckforTouch()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) //replacing 'Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began'
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero); //replacing 'Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero)'
            if(hit.collider !=null)
            {
                string clickedPart = hit.collider.gameObject.name;

                if(clickedPart == ui.CurrentPartName)
                {
                    isTouched = true;
                    StartCoroutine(ui.JudgementPhase(true));
                }
                else
                {
                    isTouched = true;
                    StartCoroutine(ui.JudgementPhase(false));
                }
            }
        }
    }
}
