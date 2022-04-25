using Core;
using UnityEngine;

namespace Enemy
{
    public class MoveAI: MonoBehaviour, IMove
    
    {
        public Animator animator;
        private float speed = 5f;
        //will be ai logic in the future
        //for now leave it as second player
        private void Update()
        {
             
            if (Input.GetKey(KeyCode.LeftArrow))
                MoveForward();
            if(Input.GetKeyUp(KeyCode.LeftArrow))
                animator.SetBool("Walk Forward", false);

            if (Input.GetKey(KeyCode.RightArrow))
                MoveBackward();
            if(Input.GetKeyUp(KeyCode.RightArrow))
                animator.SetBool("Walk Backward", false);
            
            if(Input.GetKeyUp(KeyCode.RightShift))
                animator.SetTrigger("PunchTrigger");
        }
        
        public void MoveForward()
        { 
            animator.SetBool("Walk Forward", true);  
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        public void MoveBackward()
        { 
            animator.SetBool("Walk Backward", true);  
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }

        public void Die()
        {
            animator.SetTrigger("DieTrigger");
            
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = false;
            Destroy(this);

        }
    }
}