using System.Collections.Generic;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;
        }

        private List<Order> _orderItems = new List<Order>();
        public List<Order> OrderItems
        {
            get { return base.Repository.Orders; }
            set
            {
                if(value !=_orderItems)
                {
                    _orderItems = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
