using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public Transform heartsContainer; // Assign this in the inspector 

    public void UpdateHearts(int currentHealth)
    {
        if (heartsContainer.childCount > 0)
            GameObject.Destroy(heartsContainer.transform.GetChild(0).gameObject);
    }
}
