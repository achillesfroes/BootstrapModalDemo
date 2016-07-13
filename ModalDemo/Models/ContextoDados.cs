using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModalDemo.Models
{
    public class ContextoDados :DbContext
    {
        public DbSet<Comarca> Comarcas { get; set; }
        public DbSet<Vara> Varas { get; set; }
    }
}