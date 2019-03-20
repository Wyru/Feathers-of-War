using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLogic : MonoBehaviour
{
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


    void Awake()
    {
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
        if (started && nextRound >= Time.time )
        {
            if (inputArray[1] == inputArray[2])
            {
                if (inputArray[1] == "Attack")
                {
                    // PlayerHealth.TakeDamage(damageAttack);
                    // PlayerEnergy.consumeEnergy();
                }
                else if (inputArray[1] == "Defend")
                {
                    // PlayerEnergy.consumeEnergy();
                }
                else if (inputArray[1] == "Charge")
                {
                    // PlayerEnergy.addEnergy(amountCharge);
                }
                else // EVADE
                {
                    // PlayerEnergy.consumeEnergy();
                }
            }
            else
            {
                if (inputArray[1] == "Attack" && inputArray[2] == "Defend")
                {
                    // PlayerEnergy.consumeEnergy();
                    // PlayerHealth.TakeDamage(damageAttack-damageMitigation);
                }
                else if (inputArray[1] == "Attack" && inputArray[2] == "Evade")
                {

                }
                else if (inputArray[1] == "Attack" && inputArray[2] == "Chage")
                {

                }
                else if (inputArray[1] == "Evade" && inputArray[2] == "Attack")
                {

                }
                else if (inputArray[1] == "Evade" && inputArray[2] == "Defend")
                {

                }
                else if (inputArray[1] == "Evade" && inputArray[2] == "Charge")
                {

                }
                else if (inputArray[1] == "Defend" && inputArray[2] == "Attack")
                {

                }
                else if (inputArray[1] == "Defend" && inputArray[2] == "Charge")
                {

                }
                else if (inputArray[1] == "Defend" && inputArray[2] == "Evade")
                {

                }
                else if (inputArray[1] == "Charge" && inputArray[2] == "Attack")
                {

                }
                else if (inputArray[1] == "Charge" && inputArray[2] == "Defend")
                {

                }
                else if (inputArray[1] == "Charge" && inputArray[2] == "Evade")
                {

                }
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
