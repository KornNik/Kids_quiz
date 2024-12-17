using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ParticlesData", menuName = "Data/Particles")]
    sealed class ParticlesData : ScriptableObject
    {
        [SerializeField] private ParticleSystem _starsParticles;

        public ParticleSystem StarsParticles => _starsParticles;
    }
}
