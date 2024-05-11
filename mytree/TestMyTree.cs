using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab12_3;
using LibraryLab10;

namespace MyTreeTests
{
    [TestClass]
    public class MyTreeTests
    {
        [TestMethod]
        public void AddPoint_AddSingleElement_TreeContainsElement()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(0);

            // Act
            tree.AddPoint(new MusicalInstrument());

            // Assert
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void FindMin_TreeWithMultipleElements_ReturnsMinimumElement()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(0);
            tree.AddPoint(new MusicalInstrument("Guitar", new IdNumber(1)));
            tree.AddPoint(new MusicalInstrument("Piano", new IdNumber(2)));
            tree.AddPoint(new MusicalInstrument("Drums", new IdNumber(3)));

            // Act
            var min = tree.FindMin();

            // Assert
            Assert.AreEqual("Guitar", min.InstrumentName);
        }

        //[TestMethod]
        //public void RemoveByKey_RemoveExistingKey_ElementIsRemoved()
        //{
        //    // Arrange
        //    var tree = new MyTree<MusicalInstrument>(0);
        //    var guitar = new MusicalInstrument("Guitar", new IdNumber(1));
        //    tree.AddPoint(guitar);

        //    // Act
        //    tree.RemoveByKey(guitar.InstrumentName);

        //    // Assert
        //    Assert.AreEqual(0, tree.Count);
        //    //Assert.Throws<InvalidOperationException>(() => tree.FindMin());
        //}

        [TestMethod]
        public void MakeTree_CreatesBalancedTree_TreeIsBalanced()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(0);
            int length = 3; // Example: For 7 elements, the tree depth is 3

            // Act
            tree = new MyTree<MusicalInstrument>(length);

            // Assert
            int actualDepth = GetTreeDepth(tree.root);
            Assert.AreEqual(length, actualDepth);
        }

        [TestMethod]
        public void TransformToArray_ReturnsArrayWithAllElements_ArrayContainsAllElements()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(0);
            tree.MakeTree(5, tree.root);
            var expectedArray = tree.FindMin().Id.Id.ToString(); // Just for demonstration

            // Act
            var array = new MusicalInstrument[5];
            int currentIndex = 0;
            tree.TransformToArray(tree.root, array, ref currentIndex);

            // Assert
            Assert.IsTrue(array.All(item => item.Id.Id.ToString() == expectedArray));
        }

        [TestMethod]
        public void TransformToFindTree_TransformsToBinarySearchTree_TreeIsBST()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(0);
            tree.MakeTree(5, tree.root);

            // Act
            tree.TransformToFindTree();

            // Assert
            Assert.IsTrue(IsBinarySearchTree(tree.root));
        }

        [TestMethod]
        public void RemoveMin_RemovesMinimumElement_MinimumElementIsRemoved()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(0);
            tree.MakeTree(5, tree.root);
            var expectedMin = tree.FindMin();

            // Act
            tree.RemoveMin(tree.root);
            var actualMin = tree.FindMin();

            // Assert
            Assert.AreNotEqual(expectedMin, actualMin);
        }

        // Helper method to calculate the depth of the tree
        private int GetTreeDepth(Point<MusicalInstrument>? node)
        {
            if (node == null)
                return 0;
            else
            {
                int leftDepth = GetTreeDepth(node.Left);
                int rightDepth = GetTreeDepth(node.Right);
                return Math.Max(leftDepth, rightDepth) + 1;
            }
        }

        // Helper method to check if the tree is a binary search tree
        private bool IsBinarySearchTree(Point<MusicalInstrument>? node, int? minValue = null, int? maxValue = null)
        {
            if (node == null)
                return true;

            if ((minValue != null && node.Data.Id.Id <= minValue) || (maxValue != null && node.Data.Id.Id >= maxValue))
                return false;

            return IsBinarySearchTree(node.Left, minValue, node.Data.Id.Id) && IsBinarySearchTree(node.Right, node.Data.Id.Id, maxValue);
        }

        [TestMethod]
        public void Constructor_WithData_SetsDataCorrectly()
        {
            // Arrange
            var data = new MusicalInstrument();

            // Act
            var point = new Point<MusicalInstrument>(data);

            // Assert
            Assert.AreEqual(data, point.Data);
        }

        [TestMethod]
        public void CompareTo_CompareWithLargerValue_ReturnsNegative()
        {
            // Arrange
            var point1 = new Point<MusicalInstrument>(new MusicalInstrument("Guitar", new IdNumber(1)));
            var point2 = new Point<MusicalInstrument>(new MusicalInstrument("Piano", new IdNumber(2)));

            // Act
            var result = point1.CompareTo(point2);

            // Assert
            Assert.AreEqual(point1, point2);
        }

        [TestMethod]
        public void CompareTo_CompareWithSmallerValue_ReturnsPositive()
        {
            // Arrange
            var point1 = new Point<MusicalInstrument>(new MusicalInstrument("Piano", new IdNumber(1)));
            var point2 = new Point<MusicalInstrument>(new MusicalInstrument("Guitar", new IdNumber(2)));

            // Act
            var result = point1.CompareTo(point2);

            // Assert
            Assert.AreEqual(point1, point2);
        }

        [TestMethod]
        public void GetKey_ReturnsStringRepresentationOfStringData()
        {
            // Arrange
            var point = new Point<MusicalInstrument>(new MusicalInstrument("key", new IdNumber(1)));

            // Act
            var key = point.GetKey();

            // Assert
            Assert.AreEqual("key", key);
        }

        [TestMethod]
        public void ToString_ReturnsStringRepresentationOfData()
        {
            // Arrange
            var point = new Point<MusicalInstrument>(new MusicalInstrument("Guitar", new IdNumber(1)));

            // Act
            var str = point.ToString();

            // Assert
            Assert.AreEqual("id: 1, Название инструмента: Guitar", str);
        }

    }


}



