using DG.Tweening;


abstract class DotweenUIEffect
{
    protected Sequence _sequence;
    protected float _effectDuration;
    protected float _effectIntensive;

    public DotweenUIEffect(float effectDuration, float effectIntensive)
    {
        _effectDuration = effectDuration;
        _effectIntensive = effectIntensive;
    }

    public abstract void DoEffect();
}

