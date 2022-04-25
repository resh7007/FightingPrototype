
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace ScriptableObjects
{
      [CreateAssetMenu]
      public class GameEvent : ScriptableObject
      {
           private List<GameEventLinstener> listeners = new List<GameEventLinstener>();

           public void RegisterListener(GameEventLinstener listener)=> listeners.Add(listener);
           
           public void UnregisterListener(GameEventLinstener listener)=>  listeners.Remove(listener);

           public void Raise()
           {
               foreach (var listener in listeners)
               {
                   listener.OnEventRaised();
               }
           
           }

           public int GetCount()
           {
                return listeners.Count;
           }
      }
}