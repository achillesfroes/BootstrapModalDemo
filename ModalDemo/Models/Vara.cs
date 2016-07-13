using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModalDemo.Models
{
    public class Vara
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int ComarcaId { get; set; }
        public Comarca Comarca { get; set; }
    }
}