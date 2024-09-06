using System;
using UnityEngine;
using UnityEngine.U2D;

namespace Gameplay
{
    public class GameplayInitializer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _optionPrefab;

        [SerializeField]
        private Transform _optionsParent;

        [SerializeField]
        private SpriteAtlas _optionsSpriteAtlus;

        private bool _isInitialised;

        [SerializeField]
        private Coordinator _coordinator;

        public void Initialise()
        {
            if (!_isInitialised) 
                initialiseGame();

            _coordinator.StartGame();
        }

        private void initialiseGame()
        {
            initialiseUserOptions();
            _isInitialised = true;
        }

        private void initialiseUserOptions()
        {
            Type[] choices = CommonStructures.Moves;

            for (int i = 0; i < Constants.numberOfOptions; i++)
            {
                GameObject g = Instantiate<GameObject>(_optionPrefab, _optionsParent);
                Move move = g.GetComponent<Move>();
                move.setDetails(choices[i], _optionsSpriteAtlus.GetSprite(Constants.spriteAtlusBaseName + "_" + CommonStructures.SpriteAtlusIndexMapper[choices[i]]));
                move.SetDecisionMaker(_coordinator);
            }
        }
    }
}