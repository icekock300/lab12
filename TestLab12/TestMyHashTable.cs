using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab12_2;
using LibraryLab10;
using System.Drawing;

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
        public void TestCapacity_DefaultConstructor_DefaultCapacity()
        {
            // Arrange
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();

            // Assert
            Assert.AreEqual(10, hashTable.Capacity);
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
        public void TestRemoveData_RemovesElement()
        {
            // Arrange
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            var item1 = new MusicalInstrument("Guitar", new IdNumber(3));
            var item2 = new MusicalInstrument("Piano", new IdNumber(33));
            hashTable.AddPoint(item1);
            hashTable.AddPoint(item2);

            // Act
            bool removed = hashTable.RemoveData(item1);

            // Assert
            Assert.IsTrue(removed);
            Assert.IsFalse(hashTable.Contains(item1));
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
        public void MyHashTable_RemoveData_RemovesElementFromTable_2()
        {
            // Arrange
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
            for (int i = 0; i < 50; i++)
            {
                MusicalInstrument musicalForAdd = new MusicalInstrument();
                musicalForAdd.RandomInit();
                table.AddPoint(musicalForAdd);
            }
            table = new MyHashTable<MusicalInstrument>(50);
            MusicalInstrument testData = new MusicalInstrument("Saxophone", new IdNumber(4));
            table.AddPoint(testData);

            // Act
            table.RemoveData(testData);

            // Assert
            Assert.IsFalse(table.Contains(testData));
            Assert.AreEqual(50, table.Capacity);
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
        public void MyHashTable_RemoveByKey_RemovesElementByKey_2()
        {
            // Arrange
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
            for (int i = 0; i < 50; i++)
            {
                MusicalInstrument musicalForAdd = new MusicalInstrument();
                musicalForAdd.RandomInit();
                table.AddPoint(musicalForAdd);
            }
            table = new MyHashTable<MusicalInstrument>(50);
            MusicalInstrument testData1 = new MusicalInstrument("Guitar", new IdNumber(1));
            MusicalInstrument testData2 = new MusicalInstrument("ElectricGuitar", new IdNumber(2));
            MusicalInstrument testData3 = new MusicalInstrument("Piano", new IdNumber(12));
            table.AddPoint(testData1);
            table.AddPoint(testData2);
            table.AddPoint(testData3);

            // Act
            bool result = table.RemoveByKey(testData3);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(table.Contains(testData3));
        }

        [TestMethod]
        public void MyHashTable_RemoveByKey_RemovesElementByKey_3()
        {
            // Arrange
            var table = new MyHashTable<MusicalInstrument>();
            var testData = new MusicalInstrument("Trumpet", new IdNumber(6));
            //table.AddPoint(testData);

            // Act
            var result = table.RemoveByKey(testData);

            // Assert
            Assert.IsFalse(result);
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

        //[TestMethod]
        //[ExpectedException(typeof(Exception), "System.DivideByZeroException")]
        //public void TestAddData_DuplicateItem_ThrowsException()
        //{
        //    // Arrange
        //    MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>(0);
        //    var testdata = new MusicalInstrument("Guitar", new IdNumber(3));

        //    // Act
        //    hashTable.Contains(testdata); // пытаемся добавить дубликат

        //    // Assert
        //    // Ожидаем исключение, так как дубликат элемента не должен быть добавлен
        //}

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
