﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain
{
    public class CidadeDTO : BaseDTO
    {
        public string Nome { get; set; }

        public string UF { get; set; }

        public bool Ativo { get; set; }
    }
}
