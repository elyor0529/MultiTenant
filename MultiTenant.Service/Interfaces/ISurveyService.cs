﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Service.Interfaces
{
    public interface ISurveyService
    {
        IEnumerable<KeyValuePair<int, string>> GetSurveyItems();
    }
}
