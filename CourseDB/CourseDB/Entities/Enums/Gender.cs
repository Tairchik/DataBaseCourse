using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public enum Gender
    {
        /// <summary>
        /// Мужской
        /// </summary>
        M,
        /// <summary>
        /// Женский
        /// </summary>
        W
    }

    public class GenderExtensions
    {
        public static string GetStringByEnum(Gender value)
        {
            switch (value)
            {
                case Gender.M: return "Мужской";
                case Gender.W: return "Женский";
            }
            return "";
        }

        public static Gender GetEnumByString(string value)
        {
            switch (value.ToLower())
            {
                case "мужской": return Gender.M;
                case "женский": return Gender.W;
            }
            throw new ArgumentException("Такого состояния не существует");
        }
    }
}
