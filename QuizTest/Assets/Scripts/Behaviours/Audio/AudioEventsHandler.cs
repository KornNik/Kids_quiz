using Helpers;
using System;

namespace Behaviours
{
    class AudioEventsHandler : IEventListener<MakeSoundEvent>, IEventListener<MuteSoundEvent>, IEventSubscription, IDisposable
    {
        public AudioEventsHandler()
        {
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        public void OnEventTrigger(MakeSoundEvent eventType)
        {
            Services.Instance.AudioController.ServicesObject.PlaySound(eventType.SoundData);
        }

        public void OnEventTrigger(MuteSoundEvent eventType)
        {
            Services.Instance.AudioController.ServicesObject.SetSoundStatus(eventType.MutedInfo.IsMuted);
        }

        public void Subscribe()
        {
            this.EventStartListening<MakeSoundEvent>();
            this.EventStartListening<MuteSoundEvent>();
        }

        public void Unsubscribe()
        {
            this.EventStopListening<MakeSoundEvent>();
            this.EventStopListening<MuteSoundEvent>();
        }
    }
}