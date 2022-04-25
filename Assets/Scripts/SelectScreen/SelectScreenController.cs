 
using Core; 
using ScriptabelObjects.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectScreen
{
    public class SelectScreenController : MonoBehaviour
    {
        public GameData GameData;
        public void PlayerSelected(FighterType type)
        {
            GameData.SelectedFighter1 = type;
            SceneManager.LoadScene("CombatScene");
        }
    }
}