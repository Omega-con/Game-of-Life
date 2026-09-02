using System.IO;

public class Read
{
    // Este método se encarga de leer el archivo y convertir
    // su contenido en una matriz de booleanos(que aun me cuesta entender que es eso).
    public bool[,] Load()
    {
        // para decir el nombre del archivo a leer.
        string url = "board.txt";
        // para leer todo el contenido del archivo como un texto.
        string content = File.ReadAllText(url);
        // se separa el texto por saltos de línea para obtener cada fila del tablero por separado.
        string[] contentLines = content.Split('\n');

        // Creamos una matriz de booleanos con la cantidad de filas  y columnas que tiene el archivo.
        bool[,] board = new bool[contentLines.Length, contentLines[0].Length];

        // Recorremos cada fila del archivo.
        for (int y = 0; y < contentLines.Length; y++)
        {
            // Recorremos cada carácter de la fila actual.
            for (int x = 0; x < contentLines[y].Length; x++)
            {
                // Si encontramos un '1', significa que la célula está viva.
                if (contentLines[y][x] == '1')
                {
                    board[x, y] = true;
                }
            }
        }

        // Devolvemos el tablero ya convertido a una matriz de booleanos.
        return board;
    }
}
