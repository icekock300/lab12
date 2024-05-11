using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab12;
using LibraryLab10;

namespace MyListTests
{
    [TestClass]
    public class MyListTests
    {
        [TestMethod]
        public void MakeRandomDataTest()
        {
            // Arrange
            var list = new MyList<MusicalInstrument>();

            // Act
            var randomData = list.MakeRandomData();

            // Assert
            Assert.IsNotNull(randomData);
        }

        [TestMethod]
        public void MakeRandomItemTest()
        {
            // Arrange
            var list = new MyList<MusicalInstrument>();

            // Act
            var randomItem = list.MakeRandomItem();

            // Assert
            Assert.IsNotNull(randomItem);
        }

        [TestMethod]
        public void AddToBeginTest()
        {
            // Arrange
            var list = new MyList<MusicalInstrument>();
            var item = new MusicalInstrument("Guitar", new IdNumber(1));

            // Act
            list.AddToBegin(item);

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(item, list.FindItem(item).Data);
        }

        [TestMethod]
        public void AddToEndTest()
        {
            // Arrange
            var list = new MyList<MusicalInstrument>();
            var item = new MusicalInstrument("Piano", new IdNumber(2));

            // Act
            list.AddToEnd(item);

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(item, list.FindItem(item).Data);
        }

        [TestMethod]
        public void FindItemTest()
        {
            // Arrange
            var list = new MyList<MusicalInstrument>();
            var item = new MusicalInstrument("Drums", new IdNumber(3));
            list.AddToEnd(item);

            // Act
            var foundItem = list.FindItem(item);

            // Assert
            Assert.IsNotNull(foundItem);
            Assert.AreEqual(item, foundItem.Data);
        }

        [TestMethod]
        public void RemoveItemTest()
        {
            // Arrange
            var list = new MyList<MusicalInstrument>();
            var item = new MusicalInstrument("Flute", new IdNumber(4));
            list.AddToEnd(item);

            // Act
            var removed = list.RemoveItem(item);

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.FindItem(item));
        }

        

        [TestMethod]
        public void ClearTest()
        {
            // Arrange
            var list = new MyList<MusicalInstrument>();
            list.AddToEnd(new MusicalInstrument("Trumpet", new IdNumber(7)));
            list.AddToEnd(new MusicalInstrument("Clarinet", new IdNumber(8)));

            // Act
            list.Clear();

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void MyListDefaultConstructorTest()
        {
            // Arrange & Act
            var list = new MyList<MusicalInstrument>();

            // Assert
            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void MyListSizeConstructorTest()
        {
            // Arrange
            int size = 3;

            // Act
            var list = new MyList<MusicalInstrument>(size);

            // Assert
            Assert.IsNotNull(list);
            Assert.AreEqual(size, list.Count);
        }

        [TestMethod]
        public void MyListCollectionConstructorTest()
        {
            // Arrange
            var instruments = new[]
            {
                new MusicalInstrument("Guitar", new IdNumber(1)),
                new MusicalInstrument("Piano", new IdNumber(2)),
                new MusicalInstrument("Violin", new IdNumber(3))
            };

            // Act
            var list = new MyList<MusicalInstrument>(instruments);

            // Assert
            Assert.IsNotNull(list);
            
            Assert.IsTrue(list.FindItem(instruments[0]) != null);
            Assert.IsTrue(list.FindItem(instruments[1]) != null);
            Assert.IsTrue(list.FindItem(instruments[2]) != null);
        }

        [TestMethod]
        public void PointDefaultConstructorTest()
        {
            // Arrange & Act
            var point = new Point<MusicalInstrument>();

            // Assert
            Assert.IsNotNull(point);
            Assert.IsNull(point.Data);
            Assert.IsNull(point.Next);
            Assert.IsNull(point.Prev);
        }

        [TestMethod]
        public void PointWithDataConstructorTest()
        {
            // Arrange
            var instrument = new MusicalInstrument("Guitar", new IdNumber(1));

            // Act
            var point = new Point<MusicalInstrument>(instrument);

            // Assert
            Assert.IsNotNull(point);
            Assert.AreEqual(instrument, point.Data);
            Assert.IsNull(point.Next);
            Assert.IsNull(point.Prev);
        }
    }
}
