using System;
using Core;
using UnityEngine;

namespace ScriptabelObjects.Scripts
{
    [CreateAssetMenu]
     public class GameData : ScriptableObject
     {
         [SerializeField] private FighterClass[] FighterClasses = null;

         public FighterType SelectedFighter1 { get; set; }
         public FighterType SelectedFighter2 { get; set; }

         [Serializable]
         public class FighterClass
         {
                [SerializeField] 
                [Range(100,1000)]float playerMaxHealth;
                [SerializeField] FighterType fighterType;
              
                [SerializeField]
                [Range(10,600)] float damageAmount;

                private float playerHealth;
                public float PlayerMaxHealth => playerMaxHealth;
                public FighterType FighterType => fighterType;
                public float DamageAmount => damageAmount;
                public float PlayerHealth
                {
                get => playerHealth;
                set => playerHealth = value;
                }
              
         }
 
         public float GetFighterMaxHealth(FighterType type)
         {
             foreach (var fighter in FighterClasses)
             {
                 if (fighter.FighterType == type)
                 {
                     return fighter.PlayerMaxHealth;
                 }
             }

             return 0;
         }
         
         public float GetFighterDamageAmount(FighterType type)
         {
             foreach (var fighter in FighterClasses)
             {
                 if (fighter.FighterType == type)
                 {
                     return fighter.DamageAmount;
                 }
             }

             return 0;
         }
         
       

        
     }
  
}