using UnityEngine;
using Data;
using Helpers;
using UnityEngine.UI;

namespace Behaviours
{
    interface IGrid
    {
        void CreateGrid();
    }
    class GridBehaviour : MonoBehaviour, IGrid
    {
        [SerializeField] private GridLayoutGroup _gridLayout;

        private Grid _grid;
        private CellBundleData _cellBundle;
        private AnswerChecker _answerChecker;
        private RandomAnswerGenerator _answerGenerator;
        private EventSubscriptionWraper _eventSubscriptionWraper;

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

            _eventSubscriptionWraper = new EventSubscriptionWraper(3);
            FillSubscriptions();
        }
        private void OnEnable()
        {
            _eventSubscriptionWraper.Subscribe();
        }
        private void OnDisable()
        {
            _eventSubscriptionWraper.Unsubscribe();
        }

        public void CreateGrid()
        {
            var size = Services.Instance.Level.ServicesObject.LevelDifficulty.GetLevelFieldsSize();
            _grid.FillCells(size);
            _answerGenerator.SelectAnswer(_grid.Cells);
            _answerChecker.SetRightAnswer(_answerGenerator.CurrentAnswer);
        }

        private void FillSubscriptions()
        {
            _eventSubscriptionWraper.AddEvent(_answerChecker).
                AddEvent(_answerGenerator).AddEvent(_grid);
        }
    }
}