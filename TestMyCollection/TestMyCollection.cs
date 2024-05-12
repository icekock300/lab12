using lab12_4;
using LibraryLab10;

namespace TestMyCollection;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Point_DefaultConstructor_DataIsNull()
    {
        // Arrange
        Point<MusicalInstrument> point = new Point<MusicalInstrument>();

        // Act

        // Assert
        Assert.IsNull(point.Data);
    }

    [TestMethod]
    public void Point_ParameterizedConstructor_DataIsSet()
    {
        // Arrange
        MusicalInstrument testData = new MusicalInstrument("Test Instrument", new IdNumber(1));

        // Act
        Point<MusicalInstrument> point = new Point<MusicalInstrument>(testData);

        // Assert
        Assert.AreEqual(testData, point.Data);
    }

    [TestMethod]
    public void Point_ToString_NullData_ReturnsEmptyString()
    {
        // Arrange
        Point<MusicalInstrument> point = new Point<MusicalInstrument>();

        // Act

        // Assert
        Assert.AreEqual("", point.ToString());
    }

    [TestMethod]
    public void Point_ToString_NonNullData_ReturnsDataAsString()
    {
        // Arrange
        MusicalInstrument testData = new MusicalInstrument("Test Instrument", new IdNumber(1));
        Point<MusicalInstrument> point = new Point<MusicalInstrument>(testData);

        // Act

        // Assert
        Assert.AreEqual(testData.ToString(), point.ToString());
    }

    [TestMethod]
    public void Constructor_Size()
    {
        MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>(5);

        int length = 5;

        Assert.AreEqual(length, collection.Count);
    }

    [TestMethod]
    public void Add_AddsItem()
    {
        // Arrange
        MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>();
        MusicalInstrument testData = new MusicalInstrument("Guitar", new IdNumber(1));

        // Act
        collection.Add(testData);

        // Assert
        Assert.AreEqual(1, collection.Count);
    }

    [TestMethod]
    public void AddRange_AddsRangeOfItems()
    {
        // Arrange
        MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>();
        MusicalInstrument[] testData = new MusicalInstrument[]
        {
                new MusicalInstrument("Guitar", new IdNumber(1)),
                new MusicalInstrument("Piano", new IdNumber(2)),
                new MusicalInstrument("Violin", new IdNumber(3))
        };

        // Act
        collection.AddRange(testData);

        // Assert
        Assert.AreEqual(testData.Length, collection.Count);
    }

    [TestMethod]
    public void Remove_RemovesItem()
    {
        // Arrange
        MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>();
        MusicalInstrument testData = new MusicalInstrument("Guitar", new IdNumber(1));
        collection.Add(testData);

        // Act
        bool result = collection.Remove(testData);

        // Assert
        Assert.AreEqual(0, collection.Count);
    }

    [TestMethod]
    public void RemoveRange_RemovesRangeOfItems()
    {
        // Arrange
        MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>();
        MusicalInstrument[] testData = new MusicalInstrument[]
        {
                new MusicalInstrument("Guitar", new IdNumber(1)),
                new MusicalInstrument("Piano", new IdNumber(2)),
                new MusicalInstrument("Violin", new IdNumber(3))
        };
        collection.AddRange(testData);

        // Act
        int removedCount = collection.RemoveRange(testData);

        // Assert
        Assert.AreEqual(0, collection.Count);
    }

    [TestMethod]
    public void Find_ReturnsMatchingItem()
    {
        // Arrange
        MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>();
        MusicalInstrument[] testData = new MusicalInstrument[]
        {
                new MusicalInstrument("Guitar", new IdNumber(1)),
                new MusicalInstrument("Piano", new IdNumber(2)),
                new MusicalInstrument("Violin", new IdNumber(3))
        };
        collection.AddRange(testData);

        // Act
        MusicalInstrument result = collection.Find(item => item.InstrumentName == "Piano");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Piano", result.InstrumentName);
    }

    [TestMethod]
    public void DeepCopy_CreatesDeepCopy()
    {
        // Arrange
        MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>();
        MusicalInstrument[] testData = new MusicalInstrument[]
        {
                new MusicalInstrument("Guitar", new IdNumber(1)),
                new MusicalInstrument("Piano", new IdNumber(2)),
                new MusicalInstrument("Violin", new IdNumber(3))
        };
        collection.AddRange(testData);

        // Act
        MyCollection<MusicalInstrument> clone = collection.DeepCopy();

        // Assert
        Assert.AreNotSame(collection, clone);
        Assert.AreEqual(collection.Count, clone.Count);
    }

    [TestMethod]
    public void ShallowCopy_Test()
    {
        // Arrange
        MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>(5);

        // Act
        MyCollection<MusicalInstrument> copy = collection.ShallowCopy();

        // Assert
        
        Assert.AreEqual(collection.Count - 1, copy.Count);
    }
}
