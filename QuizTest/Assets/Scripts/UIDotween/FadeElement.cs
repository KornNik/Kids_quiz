using UnityEngine;
using DG.Tweening;


class FadeElement : DotweenUIEffect
{
    private SpriteRenderer _elementSprite;

    public FadeElement(float fadeDuration, float fadeIntensive, SpriteRenderer elementSprite) : base(fadeDuration, fadeIntensive)
    {
        _effectDuration = fadeDuration;
        _effectIntensive = fadeIntensive;
        _elementSprite = elementSprite;
    }

    public override void DoEffect()
    {
        _sequence.Append(_elementSprite.DOFade(0.0f,_effectDuration));
        _sequence.Append(_elementSprite.DOFade(1.0f, _effectDuration));
    }

}