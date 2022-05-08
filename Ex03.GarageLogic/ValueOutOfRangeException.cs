using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException: Exception
    {
        private float m_StartRange;
        private float m_EndRange;
        private string m_Name;

        public ValueOutOfRangeException(float i_StartRange, float i_EndRange, string i_Name)
            : base(string.Format(
                @"The value isn't inside range (exceeded from radge):
                start range = {0} ,
                end range = {1}", i_StartRange, i_EndRange))
        {
            m_StartRange = i_StartRange;
            m_EndRange = i_EndRange;
            m_Name = i_Name;
        }

        public override string Source
        {
            get { return m_Name; }
        }
    }
}

