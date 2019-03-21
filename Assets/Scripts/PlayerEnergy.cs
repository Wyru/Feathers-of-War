using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    // TODO: Work on the HUD and do the operations.
    [SerializeField]
    private int initialEnergy = 3;
    private int currentEnergy;


    public GameObject[] hudEnergy;

    void Awake()
    {
        currentEnergy = 0;
        GetComponent<PlayerController>().OnCharge += addEnergy;
        GetComponent<PlayerController>().OnAttack += Attack;
        GetComponent<PlayerController>().OnEvade += Evade;
    }

    private void Start()
    {
        UpdateHudEnergy();
    }

    /// <summary>
    /// Verify if the player has energy to perform a hit.
    /// </summary>
    /// <param name="energyRequired">Integer based on hit cost</param>
    /// <returns>Returns true, false otherwise.</returns>
    public bool CanCast(int energyRequired)
    {
        if (currentEnergy >= energyRequired)
        {
            return true;
        }
        else
            return false;
    }

    /// <summary>
    /// Adds energy to a players pool.
    /// </summary>
    public void addEnergy()
    {
        currentEnergy++;
        if (currentEnergy > initialEnergy)
            currentEnergy = initialEnergy;
        UpdateHudEnergy();
    }

    /// <summary>
    /// Consume energy from a player.
    /// </summary>
    // / <param name="energyRequired">The amount of energy to consume.</param>
    public void Attack()
    {
        currentEnergy = 0;
        UpdateHudEnergy();
    }

    public void Evade()
    {
        currentEnergy -=1;
        UpdateHudEnergy();
    }

    private void UpdateHudEnergy()
    {
        int i = 0;
        foreach (GameObject energy in hudEnergy)
        {
            if (i < currentEnergy)
            {
                energy.SetActive(true);
            }
            else
            {
                energy.SetActive(false);
            }
            i++;
        }
    }
}
