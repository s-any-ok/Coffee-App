﻿using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Service.Models
{
    public class IngredientTypeView
    {
        public int Id { get; set; }

        public string IngredientName { get; set; }
    }
}
