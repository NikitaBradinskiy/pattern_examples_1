using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTime3
{
    //Water => Gas = > Liquid => Ice
    public abstract class WaterState
    {
        public abstract void Next(Water _water);
        public abstract void Previous(Water _water);
    }
    public sealed class GasState : WaterState
    {
        public override void Next(Water _water) { }

        public override void Previous(Water _water)
        {
            _water.State = WaterStateCreator.CreateState<LiquidState>();
        }
    }
    public sealed class LiquidState : WaterState
    {
        public override void Next(Water _water)
        {
            _water.State = WaterStateCreator.CreateState<GasState>();
        }

        public override void Previous(Water _water)
        {
            _water.State = WaterStateCreator.CreateState<SolidState>();
        }
    }
    public sealed class SolidState : WaterState
    {
        public override void Next(Water _water)
        {
            _water.State = WaterStateCreator.CreateState<LiquidState>();
        }

        public override void Previous(Water _water) { }
    }

    public class Water
    {
        private WaterState _state;
        public WaterState State { get => _state; set => _state = value; }
        public Water(WaterState state)
        {
            _state = state;
        }
        public void Heat() => _state.Next(this);
        public void Freeze() => _state.Previous(this);
    }
    static class WaterStateCreator
    {
        public static T CreateState<T>() where T : WaterState, new() => new T();
    }
}

