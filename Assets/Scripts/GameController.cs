using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Button playButton;
    Touch touch;

    void Start()
    {
        touch = Input.GetTouch(0);
        playButton.onClick.AddListener(PlayGame);
    }

    void Update()
    {
        PlayGame();
    }

    private void PlayGame()
    {

        if(Input.touchCount > 0 && touch.phase == TouchPhase.Began)
        {
            Debug.Log("Touch Detected");
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Click detected.");
        }
    }
}
