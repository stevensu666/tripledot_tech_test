using UnityEngine;

public class PlayParticleOnce : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleEffect;

    public void PlayEffect()
    {
        if (particleEffect != null)
        {
            particleEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear); 
            particleEffect.Play();
        }
    }
}