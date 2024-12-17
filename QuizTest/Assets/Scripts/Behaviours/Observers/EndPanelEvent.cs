using Helpers;
namespace Behaviours
{
    struct EndPanelEvent
    {
        private static EndPanelEvent _endPanelEvent;

        public static void Trigger()
        {
            EventManager.TriggerEvent(_endPanelEvent);
        }
    }
}
