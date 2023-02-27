using System;
using System.Collections;
using Milestone_Project;

namespace Milestone_Test
{
    [TestClass]
    public class InventoryUnitTest
    {

        [TestMethod]
        //Test that user can search by book title
        public void SearchTitleTest()
        {
            Inventory testInventory = new Inventory();
            ArrayList inventory = testInventory.populateInventory();
            
            //Should return only one item from the inventory.
            var results = testInventory.search("Title", inventory, "Book1").ToArray();
            foreach(Inventory.inventoryStruct result in results)
            {
                Assert.IsTrue(result.title.Equals("Book1"));
            }

            //Should return 3 items from the inventory
            results = testInventory.search("Title", inventory, "Book").ToArray();
            int count = 1;
            Assert.IsTrue(results.Length == 3);
            foreach (Inventory.inventoryStruct result in results)
            {
                Assert.IsTrue(result.title.Equals("Book" + count));
                count++;
            }
        }

        [TestMethod]
        //Test that user can search by book Genere
        public void SearchGenereTest()
        {
            Inventory testInventory = new Inventory();
            ArrayList inventory = testInventory.populateInventory();

            //Each should return one inventory item 
            var results = testInventory.search("Genere", inventory, "Romance").ToArray();
            foreach (Inventory.inventoryStruct result in results)
            {
                Assert.IsTrue(result.title.Equals("Book3"));
                Assert.IsTrue(Array.Find(result.genere, element => element.Contains("Romance")) != null);
            }
            results = testInventory.search("Genere", inventory, "Adventure").ToArray();
            foreach (Inventory.inventoryStruct result in results)
            {
                Assert.IsTrue(result.title.Equals("Book2"));
                Assert.IsTrue(Array.Find(result.genere, element => element.Contains("Adventure")) != null);
            }
        }
    }
}