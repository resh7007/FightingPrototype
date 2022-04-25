using Core; 
using ScriptabelObjects.Scripts;

namespace Stats
{
    public class FighterData
    {
        private FighterType myType;
        private float maxHealth;
        private float damageAmount; 
        public float MaxHealth => maxHealth;
        public float DamageAmount => damageAmount;
        public float CurrentHealth { get; set; }
    
        public FighterType MyType => myType;

        public FighterData(GameData _gameData, FighterType _myType)
        {
            myType = _myType;
            maxHealth = _gameData.GetFighterMaxHealth(_myType);
            CurrentHealth = maxHealth;
            damageAmount = _gameData.GetFighterDamageAmount(_myType);
        }

         
    }
}