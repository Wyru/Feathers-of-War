using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance;


    [SerializeField]
    private float turnTime = 2f;
    [SerializeField]
    private float minTurnTime = 0.5f;
    [SerializeField]
    private float decreaseRate = 0.2f;          // Amount of seconds to subtract from turnTime in the end of turn.
    [SerializeField]
    private int damageMitigation = 20;          // Amount of damage mitigate from a attack when you use defense.
    [SerializeField]
    private int damageAttack = 30;              // Ammount of damage inflicted from a attack hit.
    [SerializeField]
    private int amountCharge = 1;               // Amount of energy to add to energy pool when use charge.

    private float nextRound;
    private bool started = false;

    private string[] inputArray;

    public PlayerController p1;
    public PlayerController p2;

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
        nextRound = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (started && nextRound >= Time.time)
        {
            switch (inputArray[1])
            {
                case "Attack":
                    p1.Attack();
                    break;

                case "Defend":
                    p1.Defend();
                    break;

                case "Charge":
                    p1.Charge();
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
                    p2.Attack();
                    break;

                case "Defend":
                    p2.Defend();
                    break;

                case "Charge":
                    p2.Charge();
                    break;

                case "Evade":
                    p2.Evade();
                    break;

                default:
                    //idle;
                    break;
            }

            inputArray[1] = "";
            inputArray[2] = "";

            if (turnTime > minTurnTime)
                turnTime -= decreaseRate;

            nextRound = Time.time + turnTime;
        }
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

        if (inputArray[index] != "") { inputArray[index] = inputName; }
    }

}
