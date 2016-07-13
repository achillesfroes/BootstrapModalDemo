using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModalDemo.Models
{
    public class Comarca
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual IList<Vara> Varas { get; set; }
    }
}