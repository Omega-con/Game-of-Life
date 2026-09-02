public class Logic
{
    // Guarda el estado actual del tablero.
    private bool[,] board;

    // Recibe el tablero inicial y lo guarda para poder trabajar con él.
    public Logic(bool[,] board)
    {
        this.board = board;
    }

    // Calcula y guarda lo que generara despues el tablero.
    public void NextGeneration()
    {
        // Obtenemos la cantidad de columnas y filas del tablero.
        int boardWidth = board.GetLength(0);
        int boardHeight = board.GetLength(1);

        // Creamos un tablero nuevo donde guardaremos los resultados.
        // Esto evita modificar el tablero actual mientras lo estamos recorriendo.
        bool[,] cloneboard = new bool[boardWidth, boardHeight];

        // Recorremos todas las posiciones del tablero.
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                // Contará cuántos vecinos vivos tiene la célula actual.
                int aliveNeighbors = 0;

                // Recorremos las posiciones que rodean a la célula actual.
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        // Comprobamos que la posición esté dentro del tablero
                        // y que la célula encontrada esté viva.
                        if (i >= 0 && i < boardWidth &&
                            j >= 0 && j < boardHeight &&
                            board[i, j])
                        {
                            aliveNeighbors++;
                        }
                    }
                }

                // La propia célula se contó como vecina si estaba viva,
                // por lo que la quitamos del contador.
                if (board[x, y])
                {
                    aliveNeighbors--;
                }

                // Una célula viva con menos de 2 vecinos muere.
                if (board[x, y] && aliveNeighbors < 2)
                {
                    cloneboard[x, y] = false;
                }

                // Una célula viva con más de 3 vecinos muere.
                else if (board[x, y] && aliveNeighbors > 3)
                {
                    cloneboard[x, y] = false;
                }

                // Una célula muerta con exactamente 3 vecinos vivos nace.
                else if (!board[x, y] && aliveNeighbors == 3)
                {
                    cloneboard[x, y] = true;
                }

                // En cualquier otro caso, mantiene su estado actual.
                else
                {
                    cloneboard[x, y] = board[x, y];
                }
            }
        }

        // Reemplazamos el tablero actual por la nueva generación.
        board = cloneboard;
    }
}
