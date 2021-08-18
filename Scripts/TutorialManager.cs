using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Slider slider;
    public Image[] images;
    public Button NextButton1;
    public Button NextButton2;

    void Start()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
        NextButton1.gameObject.SetActive(true);
        NextButton2.gameObject.SetActive(false);

        for (int i=0; i<9; i++)
        {
            images[i].gameObject.SetActive(false);
        }
    }




    public void ChangeSliderValue()
    {
        slider.value++;
    }

    public void ChangeTutorialScene()
    {
        
        int number;
        number = (int)slider.value;

        if (number < 9)
        {
            NextButton1.gameObject.SetActive(true);
            NextButton2.gameObject.SetActive(false);
            for (int i = 0; i < 9; i++)
            {
                images[i].gameObject.SetActive(false);
            }
            images[number].gameObject.SetActive(true);
        }
        else if (number == 9)
        {
            for (int i = 0; i < 9; i++)
            {
                images[i].gameObject.SetActive(false);
            }
            NextButton1.gameObject.SetActive(false);
            NextButton2.gameObject.SetActive(true);
        }



        
    }
}
