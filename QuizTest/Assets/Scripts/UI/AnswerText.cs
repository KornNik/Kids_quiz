using Behaviours;
using Helpers;
using TMPro;
using UnityEngine;

namespace UI
{
    sealed class AnswerText : MonoBehaviour, IEventListener<RandomAnswerEvent>
    {
        private const string FIND_STRING = "Find";

        [SerializeField] private TMP_Text _textMeshPro;
        [SerializeField] private float _fadeDuration;

        private DotweenUIEffect _dotweenEffect;

        private void Awake()
        {
            _dotweenEffect = new FadeText(_fadeDuration, 1, _textMeshPro);
            _dotweenEffect.DoEffect();
        }

        private void OnEnable()
        {
            this.EventStartListening();
        }
        private void OnDisable()
        {
            this.EventStopListening();
        }
        private void ChangeText(string answer)
        {
            var finalText = Helpers.Extensions.StringBuilderExtender.
                CreateString(FIND_STRING, " ", answer);
            _textMeshPro.text = finalText;
        }

        public void OnEventTrigger(RandomAnswerEvent eventType)
        {
            ChangeText(eventType.Answer);
        }
    }
}
