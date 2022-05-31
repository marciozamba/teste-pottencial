using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pottencial.Core.Enums
{
    public enum StatusVenda
    {
        [Description("Aguardando pagamento")]
        AguardandoPagamento = 0,
        [Description("Pagamento aprovado")]
        PagamentoAprovado = 1,
        [Description("Enviado para transportadora")]
        EnviadoTransportadora = 2,
        [Description("Entregue")]
        Entregue = 3,
        [Description("Cancelada")]
        Cancelada = 4
    }
}
