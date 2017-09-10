namespace BashSoftTesting
{
    using BashSoft.Contracts;
    using BashSoft.DataStructures;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtroWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            // Act
            this.names.Add("Nasko");

            // Assert
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            // Arrange
            List<string> expected = new List<string>() { "Balkan", "Georgi", "Rosen" };

            // Act
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            // Assert
            CollectionAssert.AreEqual(expected, this.names);
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            // Act
            for (int i = 0; i < 17; i++)
            {
                this.names.Add(i.ToString());
            }

            // Assert
            Assert.IsFalse(this.names.Capacity == 16);
            Assert.AreEqual(this.names.Size, 17);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            // Arrange
            List<string> list = new List<string>() { "Tosho", "Mosho" };

            // Act
            this.names.AddAll(list);

            // Assert
            Assert.AreEqual(2, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            // Arrange
            List<string> expected = new List<string>() { "Balkan", "Georgi", "Rosen" };
            List<string> list = new List<string>() { "Georgi", "Rosen", "Balkan" };

            // Act
            this.names.AddAll(list);

            // Assert
            CollectionAssert.AreEqual(expected, this.names);
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            // Act
            this.names.Add("Tosho");
            this.names.Remove("Tosho");

            // Assert
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            // Arrange
            List<string> expected = new List<string>() { "Balkan", "Georgi", "Rosen" };
            List<string> list = new List<string>() { "Georgi", "Rosen", "Balkan", "Nesho" };

            // Act
            this.names.AddAll(list);
            this.names.Remove("Nesho");

            // Assert
            CollectionAssert.AreEqual(expected, this.names);
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }

        [Test]
        public void TestJoinWithNull()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            // Arrange
            string expected = "Gosho, Mosho, Tosho";
            this.names.Add("Tosho");
            this.names.Add("Mosho");
            this.names.Add("Gosho");

            // Assert
            Assert.AreEqual(expected, this.names.JoinWith(", "));
        }
    }
}