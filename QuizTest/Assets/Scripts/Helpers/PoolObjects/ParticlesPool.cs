using UnityEngine;

namespace Helpers
{
    class ParticlesPool : PollingPool<ParticleSystem>
    {
        public ParticlesPool(ParticleSystem prefab) : base(prefab)
        {
        }

        protected override bool IsActive(ParticleSystem component)
        {
            return component.isEmitting;
        }

        public void StartAt(Vector3 point, Quaternion rotation)
        {
            var system = Get();
            system.transform.position = point;
            system.transform.rotation = rotation;
            system.Play();
        }
    }
}
