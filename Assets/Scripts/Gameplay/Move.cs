using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Gameplay
{
    public class Move : MonoBehaviour
    {
        private Type _choice;
        private Image _icon;
        TextMeshProUGUI _text;
        private Coordinator _coordinator;

        public void setDetails(Type choice, Sprite sprite)
        {
            _choice = choice;

            _icon = GetComponent<Image>();
            _icon.sprite = sprite;
            
            _text = GetComponentInChildren<TextMeshProUGUI>();
            _text.text = _choice.Name;
        }

        public void SetDecisionMaker(Coordinator Game) 
        {
            _coordinator = Game; 
        }

        public void MoveSelected()
        {
            _coordinator.TakeUserMove(_choice);
        }
    }
}