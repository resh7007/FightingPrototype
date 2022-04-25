using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class GameEventLinstener : MonoBehaviour
    {
        public GameEvent GameEvent;
        public UnityEvent Response;
        public void OnEventRaised()
        {
            Response.Invoke();
        }

        private void OnEnable()
        {
            GameEvent.RegisterListener(this);  
        }
        private void OnDisable()
        {
            GameEvent.UnregisterListener(this);
        }
    }
}