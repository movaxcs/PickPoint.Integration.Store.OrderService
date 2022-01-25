namespace PickPoint.Integration.Store.OrderService.Models
{
    /// <summary>
    /// Статусы заказа
    /// </summary>
    public enum OrderStatus
    {
        Registered = 1,             // Зарегистрирован 
        AcceptedStock = 2,          // Принят на складе 
        IssuedCourier = 3,          // Выдан курьеру 
        DeliveredPostamat = 4,      // Доставлен в постамат 
        DeliveredRecipient = 5,     // Доставлен получателю 
        Canceled = 6                // Отменен 
    }
}
