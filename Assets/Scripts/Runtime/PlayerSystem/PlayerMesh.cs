using UnityEngine;

namespace Runtime.PlayerSystem
{
    public class PlayerMesh : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particleEffect;

        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            LevelSignals.Instance.onStageSuccess += PlayParticle;
        }
        
        private void UnsubscribeEvents()
        {
            LevelSignals.Instance.onStageSuccess -= PlayParticle;
        }
        
        private void PlayParticle()
        {
            particleEffect.Play();
        }
    }
}