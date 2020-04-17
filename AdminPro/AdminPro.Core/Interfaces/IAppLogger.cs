using System;
using System.Collections.Generic;
using System.Text;

namespace AdminPro.Core.Interfaces
{
    public interface IAppLogger
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
    }
}
