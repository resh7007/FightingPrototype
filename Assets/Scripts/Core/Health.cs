 
using System.Collections;
using ScriptableObjects;
using Stats;
using UI; 
using UnityEngine;
using UnityEngine.UIElements;

namespace Core
{
    public class Health : MonoBehaviour
    {
        public HealthUIFighter healthUIFighter;
        private IMove move;
        public GameEvent dieEvent;

        public void SetMove(IMove _move)
        {
            move = _move;
        }

        public void TakeDamage(FighterData fighter, float damageAmount)
        {
          
            float playerHealth = fighter.CurrentHealth;
            if (damageAmount > playerHealth)
            {
                playerHealth = 0;
                StartCoroutine(Die());
                
            }
            else
                playerHealth -= damageAmount; 
            fighter.CurrentHealth = playerHealth;
            healthUIFighter.UpdateHealthUI(playerHealth);
        }

        IEnumerator Die()
        {
            move.Die();
            yield return new WaitForSeconds(1.5f);
            dieEvent.Raise();
        }
    }
}