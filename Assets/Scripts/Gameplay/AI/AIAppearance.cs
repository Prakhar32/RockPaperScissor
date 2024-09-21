using Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Gameplay.AI {
    public class AIAppearance : MonoBehaviour
    {
        [SerializeField]
        private Move _move;

        [SerializeField]
        private SpriteAtlas _optionsSpriteAtlus;

        public void ChangeAppearance(Choice choice, Coordinator coordinator)
        {
            _move.setDetails(choice, _optionsSpriteAtlus.GetSprite(Constants.spriteAtlusBaseName + "_" + CommonStructures.SpriteAtlusIndexMapper[choice.GetType()]));
            _move.SetDecisionMaker(coordinator);
            ChangeState(true);
        }

        public void ChangeState(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}