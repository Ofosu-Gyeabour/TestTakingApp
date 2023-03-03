using System.ComponentModel.DataAnnotations;

using System;
using System.Data;
using System.Data.SqlClient;

namespace PETAS.Classes
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string username { get; set; } 

        public string pass { get; set; }

    }

}
