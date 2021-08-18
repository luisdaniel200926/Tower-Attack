using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Player : MonoBehaviour
{
    public Button[] TutorialsButton;
    private int TutorialRound = 1;

    public Image GameOverTime;
    public Image GameOverBlue;
    public Button PlayAgainButton;
    public Button MenuButton;
    public Button NextLevelButton;
    public Image WonImage;


    public GameObject prefabGiant;
    public Text GiantPriceTxt;
    private float TimetoSpawnGiant = 1.5f;
    public GameObject prefabMidget;
    public Text MidgetPriceTxt;
    private float TimetoSpawnMidget = .7f;
    public GameObject prefabSnake;
    public Text SnakePriceTxt;
    private float TimetoSpawnSnake = .5f;

    private float TimetoFreeze = 25f;
    private float TimetoHeal = 20f;

    public Button SnakeButton;
    public Button MidgetButton;
    public Button GiantButton;
    public Button FreezeButton;
    public Button HealthButton;

    private GameObject _Giant;
    private GameObject _Midget;
    private GameObject _Snake;

    public Text CoinText;
    public Text MinionText;
    public Text TextMinionsToWin;

    private int _Minions;


    public Text PriceFreezeTxt;
    public Text PriceHealTxt;
    public Text TimeText;

    private GameObject[] TowersInScene;
    private GameObject[] MinionsInScene;

    private int GiantCost;
    private int SnakeCost;
    private int MidgetCost;

    private float timerGenerateGiant = 100;
    private float timerGenerateMidget = 100;
    private float timerGenerateSnake = 100;
    private float timerGenerateFreeze = 100;
    private float timerGenerateHeal = 100;

    private Color grayColor;
    private Color normalColor;


    public float GameInitialTime;
    private float GameTimer;

    public int _Coins;
    public int startCoins = 3000;

    public int FreezeCost = 300;
    public float PTimeFreezed = 3.5f;
    public AudioClip FreezeSound;

    public int HealCost = 150;
    public float HealAmount = 20;
    public AudioClip HealSound;

    public Vector3 initialPosition;
    public int MinionsToWin;
    public AudioClip EndReachedSound;

    public int MoneyPerSecond = 10;
    public float intervalMoney = 1;
    float nextPayTime;



    void Start()
    {
        GameTimer = GameInitialTime;
        
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 1f;
        _Coins = startCoins;

        //Grabs info of the prebafs (Before the Scripts)

        GiantCost = prefabGiant.GetComponent<Minions>().cost;
        SnakeCost = prefabSnake.GetComponent<Minions>().cost;
        MidgetCost = prefabMidget.GetComponent<Minions>().cost;

        InitializeUI();

    }

    void Update()
    {
        GameTimer -= Time.deltaTime;
        TimeText.text = "" + Math.Round(GameTimer);
        if(GameTimer <= 0)
        {
            Time.timeScale = 0f;
            Time.fixedDeltaTime = 0f;
            GameOver();
        }
        MoneyGenerateOverTime();

        if(timerGenerateGiant <= TimetoSpawnGiant)
        {
            Generating("Giant");
        }

        if (timerGenerateMidget <= TimetoSpawnMidget)
        {
            Generating("Midget");
        }

        if (timerGenerateSnake <= TimetoSpawnSnake)
        {
            Generating("Snake");
        }

        if (timerGenerateFreeze <= TimetoFreeze)
        {
            GeneratingPowers("Freeze");
        }

        if (timerGenerateHeal <= TimetoHeal)
        {
            GeneratingPowers("Heal");
        }

    }

    //Instantiate Minions
    public void CreateGiant()
    {
        _Giant = Instantiate(prefabGiant);
        _Giant.transform.position = initialPosition;
    }
    public void CreateMidget()
    {
        _Midget = Instantiate(prefabMidget);
        _Midget.transform.position = initialPosition;
    }
    public void CreateSnake()
    {
        _Snake = Instantiate(prefabSnake);
        _Snake.transform.position = initialPosition;
    }

    //Start timer to generate the Minions, take different time to eachone
    public void StartTimer(string Minion)
    {
        
        if (Minion.Equals("Giant"))
        {
            if (_Coins >= GiantCost)
            {
                _Coins = _Coins - GiantCost;

                timerGenerateGiant = TimetoSpawnGiant;
                GiantButton.enabled = false;
            }
            CoinText.text = "" + _Coins;

        }
        else if (Minion.Equals("Midget"))
        {
            if (_Coins >= MidgetCost)
            {
                _Coins = _Coins - MidgetCost;
                timerGenerateMidget = TimetoSpawnMidget;
                MidgetButton.enabled = false;
            }
            CoinText.text = "" + _Coins;
        }
        else if (Minion.Equals("Snake"))
        {
            if (_Coins >= SnakeCost)
            {
                _Coins = _Coins - SnakeCost;
                timerGenerateSnake = TimetoSpawnSnake;
                SnakeButton.enabled = false;
            }
            CoinText.text = "" + _Coins;

        }

    }

    public void StartTimerPowers(string Power)
    {

        if (Power.Equals("Freeze"))
        {
            if (_Coins >= FreezeCost)
            {
                _Coins = _Coins - FreezeCost;
                timerGenerateFreeze = TimetoFreeze;
                FreezeTowers();
            }
            CoinText.text = "" + _Coins;
        }
        else if (Power.Equals("Heal"))
        {
            if (_Coins >= MidgetCost)
            {
                _Coins = _Coins - MidgetCost;
                timerGenerateHeal = TimetoHeal;
                HealMinions();
            }
            CoinText.text = "" + _Coins;
        }

    }

    public void Generating(string Minion)
    {
        if (Minion.Equals("Giant"))
        {
            timerGenerateGiant -= Time.deltaTime;

            if (timerGenerateGiant <= 0)
            {
                CreateGiant();
                GiantButton.enabled = true;
                //GiantButton.interactable = true;
                //GiantButton.image.color = normalColor;
                timerGenerateGiant = 100;
            }
        }
        else if (Minion.Equals("Midget"))
        {
            timerGenerateMidget -= Time.deltaTime;

            if (timerGenerateMidget <= 0)
            {
                CreateMidget();
                MidgetButton.enabled = true;
                //MidgetButton.interactable = true;
                //MidgetButton.image.color = normalColor;
                timerGenerateMidget = 100;
            }
        }
        else if (Minion.Equals("Snake"))
        {
            timerGenerateSnake -= Time.deltaTime;

            if (timerGenerateSnake <= 0)
            {
                CreateSnake();
                SnakeButton.enabled = true;
                //SnakeButton.interactable = true;
                //SnakeButton.image.color = normalColor;
                timerGenerateSnake = 100;
            }
        }
    }

    public void GeneratingPowers(string Power)
    {
        if (Power.Equals("Freeze"))
        {
            timerGenerateFreeze -= Time.deltaTime;

            if (timerGenerateFreeze <= 0)
            {
                FreezeButton.interactable = true;
                timerGenerateFreeze = 100;
            }
        }
        else if (Power.Equals("Heal"))
        {
            timerGenerateHeal -= Time.deltaTime;

            if (timerGenerateHeal <= 0)
            {
                HealthButton.interactable = true;
                timerGenerateHeal = 100;
            }
        }
    }

    public void EndReached()
    {
        //Check if the player won
        if (_Minions != MinionsToWin)
        {
            GetComponent<AudioSource>().clip = EndReachedSound;
            GetComponent<AudioSource>().Play();
            _Minions = int.Parse(MinionText.text);
            _Minions++;
            MinionText.text = "" + _Minions;
            if(_Minions == MinionsToWin)
            {
                Time.timeScale = .1f;
                Won();
            }
        }


    }

    public void FreezeTowers()
    {
        TowersInScene = GameObject.FindGameObjectsWithTag("Turret");
        GetComponent<AudioSource>().clip = FreezeSound;
        GetComponent<AudioSource>().Play();
        for (int i = 0; i < TowersInScene.Length; i++)
        {
            TowersInScene[i].GetComponent<Towers>().TimeFreezed = PTimeFreezed;
            TowersInScene[i].GetComponent<Towers>().Freezed = true;
        }

        FreezeButton.interactable = false;
    }

    public void HealMinions()
    {
        MinionsInScene = GameObject.FindGameObjectsWithTag("Enemy");
        GetComponent<AudioSource>().clip = HealSound;
        GetComponent<AudioSource>().Play();
        for (int i = 0; i < MinionsInScene.Length; i++)
        {
            MinionsInScene[i].GetComponent<Minions>().MakeHeal(HealAmount);
        }

        HealthButton.interactable = false;
    }

    public void InitializeUI()
    {
        GameOverTime.gameObject.SetActive(false);
        //GameOverBlue.gameObject.SetActive(false);
        PlayAgainButton.gameObject.SetActive(false);
        MenuButton.gameObject.SetActive(false);
        WonImage.gameObject.SetActive(false);
        NextLevelButton.gameObject.SetActive(false);
        TextMinionsToWin.text = "" + MinionsToWin;
        MinionText.text = "0";
        CoinText.text = "" + _Coins;
        GiantPriceTxt.text = "$ " + GiantCost;
        SnakePriceTxt.text = "$ " + SnakeCost;
        MidgetPriceTxt.text = "$ " + MidgetCost;
        PriceHealTxt.text = "$ " + HealCost;
        PriceFreezeTxt.text = "$ " + FreezeCost;

    }

    public void GameOver()
    {
        GameOverTime.gameObject.SetActive(true);
        GameOverBlue.gameObject.SetActive(true);
        PlayAgainButton.gameObject.SetActive(true);
        MenuButton.gameObject.SetActive(true);
    }

    public void Won()
    {
        WonImage.gameObject.SetActive(true);
        GameOverBlue.gameObject.SetActive(true);
        PlayAgainButton.gameObject.SetActive(true);
        MenuButton.gameObject.SetActive(true);
        NextLevelButton.gameObject.SetActive(true);
    }

    public void TutorialMidgetTurret()
    {
        TutorialsButton[0].gameObject.SetActive(false);
        GameOverBlue.gameObject.SetActive(false);
        GiantButton.interactable = false;
        SnakeButton.interactable = false;
        HealthButton.interactable = false;
        FreezeButton.interactable = false;
    }
    public void TutorialGiantMissile()
    {
        TutorialsButton[0].gameObject.SetActive(false);
        GameOverBlue.gameObject.SetActive(false);
        MidgetButton.interactable = false;
        SnakeButton.interactable = false;
        HealthButton.interactable = false;
        FreezeButton.interactable = false;
    }
    public void TutorialSnakeFreezer()
    {
        TutorialsButton[0].gameObject.SetActive(false);
        GameOverBlue.gameObject.SetActive(false);
        MidgetButton.interactable = false;
        GiantButton.interactable = false;
        HealthButton.interactable = false;
        FreezeButton.interactable = false;
    }
    public void TutorialPowers()
    {
        TutorialsButton[0].gameObject.SetActive(false);
        GameOverBlue.gameObject.SetActive(false);
    }
    public void UpdateCoins()
    {
        CoinText.text = "" + _Coins;
    }
    //Money each second 
    public void MoneyGenerateOverTime()
    {
        if (Time.time > nextPayTime)
        {
            _Coins += MoneyPerSecond;
            nextPayTime = Time.time + intervalMoney;
            UpdateCoins();
        }
    }
}
