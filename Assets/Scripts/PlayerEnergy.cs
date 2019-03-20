using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    // Não tem regen e chamar o script pra adicionar energia.

    [SerializeField]
    private float initialEnergy = 3f;
    [SerializeField]
    private float regenSpeed = 1f;
    private float currentEnergy;

    // TODO: Work on the HUD and do the operations.

    void Awake()
    {
        currentEnergy = initialEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        currentEnergy += regenSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Verify if the player has energy to perform a hit.
    /// </summary>
    /// <param name="energyRequired"></param>
    /// <returns>Returns true, false otherwise.</returns>
    protected bool CanCast(float energyRequired)
    {
        if (currentEnergy >= energyRequired)
        {
            currentEnergy -= energyRequired;
            return true;
        }
        else
            return false;
    }
}
