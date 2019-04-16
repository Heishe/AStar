using System;
using UnityEngine;

namespace RoyT.AStar
{
    /// <summary>
    /// A 2D position structure
    /// </summary>
    public struct Position : IEquatable<Position>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">the x-position</param>
        /// <param name="y">the y-position</param>
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// X-position
        /// </summary>
        public int x { get; }

        /// <summary>
        /// Y-position
        /// </summary>
        public int y { get; }

        public override string ToString() => $"Position: ({this.x}, {this.y})";

        public static explicit operator Position(Vector2Int v)  
        {
            Position p = new Position(v.x,v.y); 

            return p;
        }

        public bool Equals(Position other)
        {
            return this.x == other.x && this.y == other.y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            return obj is Position && Equals((Position) obj);
        }
        
        public static bool operator ==(Position a, Position b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Position a, Position b)
        {
            return !a.Equals(b);
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.x + b.x, a.y + b.y);
        }

        public static Position operator -(Position a, Position b)
        {
            return new Position(a.x - b.x, a.y - b.y);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.x * 397) ^ this.y;
            }
        }
    }
}
