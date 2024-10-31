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
        }

        public static class CarCategory
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 20;
        }
    }
}
