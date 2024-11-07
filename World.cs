using System;
using System.Collections.Generic;
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
        HashSet<Point> obstacles;

        private List<IMyObserver<Character>> observers = new List<IMyObserver<Character>>();

        public World(Character character, HashSet<Point> obstacles)
        {
            this.character = character;
            this.obstacles = obstacles;
        }

        public World(Character character) : this(character, new HashSet<Point>()) { }

        public World() : this(new Character()) { }

        /// <summary>
        /// This method moves the character a specific amount in the direction the character is currently facing.
        /// </summary>
        /// <param name="amount"></param>
        public void MovePlayer(int amount)
        {
            if (TryMove(amount, out Point destination) || true)
                character.SetPosition(new Point(destination.x, destination.y));

            Notify();
        }


        /// <summary>
        /// This method attempts to move the character for a specified amount and returns whether it succeeded, while also returning the Point where the character would have stopped.
        /// </summary>
        public bool TryMove (int amount, out Point destination)
        {
            destination = new Point();
            for (int i = 0; i < amount; i++)
            {
                switch (character.ViewDirection)
                {
                    case Direction.North:
                        destination = new Point(character.Position.x, character.Position.y - 1);
                        break;
                    case Direction.East:
                        destination = new Point(character.Position.x + 1, character.Position.y);
                        break;
                    case Direction.South:
                        destination = new Point(character.Position.x, character.Position.y + 1);
                        break;
                    case Direction.West:
                        destination = new Point(character.Position.x - 1, character.Position.y);
                        break;
                }

                if (!obstacles.Contains(destination))
                    return false;
            }

            return true;
        }

        public void TurnPlayer(LeftRight leftRight)
        {
            character.Turn(leftRight);
        }

        public void AddObstacle(Point p)
        {
            obstacles.Add(p);
        }

        public void SetBounds(int gridWidth, int gridHeight)
        {
            for(int i = 0; i < gridWidth; i++)
            {
                obstacles.Add(new Point(i, -1));
                obstacles.Add(new Point(-1, i));
                obstacles.Add(new Point(i, gridHeight));
                obstacles.Add(new Point(gridWidth, i));
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
}
