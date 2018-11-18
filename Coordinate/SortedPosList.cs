using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinate
{
    class SortedPosList
    {
        private List<Position> positions;

        public SortedPosList() => this.positions = new List<Position>();

        public int Count() => positions.Count;

        public void Add(Position p)
        {
            for (int i = 0; i < Count(); i++)
            {
                if (p < positions[i])
                {
                    positions.Insert(i, p);
                    return;
                }
            }

            positions.Add(p);
        }

        public bool Remove(Position pos)
        {
            bool removed = false;

            for (int i = 0; i < Count(); i++)
            {
                if (positions[i].Equals(pos))
                {
                    positions.RemoveAt(i);
                    removed = true;
                }
            }

            return removed;
        }

        public SortedPosList Clone()
        {
            SortedPosList clone = new SortedPosList();
            foreach (Position pos in positions)
            {
                Position cPos = pos.Clone();
                clone.Add(cPos);
            }
            return clone;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList insideCircleList = new SortedPosList();
            foreach (Position pos in positions)
            {
                // (Math.Pow(pos.X - centerPos.X, 2) + Math.Pow(pos.Y - centerPos.Y, 2) < Math.Pow(radius, 2))
                if (pos % centerPos <= radius)
                    insideCircleList.Add(pos);
            }
            return insideCircleList;
        }

        public static SortedPosList operator + (SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList sum = new SortedPosList();
            foreach (Position pos in sp1.positions)
                sum.Add(pos);
            foreach (Position pos in sp2.positions)
                sum.Add(pos);
            return sum;
        }
        
        public override string ToString() => String.Join(", ", positions);            }
}
