using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    /// <summary>
    /// BusState - коллекция хранит 4 состояния автобуса: исправен, не исправен, в ремонте, списан
    /// </summary>
    public enum BusState
    {
        /// <summary>
        /// Исправен
        /// </summary>
        InOperation,

        /// <summary>
        /// Не исправен
        /// </summary>
        UnOperation,

        /// <summary>
        /// В ремонте
        /// </summary>
        InRepair,

        /// <summary>
        /// Списан
        /// </summary>
        WrittenOff,
    }

    public class BusStateExtensions
    {
        public static string GetStringByEnum(BusState value)
        {
            switch (value)
            {
                case BusState.InOperation: return "Исправен";
                case BusState.UnOperation: return "Не исправен";
                case BusState.InRepair: return "В ремонте";
                case BusState.WrittenOff: return "Списан";
            }
            return "";
        }

        public static BusState GetEnumByString(string value)
        {
            switch (value.ToLower())
            {
                case "исправен": return BusState.InOperation;
                case "не исправен": return BusState.UnOperation;
                case "в ремонте": return BusState.InRepair;
                case "списан": return BusState.WrittenOff;
            }
            throw new ArgumentException("Такого состояния не существует");
        }
    }
}
