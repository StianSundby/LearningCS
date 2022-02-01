using System;

namespace LearningCS.Resources.TaskClasses.Standalone_classes
{
    public class Water
    {
        private const double CaloriesToMeltIce = 80;
        private const double CaloriesToEvaporateWater = 600;

        public Water(double amount, double temperature, double? proportion = null)
        {
            Amount = amount;
            Temperature = temperature;
            State = temperature <= 0 ? WaterState.Ice
                : temperature > 100 ? WaterState.Gas
                : WaterState.Fluid;

            if (Temperature != 100 && Temperature != 0) return;
            if (proportion == null) throw new ArgumentException("When temperature is 0 or 100, you must provide a value for proportion");

            ProportionFirstState = proportion.Value;
            switch (ProportionFirstState)
            {
                case 1:
                    return;
                case 0:
                    State = temperature == 0 ? WaterState.Fluid : WaterState.Gas;
                    break;
                default:
                    State = temperature == 0 ? WaterState.IceAndFluid : WaterState.FluidAndGas;
                    break;
            }
        }

        public WaterState State { get; private set; }
        public double Temperature { get; private set; }
        public double Amount { get; }
        public double ProportionFirstState { get; private set; }

        public void AddEnergy(double calories)
        {
            if (Temperature < 0) calories = HeatUp(calories, 0);
            if (Temperature == 0 && State != WaterState.Fluid) calories = ChangeState(calories);
            if (Temperature < 100) calories = HeatUp(calories, 100);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Temperature == 100 && State != WaterState.Gas) calories = ChangeState(calories);
            HeatUpMax(calories);
        }

        private double ChangeState(double calories)
        {
            if (calories <= 0) return 0;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Temperature != 0 && Temperature != 100) throw new ApplicationException("Cannot do state change when temperature is not 0 or 100.");

            var meltingIce = Temperature == 0;
            var energyNeeded = meltingIce ? CaloriesToMeltIce : CaloriesToEvaporateWater;
            var caloriesNeeded = energyNeeded * Amount;

            if (calories >= caloriesNeeded)
            {
                State = meltingIce ? WaterState.Fluid : WaterState.Gas;
                return calories - caloriesNeeded;
            }

            ProportionFirstState = 1 - calories / caloriesNeeded;
            State = meltingIce ? WaterState.IceAndFluid : WaterState.FluidAndGas;
            return 0;
        }

        private double HeatUp(double calories, int temperature)
        {
            if (calories <= 0) return 0;
            var caloriesForHeating = (temperature - Temperature) * Amount;
            if (!(calories >= caloriesForHeating)) return HeatUpMax(calories);
            Temperature = temperature;
            return calories - caloriesForHeating;
        }

        private double HeatUpMax(double calories)
        {
            if (calories <= 0) return 0;
            var temperatureChange = calories / Amount;
            Temperature += temperatureChange;
            return 0;
        }
    }

    public enum WaterState
    {
        Fluid, 
        Ice, 
        Gas, 
        FluidAndGas, 
        IceAndFluid
    }
}
