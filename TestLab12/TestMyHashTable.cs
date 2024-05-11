using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab12_2;
using LibraryLab10;

namespace MyHashTableTests
{
    [TestClass]
    public class MyHashTableTests
    {
        [TestMethod]
        public void Point_DefaultConstructor_DataIsNull()
        {
            // Arrange
            var point = new Point<MusicalInstrument>();

            // Assert
            Assert.IsNull(point.Data);
            Assert.IsNull(point.Next);
            Assert.IsNull(point.Prev);
        }

        [TestMethod]
        public void Point_ConstructorWithData_SetsDataAndNullLinks()
        {
            // Arrange
            var testData = new MusicalInstrument("Guitar", new IdNumber(1));
            var point = new Point<MusicalInstrument>(testData);

            // Assert
            Assert.AreEqual(testData, point.Data);
            Assert.IsNull(point.Next);
            Assert.IsNull(point.Prev);
        }

        [TestMethod]
        public void Point_ToString_ReturnsDataAsString()
        {
            // Arrange
            var testData = new MusicalInstrument("Piano", new IdNumber(2));
            var point = new Point<MusicalInstrument>(testData);

            // Assert
            Assert.AreEqual(testData.ToString(), point.ToString());
        }

        [TestMethod]
        public void Point_GetHashCode_ReturnsHashCodeOfData()
        {
            // Arrange
            var testData = new MusicalInstrument("Drums", new IdNumber(3));
            var point = new Point<MusicalInstrument>(testData);

            // Act
            var expectedHashCode = testData.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, point.GetHashCode());
        }

        [TestMethod]
        public void MyHashTable_DefaultConstructor_CreatesTableWithDefaultCapacity()
        {
            // Arrange & Act
            var table = new MyHashTable<MusicalInstrument>();

            // Assert
            Assert.IsNotNull(table);
            Assert.AreEqual(10, table.Capacity);
        }

        [TestMethod]
        public void MyHashTable_ConstructorWithCustomCapacity_CreatesTableWithSpecifiedCapacity()
        {
            // Arrange
            var customCapacity = 20;

            // Act
            var table = new MyHashTable<MusicalInstrument>(customCapacity);

            // Assert
            Assert.IsNotNull(table);
            Assert.AreEqual(customCapacity, table.Capacity);
        }

        [TestMethod]
        public void MyHashTable_AddPoint_AddsElementToTable()
        {
            // Arrange
            var table = new MyHashTable<MusicalInstrument>();
            var testData = new MusicalInstrument("Guitar", new IdNumber(1));

            // Act
            table.AddPoint(testData);

            // Assert
            Assert.IsTrue(table.Contains(testData));
        }

        [TestMethod]
        public void MyHashTable_Contains_ReturnsTrueIfElementExists()
        {
            // Arrange
            var table = new MyHashTable<MusicalInstrument>();
            var testData = new MusicalInstrument("Piano", new IdNumber(2));
            table.AddPoint(testData);

            // Assert
            Assert.IsTrue(table.Contains(testData));
        }

        [TestMethod]
        public void MyHashTable_Contains_ReturnsFalseIfElementDoesNotExist()
        {
            // Arrange
            var table = new MyHashTable<MusicalInstrument>();
            var testData = new MusicalInstrument("Drums", new IdNumber(3));

            // Assert
            Assert.IsFalse(table.Contains(testData));
        }

        [TestMethod]
        public void MyHashTable_RemoveData_RemovesElementFromTable()
        {
            // Arrange
            var table = new MyHashTable<MusicalInstrument>();
            var testData = new MusicalInstrument("Saxophone", new IdNumber(4));
            table.AddPoint(testData);

            // Act
            table.RemoveData(testData);

            // Assert
            Assert.IsFalse(table.Contains(testData));
        }

        [TestMethod]
        public void MyHashTable_GetIndex_ReturnsValidIndex()
        {
            // Arrange
            var table = new MyHashTable<MusicalInstrument>();
            var testData = new MusicalInstrument("Violin", new IdNumber(5));

            // Act
            var index = table.GetIndex(testData);

            // Assert
            Assert.IsTrue(index >= 0 && index < table.Capacity);
        }

        [TestMethod]
        public void MyHashTable_RemoveByKey_RemovesElementByKey()
        {
            // Arrange
            var table = new MyHashTable<MusicalInstrument>();
            var testData = new MusicalInstrument("Trumpet", new IdNumber(6));
            table.AddPoint(testData);

            // Act
            var result = table.RemoveByKey(testData);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(table.Contains(testData));
        }

        [TestMethod]
        public void MyHashTable_ContainsKey_ReturnsTrueIfKeyExists()
        {
            // Arrange
            var table = new MyHashTable<MusicalInstrument>();
            var testData = new MusicalInstrument("Flute", new IdNumber(7));
            table.AddPoint(testData);

            // Assert
            Assert.IsTrue(table.ContainsKey(testData));
        }

        [TestMethod]
        public void MyHashTable_ContainsKey_ReturnsFalseIfKeyDoesNotExist()
        {
            // Arrange
            var table = new MyHashTable<MusicalInstrument>();
            var testData = new MusicalInstrument("Cello", new IdNumber(8));

            // Assert
            Assert.IsFalse(table.ContainsKey(testData));
        }
    }
}
