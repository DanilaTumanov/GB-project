using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GBproject.Controllers.AI
{

    /// <summary>
    /// Класс для создания простых конечных автоматов на корутинах
    /// </summary>
    public class AIStateMachine
    {

        private string _currentState;

        private Dictionary<string, AISMState> _states = new Dictionary<string, AISMState>();

        private MonoBehaviour _self;

        private Coroutine _mainCoroutine;

        private string _prevState;



        /// <summary>
        /// Возвращает предыдущее состояние конечного автомата
        /// </summary>
        public string PrevState
        {
            get
            {
                return _prevState;
            }
        }



        /// <summary>
        /// Делегат, описывающий состояние конечного автомата
        /// </summary>
        /// <returns>Возвращаемое значение должно реализовывать интерфейс IEnumerator</returns>
        public delegate IEnumerator AISMState();





        public AIStateMachine(MonoBehaviour self)
        {
            _self = self;
        }



        /// <summary>
        /// Добавляет состояние в конечный автомат
        /// </summary>
        /// <param name="name">Название-идентификатор состояния</param>
        /// <param name="state">Метод, описывающий логику состояния (к примеру корутина)</param>
        public void AddState(string name, AISMState state)
        {
            _states[name] = state;
        }


        /// <summary>
        /// Запустить конечный автомат
        /// </summary>
        /// <param name="stateName">Название-идентификатор начального состояния</param>
        public void Start(string stateName)
        {
            _currentState = stateName;
            _mainCoroutine = _self.StartCoroutine(StateController());
        }


        /// <summary>
        /// Остановить конечный автомат
        /// </summary>
        public void Stop()
        {
            _self.StopCoroutine(_mainCoroutine);
        }



        private IEnumerator StateController()
        {
            // Перед стартом ждем конца кадра, чтобы все компоненты на сцене инициализировались (отработал старт и т.д.)
            yield return new WaitForEndOfFrame();

            object stateRes = _currentState;

            while (true)
            {
                IEnumerator stateExecution = _states[_currentState]();

                while (stateExecution.MoveNext())
                {
                    stateRes = stateExecution.Current;
                    yield return stateRes;
                }

                _prevState = _currentState;
                _currentState = (stateRes as string);
            }
        }

    }

}