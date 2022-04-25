using System;
using ScriptabelObjects.Scripts;
using Stats;
using UnityEngine;

namespace Core
{
    public class AttackPoints : MonoBehaviour
    {
        public LayerMask CollisionLayer;
        public float Radius = .4f; 

        public bool isPlayer, isEnemy;
        public GameObject hit_FX;
        private float damage;
        private FighterData myEnemy; 
        void Update()
        {
            DetectCollision();
        }
 

        public void SetDamage(FighterData fighter1Data, FighterData fighter2Data )
        {
            if (!isPlayer)
            {
                myEnemy = fighter1Data; 
                damage = fighter2Data.DamageAmount;
            }
            else if(isPlayer)
            {
                myEnemy = fighter2Data; 
                damage = fighter1Data.DamageAmount; 
            } 
        }
        

        private void DetectCollision()
        {
            Collider[] hit = Physics.OverlapSphere(transform.position, Radius, CollisionLayer);
            if (hit.Length > 0)
            {
              //print("We hit the "+ hit[0].gameObject.name); 
              hit[0].GetComponent<Health>().TakeDamage(myEnemy, damage);
              gameObject.SetActive(false);
              CreateHitFX();
            }
        }

        private void CreateHitFX()
        {
            Instantiate(hit_FX,transform.position,Quaternion.identity);
        }
    }
}