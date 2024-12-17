using UnityEngine;
using UnityEngine.UI;
using Data;
using Behaviours;

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

    private void OnClick()
    {
        var effect = _dotweenEffect as BounceElement;
        effect.DoEffectAction(CallEvent);
    }
    private void CallEvent()
    {
        CellSelectedEvent.Trigger(CellData.Name, this.transform.position);
    }
}
