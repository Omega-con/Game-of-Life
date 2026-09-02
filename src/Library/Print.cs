using System;
using System.Text;
public class Print
{
    // Recibe un tablero y lo muestra en la consola.
    public void Show(bool[,] board)
    {
        // Limpiamos la consola para que solamente se vea
        // la generación actual.
        Console.Clear();

        // Obtenemos las dimensiones del tablero.
        int width = board.GetLength(0);
        int height = board.GetLength(1);

        // Creamos un StringBuilder para construir todo el tablero
        // antes de mostrarlo en la consola.
        StringBuilder s = new StringBuilder();

        // Recorremos cada fila del tablero.
        for (int y = 0; y < height; y++)
        {
            // Recorremos cada columna de la fila actual.
            for (int x = 0; x < width; x++)
            {
                // Si la célula está viva, mostramos una X.
                if (board[x, y])
                {
                    s.Append("|X|");
                }
                else
                {
                    // Si está muerta, mostramos un espacio vacío.
                    s.Append("___");
                }
            }

            // Pasamos a la siguiente fila.
            s.Append("\n");
        }

        // Mostramos el tablero completo en la consola.
        Console.WriteLine(s.ToString());
    }
}
