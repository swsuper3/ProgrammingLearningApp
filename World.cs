﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    /// <summary>
    /// World is class that handles the obstacle-player interaction.
    /// It is responsible for moving the player since it knows where and how the player can move.
    /// </summary>
    public class World : ISubject<Character>
    {
        Character character;
        public Character Character { get { return character; } }
        Dictionary<Point, ObstacleType> obstacles;

        public Dictionary<Point, ObstacleType> Obstacles { get { return obstacles; } }

        private List<IMyObserver<Character>> observers = new List<IMyObserver<Character>>();

        public World(Character character, Dictionary<Point, ObstacleType> obstacles)
        {
            this.character = character;
            this.obstacles = obstacles;
        }

        public World(Character character) : this(character, new Dictionary<Point, ObstacleType>()) { }

        public World() : this(new Character()) { }

        /// <summary>
        /// This method moves the character a specific amount in the direction the character is currently facing.
        /// </summary>
        /// <param name="amount"></param>
        public void MovePlayer(int amount)
        {
            TryMove(amount, out Point destination, out Condition condition);
            character.SetPosition(new Point(destination.x, destination.y));

            Notify();
        }


        /// <summary>
        /// This method attempts to move the character for a specified amount and returns whether it succeeded, while also returning the Point where the character would have stopped.
        /// </summary>
        public void TryMove (int amount, out Point destination, out Condition occurredCondition)
        {
            destination = new Point(character.Position.x, character.Position.y);
            Point prevDestination = new Point();
            occurredCondition = Condition.None;

            for (int i = 0; i < amount; i++)
            {
                prevDestination = destination;

                switch (character.ViewDirection)
                {
                    case Direction.North:
                        destination.y -= 1;
                        break;
                    case Direction.East:
                        destination.x += 1;
                        break;
                    case Direction.South:
                        destination.y += 1;
                        break;
                    case Direction.West:
                        destination.x -= 1;
                        break;
                }

                // This conditional checked whether the destination is blocked by an obstacle.
                // If so, the character would not move further, and the destination is set back by one, since otherwise the character would be in an obstacle.
                if (obstacles.ContainsKey(destination))
                {
                    if (obstacles[destination] == ObstacleType.Wall)
                        occurredCondition = Condition.WallAhead;
                    else
                        occurredCondition = Condition.GridEdge;

                    destination = prevDestination;
                    break;
                }
            }
        }

        public void TurnPlayer(LeftRight leftRight)
        {
            character.Turn(leftRight);
        }

        public void AddObstacle(Point p, ObstacleType type)
        {
            obstacles.Add(p, type);
        }

        public void SetBounds(int gridWidth, int gridHeight)
        {
            for(int i = 0; i < gridWidth; i++)
            {
                obstacles.Add(new Point(i, -1), ObstacleType.GridEdge);
                obstacles.Add(new Point(i, gridHeight), ObstacleType.GridEdge);
            }

            for(int i = 0; i < gridHeight; i++)
            {
                obstacles.Add(new Point(-1, i), ObstacleType.GridEdge);
                obstacles.Add(new Point(gridWidth, i), ObstacleType.GridEdge);

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
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public void Notify()
        {
            foreach (IMyObserver<Character> observer in observers)
            {
                observer.Update(this.character);
            }
        }
    }

    public enum ObstacleType
    {
        Wall,
        GridEdge
    }
}
