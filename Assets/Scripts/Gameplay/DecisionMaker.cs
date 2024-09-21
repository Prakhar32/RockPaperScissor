using Gameplay.AI;
using Gameplay.RulesComposition;
using System;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class DecisionMaker : MonoBehaviour
    {
        private Rule rulebook;
        private AIOpponent opponent;

        [SerializeField]
        private AIAppearance appearance;

        [SerializeField]
        TextMeshProUGUI _flavourText;

        [SerializeField]
        private Coordinator _coordinator;

        void Awake()
        {
            RulebookFactory rulebookFactory = new RulebookFactory();
            rulebook = rulebookFactory.CreateRulebook();
            opponent = new AIOpponent();
        }

        public void MakeDecision(Choice userChoice)
        {
            Choice aiChoice = opponent.computeMove();
            appearance.ChangeAppearance(aiChoice, _coordinator);

            ResultContainer resultContainer = rulebook.CheckResult(userChoice, aiChoice);
            changeFlavourText(resultContainer.Message);
            evaluateResult(resultContainer.Result);
        }

        private void changeFlavourText(string message)
        {
            _flavourText.gameObject.SetActive(true);
            _flavourText.text = message;
        }

        private void evaluateResult(Result result) 
        {
            if (result == Result.LOSE)
                _coordinator.GameOver();

            if (result == Result.WIN)
                _coordinator.WonRound();

            if (result == Result.DRAW)
                _coordinator.DrewRound();
        }

        public void ResetState()
        {
            _flavourText.text = "";
            appearance.ChangeState(false);
        }
    }
}