using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] private Image healthBarFillImage;

     private HealthSystem healthSystem;

     private void Awake() {
        healthSystem = GetComponentInParent<HealthSystem>();
     }

     private void Update() {
        if(healthSystem && healthBarFillImage)
        {
           healthBarFillImage.fillAmount = healthSystem.GetCurrentHealth() / healthSystem.GetHealthMax();
           healthBarFillImage.color = Color.Lerp(Color.red,Color.green,healthBarFillImage.fillAmount);
        }
        else{
            Debug.LogError("No Reference Found Bar And Health system");
        }
     }

}
