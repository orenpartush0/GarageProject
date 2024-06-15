using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; }
        public float MinValue { get; }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_Msg = null)
            : base(i_Msg != null ? i_Msg : $"Value out of allowed range. Allowed range is between {i_MinValue} and {i_MaxValue}.")
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }

        public static void CheckValue(float i_Value, float i_MinValue, float i_MaxValue)
        {
            if (i_Value < i_MinValue || i_Value > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue);
            }
        }
    }
}
