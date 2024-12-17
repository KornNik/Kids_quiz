using DG.Tweening;
using TMPro;

namespace UI
{
    sealed class FadeText : DotweenUIEffect
    {
        TMP_Text _text;
        public FadeText(float fadeDuration, float fadeIntensive, TMP_Text text) : base(fadeDuration, fadeIntensive)
        {
            _effectDuration = fadeDuration;
            _effectIntensive = fadeIntensive;
            _text = text;
        }
        public override void DoEffect()
        {
            _sequence = DOTween.Sequence();
            _text.alpha = 0f;
            _sequence.Append(_text.DOFade(1.0f, _effectDuration));
        }
    }
}
