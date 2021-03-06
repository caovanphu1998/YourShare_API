﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Domain.Util
{
    public static class ValidateUtils
    {
        public static bool IsNullOrEmpty(string data)
        {
            if (data == null || data == String.Empty)
            {
                return true;
            }
            return false;
        }

        public static bool IsNullOrEmpty(Guid data)
        {
            if (data == null || data == Guid.Empty)
            {
                return true;
            }
            return false;
        }
    }
}
