using App.Shared.Models.AdditionsModules.Shared.Units;
using App.Shared.Models.AdditionsModules.Shared.Units.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.Shared.Units.Services
{
    public static class UnitsAdaptor
    {
        public static Expression<Func<Unit, UnitInfo>> SelectExpressionUnitInfo()
        {
            return unit => new UnitInfo
            {
                unitId = unit.unitId,
                unitName = unit.unitName,
                unitSympol = unit.unitSympol
            };
        }

        public static Expression<Func<Unit, UnitInfoDetails>> SelectExpressionUnitDetails()
        {
            return unit => new UnitInfoDetails
            {
                unitId = unit.unitId,
                unitName = unit.unitName,
                unitSympol = unit.unitSympol,
                unitDescription = unit.unitDescription
            };
        }

        public static Expression<Func<Unit, UnitInfo>> SelectExpressionUnitInfo(this Unit unit)
        {
            return unit => new UnitInfo
            {
                unitId = unit.unitId,
                unitName = unit.unitName,
                unitSympol = unit.unitSympol
            };
        }

        public static Expression<Func<Unit, UnitInfoDetails>> SelectExpressionUnitDetails(this Unit unit)
        {
            return unit => new UnitInfoDetails
            {
                unitId = unit.unitId,
                unitName = unit.unitName,
                unitSympol = unit.unitSympol,
                unitDescription = unit.unitDescription
            };
        }
    }
}