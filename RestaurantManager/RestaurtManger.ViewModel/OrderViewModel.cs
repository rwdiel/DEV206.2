using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;
using System;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        public OrderViewModel()
        {
            AddToOrderCommand = new Command(AddToOrder);
            SubmitOrderCommand = new Command(SubmitOrder);
        }

        private void SubmitOrder(object obj)
        {
            Order newOrder = new Order();
            newOrder.Table = base.Repository.Tables[0];
            newOrder.Items = new List<MenuItem>();
            newOrder.Items.AddRange(CurrentlySelectedMenuItems);

            base.Repository.Orders.Add(newOrder);
            newOrder = null;
            CurrentlySelectedMenuItems.Clear();
        }

        private void AddToOrder(object obj)
        {
            if (obj is MenuItem)
            {
                CurrentlySelectedMenuItems.Add(obj as MenuItem);
            }
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[4]
            };
        }

        private List<MenuItem> _menuItems = new List<MenuItem>();
        public List<MenuItem> MenuItems
        {
            get { return _menuItems;}
            set
            {
                if (value != this._menuItems)
                {
                    this._menuItems = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<MenuItem> _currentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _currentlySelectedMenuItems; }
            set
            {
                if (value != _currentlySelectedMenuItems)
                {
                    this._currentlySelectedMenuItems = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public Command AddToOrderCommand { get; private set; }
        public Command SubmitOrderCommand { get; private set; }
    }
}
