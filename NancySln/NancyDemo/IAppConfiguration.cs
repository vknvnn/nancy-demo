using System;
using System.Collections.Generic;
using System.Text;

namespace NancyDemo
{
    public interface IAppConfiguration
    {
        Logging Logging { get; }
        Smtp Smtp { get; }
    }
}
