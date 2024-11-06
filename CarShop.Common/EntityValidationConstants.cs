using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Common
{
    public static class EntityValidationConstants
    {
        public static class Car
        {
            public const int MakeMinLength = 3;
            public const int MakeMaxLength = 60;
            public const int ModelMinLenght = 3;
            public const int ModelMaxLenght = 60;
            public const int ProductionYearMinRange = 1886;
            public const int ProductionYearMaxRange = 2100;
            public const double FuelConsumptionMinRange = 1.0;
            public const double FuelConsumptionMaxRange = 100;
            public const double TankVolumeMinRange = 1;
            public const double TankVolumeMaxRange = 181;
            public const int MaximumSpeedMinRange = 45;
            public const int MaximumSpeedMaxRange = 1250;
            public const int CarImageMaxLength = 500;
            public const int DoorsCountMinRange = 1;
            public const int DoorsCountMaxRange = 10; 
            public const int SeatingCapacityMinRange = 1;
            public const int SeatingCapacityMaxRange = 20;
            public const string PricePerDayMinRange = "20";
            public const string PricePerDayMaxRange = "10000";
        }

        public static class CarCategory
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 20;
        }

        public static class DamageReport
        {
            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;
        }

        public static class Discount
        {
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 50;
        }

        public static class Feedback
        {
            public const int CommentMinLength = 10;
            public const int CommentMaxLength = 250;
            public const int RatingMinRange = 1;
            public const int RatingMaxRange = 5;
        }
    }
}
