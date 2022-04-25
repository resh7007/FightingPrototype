using Enemy;
using Stats;
using UI;
using UnityEngine;

namespace Core
{
    public class SpawnFighters: MonoBehaviour
    {
        public Transform[] SpawnPos;
        public GameObject FighterPrefab;
        private GameObject Fighter1;
        private GameObject Fighter2;
        private FighterType fighter1Type;
        private FighterType fighter2Type;
        private HealthUIFighter healthUIFighter1;
        private HealthUIFighter healthUIFighter2;
        private FighterData fighter1Data;
        private FighterData fighter2Data;
        public void SetFightersInfo(FighterData _fighter1Data, FighterData _fighter2Data, HealthUIFighter _healthUIFighter1,HealthUIFighter _healthUIFighter2)
        {
            fighter1Data = _fighter1Data;
            fighter2Data = _fighter2Data;
            fighter1Type = _fighter1Data.MyType;
            fighter2Type = _fighter2Data.MyType;
            healthUIFighter1 = _healthUIFighter1;
            healthUIFighter2 = _healthUIFighter2;
        }

        public void SpawnFightersForCombat()
        {
            Fighter1 = SpawnFighter(SpawnPos[0].position, new Vector3(0, 90, 0),fighter1Type);
            Fighter2 = SpawnFighter(SpawnPos[1].position, new Vector3(0, 270, 0),fighter2Type);
            
            SetUpFightersAppearance(fighter1Type,Fighter1.transform);
            SetUpFightersAppearance(fighter2Type,Fighter2.transform);
            
            SetUpFightersMovement();
            SetUpFightersAttributes(Fighter1,6,7,true,"Enemy");
            SetUpFightersAttributes(Fighter2,7,6,false, "Player");
            
            SetFighterHealth(Fighter1,Fighter2);
    
        }

        private GameObject SpawnFighter(Vector3 spawnPos, Vector3 rot, FighterType fighterType)
        {
            GameObject fighter = Instantiate(FighterPrefab, spawnPos, Quaternion.identity);
            fighter.transform.rotation *= Quaternion.Euler(rot);
            fighter.name = fighterType.ToString();
            return fighter;
        }
        private void SetUpFightersAppearance(FighterType type, Transform parent)
        {
            GameObject instance = Instantiate(Resources.Load(type.ToString(), typeof(GameObject)), parent, true) as GameObject;
            if(instance==null)
                return;
            instance.transform.localPosition = Vector3.zero;
            instance.transform.localScale = Vector3.one;
            instance.transform.localRotation = Quaternion.identity;
        }
        private void SetUpFightersMovement()
        {
            var move = Fighter1.AddComponent<Move>();
            var animator = Fighter1.GetComponentInChildren(typeof(Animator)) as Animator;
            move.animator = animator;
            if (animator != null) 
                animator.gameObject.AddComponent<FighterAnimationDelegate>();
            Fighter1.GetComponent<Health>().SetMove(move);

            
            var moveAI = Fighter2.AddComponent<MoveAI>();
            var animatorAI = Fighter2.GetComponentInChildren(typeof(Animator)) as Animator;
            moveAI.animator = animatorAI;
            if (animatorAI != null) 
                animatorAI.gameObject.AddComponent<FighterAnimationDelegate>();
            Fighter2.GetComponent<Health>().SetMove(moveAI);

        }
        
        private void SetUpFightersAttributes(GameObject fighter, int myLayer, int enemyLayer,bool isPlayer,string maskName)
        {
            fighter.layer = myLayer;
            var attackPoint = fighter.GetComponentInChildren(typeof(AttackPoints)) as AttackPoints;
            if(attackPoint==null)
                return;
            attackPoint.isPlayer = isPlayer;
            attackPoint.isEnemy = !isPlayer;
            attackPoint.SetDamage(fighter1Data,fighter2Data);
            attackPoint.CollisionLayer = LayerMask.GetMask(maskName); 
            attackPoint.gameObject.SetActive(false);
            var fighterDelegate = fighter.GetComponentInChildren(typeof(FighterAnimationDelegate)) as FighterAnimationDelegate;
            if(fighterDelegate!=null)
                fighterDelegate.rightArmAttackPoint = attackPoint.gameObject;
        }

        private void SetFighterHealth(GameObject fighter1, GameObject fighter2)
        {
            fighter1.GetComponent<Health>().healthUIFighter = healthUIFighter1;
            fighter2.GetComponent<Health>().healthUIFighter = healthUIFighter2;
        }
      
    }
}