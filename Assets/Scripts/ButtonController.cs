using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

namespace BabyGame
{

    public class ButtonController : MonoBehaviour
    {

        public void PlayGame()
        {
            if(Input.touchCount>0) // replacing Input.touchCount>0 for now
            {
                Debug.Log("Clicked");
                SceneManager.LoadScene(1);
            }
        }

        public void ReturnHome()
        {
            if(Input.touchCount>0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
