using Behaviours;
using Helpers;
using System.Collections.Generic;
using UnityEngine;
using UI;

class RandomAnswerGenerator : IEventSubscription, IEventListener<AnswerSelectedEvent>
{
    private string _previousAnswer;
    private string _rightAnswer;

    public string CurrentAnswer => _rightAnswer;

    public void SelectAnswer(List<CellBehaviour> cells)
    {
        _rightAnswer = SelectRandomAnswer(cells);
        if (_previousAnswer == _rightAnswer)
        {
            _rightAnswer = SelectRandomAnswer(cells);
        }
        RandomAnswerEvent.Trigger(_rightAnswer);
    }

    private string SelectRandomAnswer(List<CellBehaviour> cells)
    {
        var answer = cells[Random.Range(0, cells.Count)].CellData.Name;
        return answer;
    }

    public void OnEventTrigger(AnswerSelectedEvent eventType)
    {
        if(eventType.Type== AnswerType.Correct)
        {
            _previousAnswer = _rightAnswer;
        }
    }
    public void Subscribe()
    {
        this.EventStartListening();
    }
    public void Unsubscribe()
    {
        this.EventStopListening();
    }
}

