using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepository
{
    public class MenuRepository
    {
        private List<Menu> _menuItems = new List<Menu>();
       
        public void CreateMenuItems(Menu menuItem)
        {
            _menuItems.Add(menuItem);
        }
        
        public List<Menu> GetMenuList()
        {
            return _menuItems;
        }
        
        public bool DeleteMenuItems(string mealName)
        {
            Menu menuItem = GetMenuItemsByMealName(mealName);
            if (menuItem == null)
            {
                return false;
            }
            int initialCount = _menuItems.Count;
            _menuItems.Remove(menuItem);
            if (initialCount > _menuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public Menu GetMenuItemsByMealName(string mealName)
        {
            foreach (Menu menuItem in _menuItems)
            {
                if (menuItem.MealName.ToLower() == mealName.ToLower())
                {
                    return menuItem;
                }
            }
            return null;
        }
    }
}
