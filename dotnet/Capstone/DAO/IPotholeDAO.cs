﻿using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPotholeDAO
    {
        List<Pothole> GetAllPotholes();
    }
}