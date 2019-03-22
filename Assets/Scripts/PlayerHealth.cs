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
    private Slider healthSlider;
    [SerializeField]
    private AudioClip[] damageClips;

    // End Health Stuff
    private bool isDead = false;

    // ComebackStuff
    [SerializeField]
    private float startTimeCB;
    [SerializeField]
    private float comebackTimeCB = 10f;
    [SerializeField]
    private string buttonName = "";
    [SerializeField]
    private float regenRate = 0.5f;
    [SerializeField]
    private int combebackLimit = 3;
    [SerializeField]
    private Slider comebackSlider;

    private float actualRegen = 1;
    private PlayerController pController;
    private string playerNumber = "";
    private int comebackCount = 0;
    private float endTimeCB;
    private string buttonNameP1 = "";
    private string buttonNameP2 = "";
    private bool started = false;
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
        if (started)
        {
            // P1 always Add P2 always subtract
            //if (Input.GetButtonDown(buttonNameP1))
                //Value ++
            //if (Input.GetButtonDown(buttonNameP2))
                //Value --
        }

        // Finish the Comeback
        if (Time.time >= endTimeCB && started)
        {

            if (playerNumber == "1")
            {
                /* if (value <= 50)
                 * {
                 * Death();
                 * started = false;
                 * }
                 * else
                 * {
                 *                 // He survived
                 * started = false;
                 * comebackCount++;
                 *
                 * actualRegen *= regenRate;
                 * currentHealth = (int)(initialHealth * actualRegen);
                 *
                 * // Enable input from PlayerController
                 * // Load battlescreen
                 * }
                 */
            }
            else // P2
            {
                /* if (value >= 50)
                 * {
                 * Death();
                 * started = false;
                 * }
                 * else
                 * {
                 *                 // He survived
                 * started = false;
                 * comebackCount++;
                 *
                 * actualRegen *= regenRate;
                 * currentHealth = (int)(initialHealth * actualRegen);
                 *
                 * // Enable input from PlayerController
                 * // Load battlescreen
                 * }
                 */
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

        //int i = UnityEngine.Random.Range(0, damageClips.Length);
        //AudioSource.PlayClipAtPoint(damageClips[i], transform.position);

        if (comebackCount == combebackLimit)
        {
            Death();
        }

        if (currentHealth <= 0 && !isDead) { Comeback(); }
    }

    /// <summary>
    /// Add an amount of life to a player.
    /// </summary>
    /// <param name="amount">Integer with the amount to add.</param>
    public void AddLife(int amount)
    {
        if (currentHealth + amount > initialHealth)
        {   currentHealth = initialHealth;  }
        else
        {   currentHealth += amount;    }
    }

    /// <summary>
    /// Set the Comeback to start.
    /// </summary>
    public void StartComeback()
    {
        startTimeCB = Time.time;
        endTimeCB = startTimeCB + comebackTimeCB;

        // set comebackSlider value to 50
        started = true;
    }

    void Comeback()
    {
        // TODO: Comeback Feature
        // Disable input from PlayerController
        // Load te comback screen

        StartComeback();
    }

    void Death()
    {
        // TODO: Death Feature
        // Load te comback screen for playerNumber
    }
}
