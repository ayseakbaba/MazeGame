using MazeGame.Enums;
using MazeGame.Interpreter.Expressions;

namespace MazeGame.Interpreter
{
    public static class BlockParser
    {
        public static List<IExpression> Parse(List<string> blockCodes)
        {
            var list = new List<IExpression>();

            foreach (var code in blockCodes)
            {
                switch (code.Trim().ToLowerInvariant())
                {
                    case "sağ":
                        list.Add(new MoveRightExpression(Direction.Right));
                        break;
                    case "sol":
                        list.Add(new MoveLeftExpression(Direction.Left));
                        break;
                    case "yukarı":
                        list.Add(new MoveUpExpression(Direction.Up));
                        break;
                    case "aşağı":
                        list.Add(new MoveDownExpression(Direction.Down));
                        break;

                    // Eski move komutu (Facing'e göre gider)
                    case "ilerle":
                        list.Add(new MoveRightExpression(Direction.Right)); // İstersen default facing'e göre
                        break;
                }
            }

            return list;
        }
    }

}
