
using UnityEngine;
public class EnemyFlameVFX : MonoBehaviour
{
    [SerializeField] ParticleSystem _flame;
    
    void SummonFlame()
    {
        _flame.gameObject.SetActive(true);
        _flame.Play();
    }

    void StopFlame()
    {
        _flame.gameObject.SetActive(false);
        _flame.Stop();
    }
        
}
