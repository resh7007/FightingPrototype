using System;
using Stats;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager: MonoBehaviour
    {
        private LoadSelectedPlayerInfo playerInfo;
        private void Awake()
        {
            playerInfo = GetComponent<LoadSelectedPlayerInfo>();
        }

        private void Start()
        {
            LoadSelectedPlayersInfo();
            SpawnPlayers(); 
        }
        
        private void LoadSelectedPlayersInfo()
        {
            playerInfo.LoadSelectedPlayersInfo();
        }
        private void SpawnPlayers()
        {
            GetComponent<SpawnFighters>().SpawnFightersForCombat();
        }
        public void ReloadScene()
        { 
            print("reloading");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}