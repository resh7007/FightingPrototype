
using Core;
using UnityEngine;

namespace SelectScreen
{
    public class FighterSelectButton : MonoBehaviour
    {
        public FighterType type;
        private SelectScreenController controller;
        private void Start()
        {
            controller = FindObjectOfType<SelectScreenController>();
        }

        public void PlayerSelected()=> controller.PlayerSelected(type);
        
        
    }
}