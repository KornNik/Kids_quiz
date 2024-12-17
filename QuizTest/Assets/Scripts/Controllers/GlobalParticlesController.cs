using Behaviours;
using Data;
using Helpers;
using UnityEngine;

namespace Controllers
{
    sealed class GlobalParticlesController : MonoBehaviour, IEventListener<AnswerSelectedEvent>
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

        public void OnEventTrigger(AnswerSelectedEvent eventType)
        {
            if (eventType.Type == AnswerType.Correct)
            {
                _starsPool.StartAt(eventType.CellPosition, Quaternion.identity);
            }
        }
    }
}
