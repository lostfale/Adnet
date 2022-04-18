using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer
namespace adoNEt.ENT
{
    internal class Connect : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = WIN-ODHAFDQSSPK; Database = Players; Trusted_Connection = True;");

        }



    }


}


//Scaffold-DbContext "Server=WIN-ODHAFDQSSPK;Database=Players;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
