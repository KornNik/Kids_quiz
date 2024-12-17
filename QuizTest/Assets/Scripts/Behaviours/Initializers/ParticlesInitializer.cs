using Helpers;
using Controllers;
using UnityEngine;
using Data;

namespace Behaviours
{
    sealed class ParticlesInitializer : IInitialization
    {
        public void Initialization()
        {
            var particlesControllerPrefab = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetGlobalParticlesController();
            var particlesController = GameObject.Instantiate(particlesControllerPrefab).
                GetComponent<GlobalParticlesController>();

            Services.Instance.ParticlesController.SetObject(particlesController);
        }
    }
}
