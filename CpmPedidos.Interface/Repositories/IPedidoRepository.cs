﻿namespace CpmPedidos.Interface.Repositories
{
    public interface IPedidoRepository
    {
        decimal MaxTicket();
        dynamic ClientOrder();
    }
}