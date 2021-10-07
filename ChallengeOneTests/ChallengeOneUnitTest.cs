using ChallengeOneRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOneTests
{
    [TestClass]
    public class ChallengeOneUnitTest
    {
        [TestMethod]
        private void CreateMenuItems_ShouldNotGetNull()
        {
            Menu menuItems = new Menu();
            menuItems.MealName = "HamSandy";
            MenuRepository menuRepo = new ChallengeOneRepository.MenuRepository();
        
            menuRepo.CreateMenuItems(menuItems);
            Menu menuItemsFromMenu = menuRepo.GetMenuItemsByMealName("HamSandy");
    
            Assert.IsNotNull(menuItemsFromMenu);
        }
        [TestMethod]
        public void DeleteMenuItems_ShouldReturnTrue()
        {
            Menu menuItems = new Menu();
            menuItems.MealName = "Panini";
            MenuRepository menuRepo = new MenuRepository();
            
            menuRepo.CreateMenuItems(menuItems);
            bool deleteMenuItem = menuRepo.DeleteMenuItems("Panini");
            
            Assert.IsTrue(deleteMenuItem);
        }
        [TestMethod]
        public void GetMenuList_IsNotNull()
        {
            MenuRepository menuRepo = new MenuRepository();
            
            List<Menu> menuItemsList = menuRepo.GetMenuList();
            
            Assert.IsNotNull(menuItemsList);
        }
    }
}

