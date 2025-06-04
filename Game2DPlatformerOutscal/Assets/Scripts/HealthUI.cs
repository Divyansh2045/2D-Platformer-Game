using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public Transform heartsContainer; // Assign this in the inspector — the parent object of all hearts (e.g., HeartsPanel)

    public void UpdateHearts(int currentHealth)
    {
        // Defensive check
        if (currentHealth >= 0 && currentHealth < heartsContainer.childCount)
        {
            Transform heart = heartsContainer.GetChild(currentHealth);
            Animator heartAnim = heart.GetComponent<Animator>();

            if (heartAnim != null)
            {
                heartAnim.SetTrigger("Lose"); // Trigger the 'Lose' animation
            }
            else
            {
                Debug.LogWarning("No Animator found on heart {currentHealth}");
            }
        }
        else
        {
            Debug.LogWarning("Tried to update health UI with invalid index: " + currentHealth);
        }
    }
}
