using UnityEngine;
using Behaviours;
using Helpers;

namespace UI
{
    class GameMenu : BaseUI, IEventListener<EndPanelEvent>
    {
        [SerializeField] private Transform _cellsTransform;
        [SerializeField] private GridBehaviour _gridBehaviour;
        [SerializeField] private AnswerText _answerText;
        [SerializeField] private EndGamePanel _endGamePanel;

        private void OnEnable()
        {
            this.EventStartListening();
        }
        private void OnDisable()
        {
            this.EventStopListening();
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            _endGamePanel.gameObject.SetActive(false);
            ShowUI.Invoke();
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }

        public void OnEventTrigger(EndPanelEvent eventType)
        {
            _endGamePanel.gameObject.SetActive(true);
        }
    }
}