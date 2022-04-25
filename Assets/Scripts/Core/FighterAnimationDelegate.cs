using UnityEngine;

namespace Core
{
    public class FighterAnimationDelegate: MonoBehaviour
    {
        public GameObject rightArmAttackPoint;

        void RightArmAttackPointOn()
        {
            rightArmAttackPoint.SetActive(true);
        }
        void RightArmAttackPointOff()
        {
            if(rightArmAttackPoint.activeInHierarchy)
                rightArmAttackPoint.SetActive(false);
        }
    }
}