﻿using BallSimulator.Logic;
using System.Collections.Generic;

namespace BallSimulator.Presentation.Model
{
    internal class Model : ModelApi
    {
        private readonly LogicAbstractApi _logic;
        public IEnumerable<BallModel> _ballModels => MapBallToBallModel();

        public Model(LogicAbstractApi logic = default)
        {
            _logic = logic ?? LogicAbstractApi.CreateLogicApi();
            _logic.SetObserver(NotifyUpdate);
        }

        public override void SpawnBalls(int count)
        {
            _logic.CreateBalls(count);
        }

        public override void Start()
        {
            _logic.StartSimulation();
        }

        public override void Stop()
        {
            _logic.StopSimulation();
        }

        public override void NotifyUpdate()
        {
            _observer.Invoke(_ballModels);
        }

        public override IEnumerable<BallModel> MapBallToBallModel()
        {
            List<BallModel> result = new List<BallModel>();
            foreach (Ball ball in _logic.Balls)
            {
                result.Add(new BallModel(ball));
            }
            return result;
        }

        public override void SetObserver(Observer observer)
        {
            _observer = observer;
        }
    }
}