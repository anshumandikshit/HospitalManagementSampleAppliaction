﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Domain.ServiceModels
{
   public class ServiceResultModel<T>
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public List<T> ListOfData { get; set; }
    }
}
