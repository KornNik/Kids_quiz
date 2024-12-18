using UnityEngine;
using UnityEngine.UI;
using Data;
using Behaviours;
using System;

namespace UI
{
    class CellBehaviour : MonoBehaviour
    {
        [SerializeField] private float _effectTime;
        [SerializeField] private float _effectIntense;
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        private CellStruct _cellData;
        private DotweenUIEffect _dotweenEffect;

        public CellStruct CellData => _cellData;

        private void Awake()
        {
            _dotweenEffect = new BounceElement(_effectTime, _effectIntense, _image.transform);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void ActivateSlot()
        {
            gameObject.SetActive(true);
            SetInteractableStatus(true);

            _dotweenEffect.DoEffect();
        }
        public void DeactivateSlot()
        {
            gameObject.SetActive(false);
        }
        public void FillCell(CellStruct cellData)
        {
            _cellData = cellData;
            _image.sprite = _cellData.Image;
        }
        public void SetInteractableStatus(bool status)
        {
            _button.interactable = status;
        }
        public void EffectOnCorrectAnswer(Action actionAfterEffect)
        {
            _dotweenEffect.DoEffect(actionAfterEffect);
        }

        private void OnClick()
        {
            CallEvent();
        }
        private void CallEvent()
        {
            CellSelectedEvent.Trigger(CellData.Name, this);
        }
    }
}
