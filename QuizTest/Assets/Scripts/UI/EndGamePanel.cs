using Behaviours;
using DG.Tweening;
using Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    sealed class EndGamePanel : MonoBehaviour
    {
        [SerializeField] private Button _repeatButton;

        private RectTransform _rectTransform;
        private SettingsPanelTween _panelTween;
        private SequenceSettings _sequenceSettings;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _panelTween = new SettingsPanelTween(_rectTransform);
            _sequenceSettings = new SequenceSettings(_panelTween);
        }

        private void OnEnable()
        {
            _repeatButton.onClick.AddListener(OnRepeatButtonDown);
            Show();
        }

        private void OnDisable()
        {
            _repeatButton.onClick.RemoveListener(OnRepeatButtonDown);
        }
        private void Show()
        {
            _panelTween.GoToEnd(MoveMode.Hide);
            _sequenceSettings.Move(MoveMode.Show);
        }
        private void Hide()
        {
            _sequenceSettings.Move(MoveMode.Hide).AppendCallback(() => gameObject.SetActive(false));
        }


        private void OnRepeatButtonDown()
        {
            var levelLoader = Services.Instance.LevelLoader.ServicesObject;
            levelLoader.LoadLevelGame(0);
            Services.Instance.GridBehaviour.ServicesObject.CreateGrid();
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }
    }
}
