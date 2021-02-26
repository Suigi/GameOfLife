using System.Collections.Generic;

namespace GameOfLife
{
    public class IndexMechanics
    {
        private readonly int rows;
        private readonly int columns;

        public IndexMechanics(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        private static int WrapIndex(int value, int upperBound)
        {
            if (value >= upperBound)
            {
                return 0;
            }

            if (value <= 0)
            {
                return upperBound - 1;
            }

            return value;
        }

        private int WrapRow(int row)
        {
            return WrapIndex(row, rows);
        }
        
        private int WrapColumn(int column)
        {
            return WrapIndex(column, columns);
        }
        
        public IEnumerable<(int row,int column)> Neighbors((int row, int column) valueTuple)
        {
            yield return (WrapRow(valueTuple.row - 1), WrapColumn(valueTuple.column - 1));
            yield return (WrapRow(valueTuple.row - 1), valueTuple.column);
            yield return (WrapRow(valueTuple.row - 1), WrapColumn(valueTuple.column + 1));
            yield return (valueTuple.row, WrapColumn(valueTuple.column - 1));
            yield return (valueTuple.row, WrapColumn(valueTuple.column + 1));
            yield return (WrapRow(valueTuple.row + 1), WrapColumn(valueTuple.column - 1));
            yield return (WrapRow(valueTuple.row + 1), valueTuple.column);
            yield return (WrapRow(valueTuple.row + 1), WrapColumn(valueTuple.column + 1));
        }
    }
}