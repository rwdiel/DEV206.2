using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {       
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
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
                    this.OnPropertyChanged();
                }
            }
        }

        private List<MenuItem> _currentlySelectedMenuItems = new List<MenuItem>();
        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _currentlySelectedMenuItems; }
            set
            {
                if (value != _currentlySelectedMenuItems)
                {
                    this._currentlySelectedMenuItems = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
