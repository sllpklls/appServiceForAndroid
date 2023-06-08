﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace appServiceForAndroid.Data
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public double Max { get; set; }

    }
}
