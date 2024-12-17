using UnityEngine;
using DG.Tweening;
using System;

class BounceElement : DotweenUIEffect
{
    private Transform _elementTransform;

    public BounceElement(float bounceDuration, float bounceIntensive, Transform elementTransform):base(bounceDuration, bounceIntensive)
    {
        _effectDuration = bounceDuration;
        _effectIntensive = bounceIntensive;
        _elementTransform = elementTransform;
    }

    public override void DoEffect()
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(_elementTransform.DOScale(_effectIntensive, _effectDuration/2).SetEase(Ease.InBounce));
        _sequence.Append(_elementTransform.DOScale(1f, _effectDuration/2).SetEase(Ease.Linear));
        _sequence.Play();
    }
    public void DoEffectAction(Action onCompleteAction)
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(_elementTransform.DOScale(_effectIntensive, _effectDuration / 2).SetEase(Ease.InBounce));
        _sequence.Append(_elementTransform.DOScale(1f, _effectDuration / 2).SetEase(Ease.Linear));
        _sequence.OnComplete(() => onCompleteAction());
    }
}
