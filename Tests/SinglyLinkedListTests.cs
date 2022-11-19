using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.SinglyLinkedList;
using Moq;
using NUnit.Framework;
using FluentAssertions;

namespace Tests
{
    [TestFixture]
    public class SinglyLinkedListTests
    {
        private SinglyLinkedList<int> _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new SinglyLinkedList<int>(new SLLNode<int>(10));
        }

        [Test]
        public void InsertAtFront_ShouldMakeNodeAddedEqualHead()
        {
            // Arrange
            var nodeValueToAdd = 20;

            // Act
            _sut.InsertAtFront(nodeValueToAdd);

            // Assert
            var nodeValueAdded = _sut.Head.Data;
            nodeValueAdded.Should().Be(nodeValueToAdd);
        }

        [Test]
        public void InsertAtBack_ShouldMakeNodeAddedEqualLastNode()
        {
            // Arrange
            var nodeValueToAdd = 20;

            // Act
            _sut.InsertAtBack(nodeValueToAdd);

            // Assert
            var nodeValueAdded = _sut.GetLastNode().Data;
            nodeValueAdded.Should().Be(nodeValueToAdd);
        }

        [Test]
        [TestCase(20, 20)]
        [TestCase(-30, -30)]
        [TestCase(0, 0)]
        [TestCase(null, null)]
        public void GetLastNode_ShouldReturnLastNode(int numToAdd, int expected)
        {
            // Arrange
            _sut.InsertAtBack(numToAdd);

            // Act
            var actualNode = _sut.GetLastNode();
            var actualValue = actualNode.Data;

            // Assert
            actualValue.Should().Be(expected);
        }

        [Test]
        public void InsertAfterNode_ShouldAddNodeAfterGivenNode()
        {
            // Arrange
            var node = _sut.GetLastNode();

            // Act
            _sut.InsertAfterNode(node, 30);

            // Assert
            var nodeValueAdded = _sut.GetLastNode().Data;
            nodeValueAdded.Should().Be(30);
        }

        [Test]
        public void RemoveFirstNode_FirstNodeShouldBeDifferentAfterMethodCall()
        {
            // Arrange
            var firstNodeBeforeCall = _sut.FirstOrDefault();

            // Act
            _sut.RemoveFirstNode();

            // Assert
            var firstNodeAfterCall = _sut.FirstOrDefault();
            firstNodeAfterCall.Should().NotBe(firstNodeBeforeCall);
        }

        [Test]
        public void Reverse_ShouldMakeLastNodeEqualFirstNode()
        {
            // Arrange
            _sut.InsertAtBack(20);
            _sut.InsertAtBack(30);
            _sut.InsertAtBack(40);
            _sut.InsertAtBack(50);
            _sut.InsertAtBack(60);
            var firstNodeBeforeCall = _sut.FirstOrDefault();
            var lastNodeBeforeCall = _sut.Last();

            // Act
            _sut.Reverse();

            // Assert
            var lastNodeAfterCall = _sut.Last();
            var firstNodeAfterCall = _sut.FirstOrDefault();
            lastNodeAfterCall.Should().Be(firstNodeBeforeCall);
            lastNodeBeforeCall.Should().Be(firstNodeAfterCall);
        }
    }
}
