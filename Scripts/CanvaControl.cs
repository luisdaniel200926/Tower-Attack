using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvaControl : MonoBehaviour
{
    public Button ButtonPlay;
    public Button ButtonTutorial;
    public Button ButtonEasy;
    public Button ButtonMedium;
    public Button ButtonHard;

    public Button ButtonReturn;

    public Button buttonCredits;
    public Image background;
    public Text creditsText;


    public void ChangeButtons()
    {
        ButtonPlay.gameObject.SetActive(false);
        ButtonTutorial.gameObject.SetActive(false);
        buttonCredits.gameObject.SetActive(false);

        ButtonEasy.gameObject.SetActive(true);
        ButtonMedium.gameObject.SetActive(true);
        ButtonHard.gameObject.SetActive(true);
        ButtonReturn.gameObject.SetActive(true);
    }

    public void ChangeScene(string NewScene)
    {
        SceneManager.LoadScene(NewScene, LoadSceneMode.Single);
    }

    public void ChangeButtonsReturn()
    {
        ButtonPlay.gameObject.SetActive(true);
        ButtonTutorial.gameObject.SetActive(true);

        ButtonEasy.gameObject.SetActive(false);
        ButtonMedium.gameObject.SetActive(false);
        ButtonHard.gameObject.SetActive(false);
        ButtonReturn.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);
        buttonCredits.gameObject.SetActive(true);
    }

    public void SetCreditsScene()
    {
        buttonCredits.gameObject.SetActive(false);
        ButtonPlay.gameObject.SetActive(false);
        ButtonTutorial.gameObject.SetActive(false);

        background.gameObject.SetActive(true);
        creditsText.gameObject.SetActive(true);

        ButtonReturn.gameObject.SetActive(true);
    }

    public void InitializeMenu()
    {
        buttonCredits.gameObject.SetActive(true);
        ButtonPlay.gameObject.SetActive(true);
        ButtonTutorial.gameObject.SetActive(true);

        ButtonEasy.gameObject.SetActive(false);
        ButtonMedium.gameObject.SetActive(false);
        ButtonHard.gameObject.SetActive(false);

        background.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);
        ButtonReturn.gameObject.SetActive(false);
    }
}

