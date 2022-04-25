using Core; 
using UI;
using ScriptabelObjects.Scripts;
using UnityEngine;

namespace Stats
{
    public class LoadSelectedPlayerInfo: MonoBehaviour
    {
        public GameData GameData;
        private SpawnFighters spawnFighters;
        private HealthUIFighter healthUIFighter1;
        private HealthUIFighter healthUIFighter2;
        private HealthUIFighter[] attackPoints;
        private void Awake()
        {
            spawnFighters = GetComponent<SpawnFighters>();
            healthUIFighter1 = GameObject.FindGameObjectWithTag(Tags.FIGHTER1UI_TAG).GetComponent<HealthUIFighter>();
            healthUIFighter2 = GameObject.FindGameObjectWithTag(Tags.FIGHTER2UI_TAG).GetComponent<HealthUIFighter>();
        }
        public void LoadSelectedPlayersInfo()
        {  
            var fighter1Data = new FighterData(GameData,GameData.SelectedFighter1);
            var fighter2Data = new FighterData(GameData,GameData.SelectedFighter2);
            spawnFighters.SetFightersInfo(fighter1Data,fighter2Data,healthUIFighter1,healthUIFighter2);
            SetHealthUI(fighter1Data,fighter2Data);


        }

        private void SetHealthUI(FighterData fighter1Data,FighterData fighter2Data)
        {
            healthUIFighter1.SetInitialHealthUI(fighter1Data);
            healthUIFighter2.SetInitialHealthUI(fighter2Data);
        }
        
    }
}