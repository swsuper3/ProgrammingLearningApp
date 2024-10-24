using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class Character : ISubject<Character>
    {
        public Direction ViewDirection { get => viewDirection.Value; }
        public Point Position { get => position; }

        LinkedListNode<Direction> viewDirection;
        Point position;

        private List<IMyObserver<Character>> observers = new List<IMyObserver<Character>>();

        HashSet<Point> obstacles;

        public Character()
        {
            Direction[] directions = (Direction[]) Enum.GetValues(typeof(Direction));

            LinkedList<Direction> ll = new LinkedList<Direction>(directions);

            viewDirection = ll.First.NextOrFirst();

            this.position = new Point();

            obstacles = new HashSet<Point>();
        }

        public Character(HashSet<Point> obstacles) : this()
        {
            this.obstacles = obstacles;
        }

        /// <summary>
        /// This method moves the character a specific amount in the direction the character is currently facing.
        /// </summary>
        /// <param name="amount"></param>
        public void Move(int amount)
        {
            Point destination = new Point();
            for (int i = 0; i < amount; i++) {
                switch (ViewDirection)
                {
                    case Direction.North:
                        destination = new Point(position.x, position.y-1);
                        break;
                    case Direction.East:
                        destination = new Point(position.x+1, position.y);
                        break;
                    case Direction.South:
                        destination = new Point(position.x, position.y+1);
                        break;
                    case Direction.West:
                        destination = new Point(position.x-1, position.y);
                        break;
                }

                if(!obstacles.Contains(destination))
                {
                    position = new Point(destination.x, destination.y);
                }
            }

            Notify();
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

        public void Turn(LeftRight turnDirection, int amountOfTurns)
        {
            for(int i = 0; i < amountOfTurns; i++)
            {
                Turn(turnDirection);
            }
        }

        public void Attach(IMyObserver<Character> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void Detach(IMyObserver<Character> observer)
        {
            if(observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public void Notify()
        {
            foreach(IMyObserver<Character> observer in observers)
            {
                observer.Update(this);
            }
        }
    }

    /// <summary>
    /// These methods contain circular logic, so that turning the character is circular as well.
    /// If there is no next node, it takes the first. If there is no previous node, it takes the last.
    /// 
    /// Methods from: https://stackoverflow.com/questions/716256/creating-a-circularly-linked-list-in-c
    /// </summary>
    static class CircularLinkedList
    {
        /// <summary>
        /// If there is no next node, it takes the first.
        /// </summary>
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current)
        {
            return current.Next ?? current.List.First;
        }

        /// <summary>
        /// If there is no previous node, it takes the last.
        /// </summary>
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
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }
}
