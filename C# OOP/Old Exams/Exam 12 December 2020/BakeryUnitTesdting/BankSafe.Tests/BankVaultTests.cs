using NUnit.Framework;
using System;

namespace BankSafe.Tests
{

    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;


        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("Az", "1");
        }

        [Test]
        public void WhenCellDoesNOtExist_ShouldThrowExeption()
        {
            Exception exeption = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("no item", item);
            });

            Assert.AreEqual(exeption.Message, "Cell doesn't exists!");
        }

        [Test]
        public void WhenCellAlreadyTaken_ShouldThrowExeption()
        {
            Exception exeption = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("A2", new Item("toi", "3"));
            });

            Assert.AreEqual(exeption.Message, "Cell is already taken!");
        }

        [Test]
        public void WhenCellWithIdAlreadyExist_ShouldThrowExeption()
        {
            Exception exeption = Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("B3", item);
            });

            Assert.AreEqual(exeption.Message, "Item is already in cell!");
        }

        [Test]
        public void WhenItemIsAdded_ShouldReturnCorectly()
        {
            string result = vault.AddItem("A2", item);

            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void WhenRemoveItem_AndThereIsNoCell_ShouldThrowExeption()
        {
            Exception exeption = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A", new Item("A2", "3"));
            });

            Assert.AreEqual(exeption.Message, "Cell doesn't exists!");
        }
        [Test]
        public void WhenRemoveItem_AndThereIsNoItemInTheCell_ShouldThrowExeption()
        {
            vault.AddItem("A1", item);

            Exception exeption = Assert.Throws<ArgumentException>(() =>
            {
                //vault.RemoveItem("A1", item);
                vault.RemoveItem("A1", new Item("Ti", "4"));
            });

            Assert.AreEqual(exeption.Message, $"Item in that cell doesn't exists!");
        }

        [Test]
        public void WhenItemIsRemoved_ShouldReturnCorectly()
        {
            vault.AddItem("A2", item);
            string result = vault.RemoveItem("A2", item);

            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }
    }
}