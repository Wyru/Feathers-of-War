using UnityEngine;


namespace GameLogicV2
{
    public class PlayerController : MonoBehaviour
    {
        [System.Serializable]
        public class InputButtons
        {
            public string attack = "";
            public string charge = "";
            public string defense = "";
            public string evade = "";
        }

        public InputButtons button;

        public enum PlayerAction
        {
            Nothing,
            Charge,
            Defense,
            Attack,
            Evade
        }

        [SerializeField] PlayerAction action;
        bool alreadyActed;

        bool actionAnimationEnded;

        public void ManageInput()
        {
            
                if (Input.GetButtonDown(button.attack))
                {
                    action = PlayerAction.Attack;
                }
                if (Input.GetButtonDown(button.charge))
                {
                    action = PlayerAction.Charge;
                }
                if (Input.GetButtonDown(button.defense))
                {
                    action = PlayerAction.Defense;
                }
                if (Input.GetButtonDown(button.evade))
                {
                    action = PlayerAction.Evade;
                }
        }

        public void DoAction()
        {
            if (!alreadyActed)
            {
                actionAnimationEnded = false;
                alreadyActed = true;
                //animator
            }
        }

        private void ResetAction()
        {
            action = PlayerAction.Nothing;
            alreadyActed = false;
        }

        public bool ActionAnimationEnded(){
            return actionAnimationEnded;
        }

    }
}