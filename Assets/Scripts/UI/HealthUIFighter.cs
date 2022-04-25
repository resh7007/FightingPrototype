using Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthUIFighter : MonoBehaviour
    {
        public Text playerName;
        public Image healthUI;
        public Image icon;
        public void SetInitialHealthUI(FighterData fighterData)
        {
            UpdateHealthUIValue(fighterData.MaxHealth);
            SetIcon(fighterData.MyType.ToString());
            SetNameUI(fighterData.MyType.ToString());
        }

        private void SetNameUI(string fighterName)=> playerName.text = fighterName;
        

        private void SetIcon(string iconName)
        { 
            var sprite = Resources.Load<Sprite>("Icons/"+iconName);
            icon.sprite = sprite;
        } 

        public void UpdateHealthUI(float currentHp)=>  UpdateHealthUIValue(currentHp);
        
 
        private void UpdateHealthUIValue(float hp)
        {
            healthUI.fillAmount = hp/1000f;
        }
    }
}