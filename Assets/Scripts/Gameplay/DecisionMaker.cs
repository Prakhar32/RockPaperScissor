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

        public void makeDecision(Type userSelectedMove)
        {
            Type aiMove = opponent.computeMove();
            appearance.ChangeAppearance(aiMove, _coordinator);

            ResultContainer resultContainer = rulebook.CheckResult(userSelectedMove, aiMove);
            _flavourText.gameObject.SetActive(true);
            _flavourText.text = resultContainer.Message;

            if (resultContainer.Result == Result.LOSE)
                _coordinator.GameOver();

            if(resultContainer.Result == Result.WIN)
                _coordinator.WonRound();

            if(resultContainer.Result == Result.DRAW)
                _coordinator.DrewRound();
        }

        public void ResetState()
        {
            _flavourText.text = "";
            appearance.ChangeState(false);
        }
    }
}