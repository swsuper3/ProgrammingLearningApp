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
        public Point Position { get { return position; } }

        LinkedListNode<Direction> viewDirection;
        Point position;

        public Character()
        {
            Direction[] directions = (Direction[]) Enum.GetValues(typeof(Direction));

            LinkedList<Direction> ll = new LinkedList<Direction>(directions);

            viewDirection = ll.First.NextOrFirst();

            this.position = new Point();
        }

        /// <summary>
        /// This method moves the character a specific amount in the direction the character is currently facing.
        /// </summary>
        /// <param name="amount"></param>
        public void Move(int amount)
        {
            switch (ViewDirection)
            {
                case Direction.North:
                    position.y -= amount;
                    break;
                case Direction.East:
                    position.x += amount;
                    break;
                case Direction.South:
                    position.y += amount;
                    break;
                case Direction.West:
                    position.x -= amount;
                    break;
            }
        }

        /// <summary>
        /// This method turns the character to the left or right (changing the viewDirection), depending on the parameter.
        /// </summary>
        /// <param name="turnDirection"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Turn(LeftRight turnDirection)
        {
            if (turnDirection == LeftRight.Left)
            {
                viewDirection = viewDirection.PreviousOrLast();
            }
            else if (turnDirection == LeftRight.Right)
            {
                viewDirection = viewDirection.NextOrFirst();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid turnDirection");
            }
        }
    }

    /// <summary>
    /// These methods contain circular logic, so that turning the character is circular as well.
    /// If there is no next node, it takes the first. If there is no previous node, it takes the last.
    /// </summary>
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

    public struct Point
    {
        public int x;
        public int y;

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(int x, int y)
        {
            this.x = y;
            this.y = y;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }
}
