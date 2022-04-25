using UnityEngine;

namespace Core
{
    public class Move: MonoBehaviour,IMove
    {
        public Animator animator;
        private float speed = 5f;
        private void Update()
        {
         
            if (Input.GetKey(KeyCode.D))
                MoveForward();
            if(Input.GetKeyUp(KeyCode.D))
                animator.SetBool("Walk Forward", false);

            if (Input.GetKey(KeyCode.A))
                MoveBackward();
            if(Input.GetKeyUp(KeyCode.A))
                animator.SetBool("Walk Backward", false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("PunchTrigger", true); 

            }
 

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