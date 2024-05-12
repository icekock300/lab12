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
        public void Point_DefaultConstructor_DataIsNull()
        {
            // Arrange
            var point = new Point<MusicalInstrument>();

            // Assert
            Assert.IsNull(point.Data);
            Assert.IsNull(point.Left);
            Assert.IsNull(point.Right);
        }

        [TestMethod]
        public void Point_ConstructorWithData_SetsDataAndNullLinks()
        {
            // Arrange
            var testData = new MusicalInstrument("Guitar", new IdNumber(1));
            var point = new Point<MusicalInstrument>(testData);

            // Assert
            Assert.AreEqual(testData, point.Data);
            Assert.IsNull(point.Left);
            Assert.IsNull(point.Right);
        }


        [TestMethod]
        public void CompareTo_CompareTwoPoints_Success()
        {
            // Arrange
            int data1 = 10;
            int data2 = 5;
            Point<int> point1 = new Point<int>(data1);
            Point<int> point2 = new Point<int>(data2);

            // Act
            int result = point1.CompareTo(point2);

            // Assert
            Assert.AreEqual(1, result); // Expecting point1 to be greater than point2
        }

        [TestMethod]
        public void MakeTree_CreateTreeWithSpecifiedLength_Success()
        {
            // Arrange
            int length = 5;
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(length);

            // Act
            tree.MakeTree(length, tree.root);
            int count = CountNodes(tree.root);

            // Assert
            Assert.AreEqual(length, count);
        }

        [TestMethod]
        public void AddPoint_AddNewPointToTree_Success()
        {
            // Arrange
            MyTree<MusicalInstrument> tree = null;
            tree = new MyTree<MusicalInstrument>(3);

            MusicalInstrument instrument1 = new MusicalInstrument("Guitar", new IdNumber(1));
            MusicalInstrument instrument2 = new MusicalInstrument("Piano", new IdNumber(2));
            MusicalInstrument instrument3 = new MusicalInstrument("Drums", new IdNumber(3));

            // Act
            tree.AddPoint(instrument1);
            tree.AddPoint(instrument2);
            tree.AddPoint(instrument3);

            // Assert
            Assert.AreEqual(6, tree.Count);
        }

        //[TestMethod]
        //public void TransformToArray_TransformTreeToArray_Success()
        //{
        //    // Arrange
        //    MyTree<MusicalInstrument> tree = null;

        //    MusicalInstrument instrument1 = new MusicalInstrument("Guitar", new IdNumber(1));
        //    MusicalInstrument instrument2 = new MusicalInstrument("Piano", new IdNumber(2));
        //    MusicalInstrument instrument3 = new MusicalInstrument("Drums", new IdNumber(3));

        //    tree.AddPoint(instrument1);
        //    tree.AddPoint(instrument2);
        //    tree.AddPoint(instrument3);

        //    MusicalInstrument[] expectedArray = { instrument1, instrument2, instrument3 };
        //    MusicalInstrument[] array = new MusicalInstrument[tree.Count];
        //    int current = 0;

        //    // Act
        //    tree.TransformToArray(tree.root, array, ref current);

        //    // Assert
        //    Assert.AreEqual(expectedArray, array);
        //}

        [TestMethod]
        public void TransformToFindTree_TransformTreeToBinarySearchTree_Success()
        {
            // Arrange
            MyTree<MusicalInstrument> tree = null;
            tree = new MyTree<MusicalInstrument>(100);

            // Act
            tree.TransformToFindTree();

            // Assert
            Assert.AreEqual(2, tree.Count);
        }

        //[TestMethod]
        //public void FindMin_FindMinimumElementInTree_Success()
        //{
        //    // Arrange
        //    MyTree<MusicalInstrument> tree = null;
        //    tree = new MyTree<MusicalInstrument>(1);
        //    MusicalInstrument instrument1 = new MusicalInstrument("Гитара", new IdNumber(0));
            
        //    tree.AddPoint(instrument1);
        //    // Act
        //    MusicalInstrument min = tree.FindMin();
        //    // Assert
        //    Assert.AreEqual(instrument1, min);
        //}

        [TestMethod]
        public void RemoveTree_RemoveAllElementsFromTree_Success()
        {
            // Arrange
            MyTree<MusicalInstrument> tree = null;
            tree = new MyTree<MusicalInstrument>(10);
            // Act
            tree.RemoveTree();

            // Assert
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void Remove_RemoveElementFromTree_Success()
        {
            // Arrange
            MyTree<MusicalInstrument> tree = null;
            tree = new MyTree<MusicalInstrument>(2);

            MusicalInstrument instrument1 = new MusicalInstrument("Гитара", new IdNumber(1500));

            tree.AddPoint(instrument1);

            // Act
            tree.Remove(instrument1);

            // Assert
            Assert.AreEqual(2, tree.Count);
        }

        
        private int CountNodes(Point<MusicalInstrument>? point)
        {
            if (point == null)
                return 0;

            return 1 + CountNodes(point.Left) + CountNodes(point.Right);
        }

        
        private bool IsBinarySearchTree(Point<MusicalInstrument>? point, MusicalInstrument min = null, MusicalInstrument max = null)
        {
            if (point == null)
                return true;

            if ((min != null && point.Data.CompareTo(min) <= 0) || (max != null && point.Data.CompareTo(max) >= 0))
                return false;

            return IsBinarySearchTree(point.Left, min, point.Data) && IsBinarySearchTree(point.Right, point.Data, max);
        }

    }
}



