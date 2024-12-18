using Helpers;

namespace Behaviours
{
    struct CellsStatusEvent
    {
        private static CellsStatusEvent _cellsStatusEvent;
        private bool _interactableStatus;

        public bool InteractableStatus => _interactableStatus;

        public static void Trigger(bool interactableStatus)
        {
            _cellsStatusEvent._interactableStatus = interactableStatus;
            EventManager.TriggerEvent(_cellsStatusEvent);
        }
    }
}
