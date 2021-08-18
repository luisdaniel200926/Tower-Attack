using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPausePlay : MonoBehaviour
{

    public Button PauseButton;
    public Button PlayButton;

    public Button X2Button;
    public Button X1Button;

    public Image UiImage;
    public Image PauseImage;
    public Image StatsImage;

    public Button PlayAgainButton;
    public Button MenuButton;


    void Start()
    {
        PlayButton.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(true);
        UiImage.gameObject.SetActive(true);
        PauseImage.gameObject.SetActive(false);
        StatsImage.gameObject.SetActive(false);

        PlayAgainButton.gameObject.SetActive(false);
        MenuButton.gameObject.SetActive(false);

        X2Button.gameObject.SetActive(true);
        X1Button.gameObject.SetActive(false);
    }

    public void ChangeToScenePause()
    {
        PlayButton.gameObject.SetActive(true);
        PauseButton.gameObject.SetActive(false);
        UiImage.gameObject.SetActive(false);
        PauseImage.gameObject.SetActive(true);
        StatsImage.gameObject.SetActive(true);

        PlayAgainButton.gameObject.SetActive(true);
        MenuButton.gameObject.SetActive(true);


        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
    }

    public void ChangeToScenePlay()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 1f;

        PlayButton.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(true);
        UiImage.gameObject.SetActive(true);
        PauseImage.gameObject.SetActive(false);
        StatsImage.gameObject.SetActive(false);
        PlayAgainButton.gameObject.SetActive(false);
        MenuButton.gameObject.SetActive(false);

    }

    public void SetX2()
    {
        Time.timeScale = 2f;
        Time.fixedDeltaTime = 2f;

        X2Button.gameObject.SetActive(false);
        X1Button.gameObject.SetActive(true);
    }
    public void SetX1()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 1f;

        X1Button.gameObject.SetActive(false);
        X2Button.gameObject.SetActive(true);
    }

}

