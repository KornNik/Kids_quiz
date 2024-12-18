using UnityEngine;
using DG.Tweening;
using System;

namespace UI
{
    sealed class BounceElement : DotweenUIEffect
    {
        private Transform _elementTransform;
        private float _effectIntensive;

        public BounceElement(float bounceDuration, float bounceIntensive, Transform elementTransform) : base(bounceDuration)
        {
            _effectDuration = bounceDuration;
            _effectIntensive = bounceIntensive;
            _elementTransform = elementTransform;
        }

        public override void DoEffect()
        {
            base.DoEffect();
            _sequence.Append(_elementTransform.DOScale(_effectIntensive, _effectDuration / 2).SetEase(Ease.InBounce));
            _sequence.Append(_elementTransform.DOScale(1f, _effectDuration / 2).SetEase(Ease.Linear));
        }
        public override void DoEffect(Action onCompleteAction)
        {
            base.DoEffect(onCompleteAction);
            _sequence.Append(_elementTransform.DOScale(_effectIntensive, _effectDuration / 2).SetEase(Ease.InBounce));
            _sequence.Append(_elementTransform.DOScale(1f, _effectDuration / 2).SetEase(Ease.Linear));
            _sequence.OnComplete(() => onCompleteAction());
        }
    }
}
