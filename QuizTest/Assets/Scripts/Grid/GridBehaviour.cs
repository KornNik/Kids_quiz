using UnityEngine;
using Data;
using Helpers;
using UnityEngine.UI;

namespace Behaviours
{
    class GridBehaviour : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _gridLayout;

        private Grid _grid;
        private CellBundleData _cellBundle;
        private AnswerChecker _answerChecker;
        private RandomAnswerGenerator _answerGenerator;

        public AnswerChecker AnswerChecker => _answerChecker;
        public RandomAnswerGenerator AnswerGenerator => _answerGenerator;


        private void Awake()
        {
            Services.Instance.GridBehaviour.SetObject(this);
            _cellBundle = Services.Instance.DatasBundle.ServicesObject.GetData<CellBundleData>();
            _grid = new Grid(_gridLayout.transform);
            _answerChecker = new AnswerChecker();
            _answerGenerator = new RandomAnswerGenerator();
            _grid.CreateCells();
        }
        private void OnEnable()
        {
            _answerChecker.Subscribe();
            _answerGenerator.Subscribe();
        }
        private void OnDisable()
        {
            _answerChecker.Unsubscribe();
            _answerGenerator.Unsubscribe();
        }

        public void CreateGrid()
        {
            var size = Services.Instance.Level.ServicesObject.LevelDifficulty.GetLevelFieldsSize();
            _grid.FillCells(size);
            _answerGenerator.SelectAnswer(_grid.Cells);
            _answerChecker.SetRightAnswer(_answerGenerator.CurrentAnswer);
        }
    }
}