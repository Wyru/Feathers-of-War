using UnityEngine;

namespace GameLogicV2
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] float maxLife;
        [SerializeField] float currentLife;

        [SerializeField] float maxEnergy;
        [SerializeField] float currentEnergy;

        [SerializeField] int maxComebacks;
        [SerializeField] int comebacks;

        [SerializeField] bool dead;
        public void ChangeLife(float amount){
            if(amount > 0){
                currentLife = Mathf.Max(maxLife,currentLife+amount);
            }
            else{
                currentLife = Mathf.Max(0,currentLife+amount);
                if(currentLife == 0){
                    comebacks--;
                    dead = true;  
                }
            }
        }

        public void GainEnery(){
            currentEnergy = Mathf.Min(maxEnergy, currentEnergy++);
        }

        public void LoseEnery(){
            currentEnergy = 0;
        }

        public bool IsAlive()
        {
            return !dead;
        }

        public bool CanComeback(){
            return comebacks < maxComebacks;
        }

        

    }
}
