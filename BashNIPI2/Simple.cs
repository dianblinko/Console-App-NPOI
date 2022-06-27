using System;
using System.ComponentModel;
using System.Linq;

namespace BashNIPI2
{
    public class Simple
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Давление, \nатм.")]
        public double Pressure { get; set; }

        [DisplayName("Температура на глубине L, °С.")]
        public double TemperatureAtDepthL { get; set; }

        [DisplayName("Объемный фактор газа.")]
        public double VolumeFactorGas { get; set; }

        [DisplayName("Объемный фактор нефти.")]
        public double VolumeFactorOil { get; set; }

        [DisplayName("Объемный фактор воды.")]
        public double VolumeFactorWater { get; set; }

        [DisplayName("Теплопроводность газа.")]
        public double ThermalConductivityGas { get; set; }

        [DisplayName("Теплопроводность нефти.")]
        public double ThermalConductivityOil { get; set; }

        [DisplayName("Теплопроводность воды.")]
        public double ThermalConductivityWater { get; set; }

        [DisplayName("Теплопроводность смеси.")]
        public double ThermalConductivityMixture { get; set; }

        [DisplayName("Тип потока на глубине L.")]
        public double TypeFlowAtDepthL { get; set; }

        [DisplayName("Дебит смеси с водой.")]
        public double FlorRateMixtureWater { get; set; }

        [DisplayName("Дебит газа в условиях насоса.")]
        public double GasFlowRateUnderPumpConditions { get; set; }

        [DisplayName("Дебит нефти в условиях насоса.")]
        public double OilFlowRateUnderPumpConditions { get; set; }

        [DisplayName("Дебит воды в условиях насоса.")]
        public double WaterFlowRateUnderPumpConditions { get; set; }

        [DisplayName("Расход НГС (Объемный, Стд), м3/сутки.")]
        public double ConsumptionNgsStd { get; set; }

        [DisplayName("Расход НГС (Объемный, Действ), м3/сутки.")]
        public double ConsumptionNgsEffective { get; set; }

        [DisplayName("Массовый Расход воды.")]
        public double MassFlowRateWater { get; set; }

        [DisplayName("Расход НГС (Массовый), кг/с.")]
        public double ConsumptionNgsMassKg { get; set; }

        [DisplayName("Расход НГС (Массовый), Киломоль/сек.")]
        public double ConsumptionNgsMassKilomol { get; set; }

        [DisplayName("Обводненность в долях.")]
        public double WaterContentInFractions { get; set; }

        [DisplayName("Мольная доля газа (композиционный поток).")]
        public double MoleFractionOnGas { get; set; }

        [DisplayName("Объемная доля газа.")]
        public double VolumeFractionfGas { get; set; }

        [DisplayName("Вязкость газа.")]
        public double ViscosityOfGas { get; set; }

        [DisplayName("Вязкость жидкости.")]
        public double LiquidVicosity { get; set; }

        [DisplayName("Вязкость нефти.")]
        public double OilVicosity { get; set; }

        [DisplayName("Вязкость воды.")]
        public double WaterVicosity { get; set; }

        [DisplayName("Вязкость смеси.")]
        public double MixtureVicosity { get; set; }

        [DisplayName("Коэффициент теплообмена")]
        public double HeatTransferCoefficient { get; set; }
        public static double GenerateDoubleorNaN(Random rand)
        {
            return rand.Next() % 5 == 0 ? double.NaN : rand.NextDouble();
        }
        public Simple(int i, Random rand)
        {
            Name = "Simple " + i;
            Pressure = GenerateDoubleorNaN(rand);
            TemperatureAtDepthL = rand.NextDouble();
            VolumeFactorGas = rand.NextDouble();
            VolumeFactorOil = rand.NextDouble();
            VolumeFactorWater = rand.NextDouble();
            ThermalConductivityGas = rand.NextDouble();
            ThermalConductivityOil = rand.NextDouble();
            ThermalConductivityWater = rand.NextDouble();
            ThermalConductivityMixture = rand.NextDouble();
            TypeFlowAtDepthL = rand.NextDouble();
            FlorRateMixtureWater = rand.NextDouble();
            GasFlowRateUnderPumpConditions = rand.NextDouble();
            OilFlowRateUnderPumpConditions = rand.NextDouble();
            WaterFlowRateUnderPumpConditions = rand.NextDouble();
            ConsumptionNgsStd = rand.NextDouble();
            ConsumptionNgsEffective = rand.NextDouble();
            MassFlowRateWater = rand.NextDouble();
            ConsumptionNgsMassKg = rand.NextDouble();
            ConsumptionNgsMassKilomol = rand.NextDouble();
            WaterContentInFractions = rand.NextDouble();
            MoleFractionOnGas = rand.NextDouble();
            VolumeFractionfGas = rand.NextDouble();
            ViscosityOfGas = rand.NextDouble();
            LiquidVicosity = rand.NextDouble();
            OilVicosity = rand.NextDouble();
            WaterVicosity = rand.NextDouble();
            MixtureVicosity = rand.NextDouble();
            HeatTransferCoefficient = rand.NextDouble();
        }

        public static string GetPropertyDisplayName(string propertyName)
        {
            
            var property = typeof(Simple).GetProperty(propertyName);
            var propertyDsplayName = property.GetCustomAttributes(false)
                .OfType<DisplayNameAttribute>()
                .FirstOrDefault();
            if (propertyDsplayName != null)
            {
                return propertyDsplayName.DisplayName;
            }
            return property.Name;
        }
    }
}