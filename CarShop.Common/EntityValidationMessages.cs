using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Common
{
    public static class EntityValidationMessages
    {
        public static class Car
        {   
            public const string MakeRequiredMessage = "Make needs to be between 3 and 60 characters.";
            public const string ModelRequiredMessage = "Model needs to be between 3 and 60 characters.";
            public const string ProductionYearRequiredMessage = "Please enter a valid production year.";
            public const string FuelConsumptionRequiredMessage = "Fuel consumption must be a positive number.";
            public const string TankVolumeRequiredMessage = "Tank volume must be a positive number.";
            public const string MaximumSpeedRequiredMessage = "Maximum speed must be a positive number.";
            public const string DoorsCountRequiredMessage = "Doors count must be between 1 and 10.";
            public const string SeatingCapacityRequiredMessage = "Seating capacity must be between 1 and 20.";
            public const string PricePerDayRequiredMessage = "Price per day must be a positive number.";
        }

        public static class DamageReport
        {
            public const string DescriptionRequiredMessage = "Description must be between 50 and 500.";
            public const string CostEtimationRequiredMessage = "Cost etimation must be a positive number.";
            public const string InvalidCarIdMessage = "Invalid car ID";
            public const string InvalidDamageReportIdMessage = "Invalid damage report ID";
        }

        public static class Feedback
        {
            public const string CommentRequiredMessage = "Your comment should be between 10 and 250 characters long.";
            public const string RatingRequiredMessage = "Your rating should be between 1 and 5 included.";
            public const string InvalidDamageReportIdMessage = "Invalid damage report ID";
            public const string InvalidCarIdMessage = "Invalid car ID";
            public const string InvalidFeedbackUserEditMessage = "You do not have permission to edit this feedback.";
        }

        public static class Rental
        {
            public const string CommentRequiredMessage = "Your comment should be between 10 and 250 characters long.";
            public const string InvalidCarIdMessage = "Invalid car ID";
            public const string InvalidUserRentalRemoveMessage = "You do not have permission to remove this rental.";
        }
    }
}
