using System;

namespace FinancialControl
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message) : base(message)
        {
        }
    }
}