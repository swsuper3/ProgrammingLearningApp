using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class Character
    {
        public Direction ViewDirection { get { return viewDirection.Value; } }

        LinkedListNode<Direction> viewDirection;

        public Character()
        {
            Direction[] directions = (Direction[]) Enum.GetValues(typeof(Direction));

            LinkedList<Direction> ll = new LinkedList<Direction>(directions);

            viewDirection = ll.First;

        }
    }

    static class CircularLinkedList //https://stackoverflow.com/questions/716256/creating-a-circularly-linked-list-in-c
    {
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current)
        {
            return current.Next ?? current.List.First;
        }

        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current)
        {
            return current.Previous ?? current.List.Last;
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}
