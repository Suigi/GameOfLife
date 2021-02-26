using System.Text;

namespace GameOfLife
{
    public class GamePrinter
    {
        public string Print(Game game)
        {
            var builder = new StringBuilder();

            for (int row = 0; row < game.Rows; row++)
            {
                for (int column = 0; column < game.Columns; column++)
                {
                    if (game.IsCellAlive(row, column))
                    {
                        builder.Append('x');
                    }
                    else
                    {
                        builder.Append("_");
                    }
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}