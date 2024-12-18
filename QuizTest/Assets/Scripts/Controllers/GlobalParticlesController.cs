using Behaviours;
using Data;
using Helpers;
using UnityEngine;

namespace Controllers
{
    sealed class GlobalParticlesController : MonoBehaviour, IEventListener<CreateParticleEvent>
    {
        private ParticlesPool _starsPool;

        private void Awake()
        {
            var starParticle = Services.Instance.DatasBundle.ServicesObject.GetData<ParticlesData>().StarsParticles;
            _starsPool = new ParticlesPool(starParticle);
        }
        private void OnEnable()
        {
            this.EventStartListening();
        }
        private void OnDisable()
        {
            this.EventStopListening();
        }

        public void OnEventTrigger(CreateParticleEvent eventType)
        {
            if (eventType.Type == ParticleType.Stars)
            {
                var finalPosition = new Vector3(eventType.ParticlePosition.position.x,
                    eventType.ParticlePosition.position.y, eventType.ParticlePosition.position.z - 5);
                _starsPool.StartAt(finalPosition, Quaternion.identity);
            }
        }
    }
}
