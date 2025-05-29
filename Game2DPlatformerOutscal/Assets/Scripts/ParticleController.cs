using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;
  public void PlayEffect()
    {
       
        particleSystem.Play();
        gameObject.SetActive(true);
    }

}
