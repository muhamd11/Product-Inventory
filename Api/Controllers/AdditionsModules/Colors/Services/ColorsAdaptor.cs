using App.Shared.Models.AdditionsModules.ColorModule;
using App.Shared.Models.AdditionsModules.ColorModule.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.Colors.Services
{
    public static class ColorsAdaptor
    {
        public static Expression<Func<Color, ColorInfo>> SelectExpressionColorInfo()
        {
            return color => new ColorInfo
            {
                colorId = color.colorId,
                colorName = color.colorName,
                colorSympol = color.colorSympol
            };
        }

        public static Expression<Func<Color, ColorInfoDetails>> SelectExpressionColorDetails()
        {
            return color => new ColorInfoDetails
            {
                colorId = color.colorId,
                colorName = color.colorName,
                colorSympol = color.colorSympol,
                colorDescription = color.colorDescription
            };
        }

        public static Expression<Func<Color, ColorInfo>> SelectExpressionColorInfo(this Color color)
        {
            return color => new ColorInfo
            {
                colorId = color.colorId,
                colorName = color.colorName,
                colorSympol = color.colorSympol
            };
        }

        public static Expression<Func<Color, ColorInfoDetails>> SelectExpressionColorDetails(this Color color)
        {
            return color => new ColorInfoDetails
            {
                colorId = color.colorId,
                colorName = color.colorName,
                colorSympol = color.colorSympol,
                colorDescription = color.colorDescription
            };
        }
    }
}