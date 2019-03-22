using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance;

    [SerializeField]
    private float turnTime = 2f;
    [SerializeField]
    private float minTurnTime = 1f;
    [SerializeField]
    private float decreaseRate = 0.2f;          // Amount of seconds to subtract from turnTime in the end of turn.
    [SerializeField]
    private int damageMitigation = 20;          // Amount of damage mitigate from a attack when you use defense.
    [SerializeField]
    private int damageAttack = 30;              // Ammount of damage inflicted from a attack hit.
    [SerializeField]
    private AudioSource battleSound = null;

    private int defenseP1 = 0;
    private int defenseP2 = 0;

    private float nextRound;
    private float lastRound;
    private bool started = false;

    private string[] inputArray;

    public PlayerController p1;
    public PlayerController p2;

    public PlayerHealth p1Health;
    public PlayerHealth p2Health;

    public PlayerEnergy p1Energy;
    public PlayerEnergy p2Energy;

    public Image hudTimeDisplay;

    public static event Action OnEndTurn;

    void Awake()
    {
        Instance = this;

        inputArray = new string[3];

        inputArray[1] = "";
        inputArray[2] = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        started = true;
        nextRound = Time.time + turnTime;


        battleSound.Stop();
        battleSound.loop = true;
        battleSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputArray[1] == "Defend")
            defenseP1 = damageMitigation;

        if (inputArray[2] == "Defend")
            defenseP2 = damageMitigation;

        if (started && nextRound < Time.time)
        {
            switch (inputArray[1])
            {
                case "Attack":
                    p2Health.TakeDamage(damageAttack - defenseP2);
                    p1.Attack();
                    break;

                case "Defend":
                    p1.Defend();
                    break;

                case "Charge":
                    p1.Charge();
                    //p1Energy.addEnergy();
                    break;

                case "Evade":
                    p1.Evade();
                    break;

                default:
                    //idle;
                    break;
            }

            switch (inputArray[2])
            {
                case "Attack":
                    p1Health.TakeDamage(damageAttack - defenseP1);
                    p2.Attack();
                    break;

                case "Defend":
                    p2.Defend();
                    break;

                case "Charge":
                    p2.Charge();
                    //p2Energy.addEnergy(); 
                    break;

                case "Evade":
                    p2.Evade();
                    break;

                default:
                    //idle;
                    break;
            }

            defenseP1 = 0;
            defenseP2 = 0;

            //Debug.Log($"p1 action:{inputArray[1]}, p2 action:{inputArray[2]}");

            inputArray[1] = "";
            inputArray[2] = "";

            
            if (turnTime > minTurnTime)
                turnTime -= decreaseRate;
            
            lastRound = nextRound;
            nextRound = Time.time + turnTime;

            if (OnEndTurn != null)
            {
                OnEndTurn.Invoke();
            }
        }

        UpdateTimeCounter();

    }

    /// <summary>
    /// Sets timeCount to start properly.
    /// </summary>
    public void StartGame() { nextRound = Time.time; started = true; }

    /// <summary>
    /// Pauses the turn process.
    /// </summary>
    public void PauseGame() { started = false; }

    /// <summary>
    /// Pair inputs from players.
    /// </summary>
    /// <param name="playerNumber">Players Number (1 or 2).</param>
    /// <param name="inputName">Input Name (Charge, Attack, Defend, Evade).</param>
    public void GetInput(string playerNumber, string inputName)
    {
        int index = 0;
        Int32.TryParse(playerNumber, out index);
        if (inputArray[index] == "") { inputArray[index] = inputName; }
    }


    public void UpdateTimeCounter()
    {

        hudTimeDisplay.fillAmount = 1 - (Time.time - lastRound) / turnTime;


    }

}
