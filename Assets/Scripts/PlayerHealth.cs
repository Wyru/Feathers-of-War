using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Health Stuff
    [SerializeField]
    private int initialHealth = 100;
    private int currentHealth;
    [SerializeField]
    private Slider healthSlider = null;

    // End Health Stuff
    private bool isDead = false;

    // ComebackStuff
    [SerializeField]
    private float startTimeCB;
    [SerializeField]
    private float comebackTimeCB = 10f;
    [SerializeField]
    private string buttonName = "Attack";
    [SerializeField]
    private float regenRate = 0.5f;
    [SerializeField]
    private int combebackLimit = 3;
    [SerializeField]
    private Slider comebackSlider = null;

    private float actualRegen = 1;
    private PlayerController pController;
    private string playerNumber = "";
    private int comebackCount = 0;
    private float endTimeCB;
    private string buttonNameP1 = "";
    private string buttonNameP2 = "";
    public bool started = false;
    // Ene Comeback Stuff

    void Awake()
    {
        currentHealth = initialHealth;

        pController = GetComponent<PlayerController>();

        playerNumber = pController.playerNumber;

        buttonNameP1 = String.Concat(buttonName, "_P1");
        buttonNameP2 = String.Concat(buttonName, "_P2");
    }

    void Update()
    {
        healthSlider.value = currentHealth;

        if (started && !isDead)
        {
            if (Input.GetButtonDown(buttonNameP1))
                comebackSlider.value++;
            if (Input.GetButtonDown(buttonNameP2))
                comebackSlider.value--;
        }

        // Finish the Comeback
        if (Time.time >= endTimeCB && started && !isDead)
        {
            if (comebackSlider.value <= 50)
            {
                isDead = true;
                Death();
            }
            else
            {
                // He survived
                started = false;
                comebackCount++;

                actualRegen *= regenRate;
                currentHealth = (int)(initialHealth * actualRegen);

                // TODO: Go back to battle
            }

        }
    }

    /// <summary>
    /// Performe the damage Operations.
    /// </summary>
    /// <param name="amount">The amount of damage inflicted to a player.</param>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if (comebackCount == combebackLimit)
        {
            isDead = true;
            Death();
        }

        if (currentHealth <= 0 && !isDead) { StartComeback(); }
    }

    /// <summary>
    /// Add an amount of life to a player.
    /// </summary>
    /// <param name="amount">Integer with the amount to add.</param>
    public void AddLife(int amount)
    {
        if (currentHealth + amount > initialHealth)
        { currentHealth = initialHealth; }
        else
        { currentHealth += amount; }
    }

    /// <summary>
    /// Set the Comeback to start.
    /// </summary>
    public void StartComeback()
    {
        startTimeCB = Time.time;
        endTimeCB = startTimeCB + comebackTimeCB;

        comebackSlider.value = 50;
        started = true;

        // TODO: Fazer aparecer coisas do comeback
    }

    void Death()
    {
        
        // TODO: Death Feature
        // Load te comback screen for playerNumber
    }
}
