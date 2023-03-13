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
            Array inventory = testInventory.populateInventory().ToArray();
            
            //Should return only one item from the inventory.
            var results = testInventory.search("Title", inventory, "Book1", true);
            foreach(Inventory.inventoryStruct result in results)
            {
                Assert.IsTrue(result.title.Equals("Book1"));
            }

            //Should return 5 items from the inventory
            results = testInventory.search("Title", inventory, "Book", true);
            int count = 1;
            Assert.IsTrue(results.Length == 4);
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
            Array inventory = testInventory.populateInventory().ToArray();

            //Each should return one inventory item 
            var results = testInventory.search("Genere", inventory, "Romance", true);
            foreach (Inventory.inventoryStruct result in results)
            {
                Assert.IsTrue(result.title.Equals("Book3"));
                Assert.IsTrue(Array.Find(result.genere, element => element.Contains("Romance")) != null);
            }
            results = testInventory.search("Genere", inventory, "Adventure", true);
            foreach (Inventory.inventoryStruct result in results)
            {
                Assert.IsTrue(result.title.Equals("Book2"));
                Assert.IsTrue(Array.Find(result.genere, element => element.Contains("Adventure")) != null);
            }
        }

        [TestMethod]
        //Test that user can search by instock items
        public void SearchInstockTest()
        {
            Inventory testInventory = new Inventory();
            Array inventory = testInventory.populateInventory().ToArray();

            //Should return 4 items from the inventory.
            var results = testInventory.search(inventory, true);
            Assert.IsTrue(results.Length == 4);
            int count = 1;
            foreach (Inventory.inventoryStruct result in results)
            {
                Assert.IsTrue(result.title.Equals("Book" + count));
                count++;
            }

            //Should return 5 items from the inventory
            results = testInventory.search(inventory, false);
            count = 1;
            Assert.IsTrue(results.Length == 5);
            foreach (Inventory.inventoryStruct result in results)
            {
                Assert.IsTrue(result.title.Equals("Book" + count));
                count++;
            }
        }
    }
}