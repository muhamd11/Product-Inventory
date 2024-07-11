using App.Shared.Models.AdditionsModules.Shared.Colors;
using App.Shared.Models.AdditionsModules.Shared.Colors.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.Shared.Colors
{
    public static class ColorsAdaptor
    {
        public static Expression<Func<Color, ColorInfo>> SelectExpressionColorInfo()
        {
            return color => new ColorInfo
            {
                colorId = color.colorId,
                colorName = color.colorName,
                colorHexCode = color.colorHexCode
            };
        }

        public static Expression<Func<Color, ColorInfoDetails>> SelectExpressionColorDetails()
        {
            return color => new ColorInfoDetails
            {
                colorId = color.colorId,
                colorName = color.colorName,
                colorHexCode = color.colorHexCode,
                colorDescription = color.colorDescription
            };
        }

        public static Expression<Func<Color, ColorInfo>> SelectExpressionColorInfo(this Color color)
        {
            return color => new ColorInfo
            {
                colorId = color.colorId,
                colorName = color.colorName,
                colorHexCode = color.colorHexCode
            };
        }

        public static Expression<Func<Color, ColorInfoDetails>> SelectExpressionColorDetails(this Color color)
        {
            return color => new ColorInfoDetails
            {
                colorId = color.colorId,
                colorName = color.colorName,
                colorHexCode = color.colorHexCode,
                colorDescription = color.colorDescription
            };
        }
    }
}