using Helpers;
using UnityEngine;

namespace Behaviours
{
    enum ParticleType
    {
        None = 0,
        Stars
    }
    struct CreateParticleEvent
    {
        private ParticleType _type;
        private Transform _particlePosition;
        private static CreateParticleEvent _createParticleEvent;

        public ParticleType Type => _type;
        public Transform ParticlePosition => _particlePosition;

        public static void Trigger(ParticleType particleType, Transform particlePosition)
        {
            _createParticleEvent._type = particleType;
            _createParticleEvent._particlePosition = particlePosition;
            EventManager.TriggerEvent(_createParticleEvent);
        }
    }
}
