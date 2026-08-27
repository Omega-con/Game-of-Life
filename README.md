<!-- markdownlint-disable MD033 -->
<!-- markdownlint-disable-next-line MD033 MD041 -->
<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>

# Universidad Católica del Uruguay

## Programación II

# Conway's Game of Life

## Contexto

[John Conway](https://en.wikipedia.org/wiki/John_Horton_Conway) fue un
matemático inglés muy conocido por sus aportes matemáticos en diversas áreas,
pero lo que realmente lo hizo famoso fue su creación lúdica: [juego de la
vida](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life).

![Game of life
animation](https://upload.wikimedia.org/wikipedia/commons/e/e5/Gospers_glider_gun.gif)

El juego de la vida consiste en un autómata celular con unas pocas reglas muy
simples. El universo es una grilla ortogonal de dos dimensiones, donde cada
espacio de la grilla representa una única célula. Cada célula puede estar viva o
muerta. Cada una de estas células tendrá 8 vecinos. En cada iteración del tiempo
(generación) una célula estará viva o muerta según la cantidad de vecinos vivos
o muertos que tenga. Siguiendo estas reglas:

* Una célula viva con menos de 2 vecinos vivos muere, por soledad.
* Una célula viva con 2 o 3 vecinos vivos sobrevive a la siguiente generación.
* Una célula viva con más de 3 vecinos vivos muere, por sobrepoblación.
* Una célula muerta con exactamente 3 vecinos vivos se convierte en una célula
  viva, por reproducción

## Objetivo

Como tributo a Conway ¡hoy vamos a crear este juego en consola! Para ello te
vamos a proveer de varios code
[snippets](https://en.wikipedia.org/wiki/Snippet_(programming)) y será tu
trabajo asignarlos a la clase correcta cumpliendo con Expert y SRP.

Tómate tu tiempo para entender que hace cada *code snippet*. Cada uno de ellos
implementa una responsabilidad, tu desafío es definir qué clase es la que debe
tener esa responsabilidad, usando las guías Expert y SRP para ello.

El objetivo será desarrollar este juego mediante objetos diferentes, cada uno
con una sola razón de cambio. El tablero deberá ser cargado a partir de un
archivo de texto —como [este](/assets/board.txt)— y luego el avance del juego
deberá ser impreso en pantalla mediante consola.

> [!TIP]
> Debes tener en cuenta que hoy se pide que el juego se lea desde un archivo y
> se imprima en consola, pero mañana podremos pedirles que se lea de una fuente
> diferente y se muestre en pantalla por otro medio :wink:

<br>

> [!IMPORTANT]
> Recuerda agregar comentarios a todas tus clases justificando tus decisiones de
> diseño, es decir, por qué crees que si cumplen o no con SRP y Expert.

Si todo ha funcionado correctamente, tu resultado debería verse algo similar a
esto:

![GoL](./assets/console-gif-GoL.gif)

## *Code snippets*

A continuación se presentan fragmentos de código suelto —*snippets*— que podrás
reutilizar en tu solución.

> [!WARNING]
> Estos fragmentos de código son genéricos y no funcionaran simplemente haciendo
> copy/paste. Si bien la estructura general y la mayoría del código no debería
> ser necesario modificarlo, deberán ser adaptados a tu solución propuesta.

### Lógica de juego

El siguiente *code snippet* contiene la lógica necesaria para procesar una
generación del juego.

Se asume:

* Que el tablero es un vector —*array*— de 2 dimensiones de booleanos, donde
  `true` indica una célula viva y `false` indica una célula muerta. Este
  vector de dos dimensiones es en realidad una matriz, donde una dimensión son
  las filas, y la otra dimensión son las columnas.
* El objeto `gameBoard` contiene uun vector —*array*— ya cargado con todos
  los valores asignados.

```csharp
bool[,] gameBoard = /* contenido del tablero */;
int boardWidth = gameBoard.GetLength(0);
int boardHeight = gameBoard.GetLength(1);

bool[,] cloneboard = new bool[boardWidth, boardHeight];
for (int x = 0; x < boardWidth; x++)
{
    for (int y = 0; y < boardHeight; y++)
    {
        int aliveNeighbors = 0;
        for (int i = x-1; i<=x+1;i++)
        {
            for (int j = y-1;j<=y+1;j++)
            {
                if(i>=0 && i<boardWidth && j>=0 && j < boardHeight && gameBoard[i,j])
                {
                    aliveNeighbors++;
                }
            }
        }
        if(gameBoard[x,y])
        {
            aliveNeighbors--;
        }
        if (gameBoard[x,y] && aliveNeighbors < 2)
        {
            // Célula muere por baja población
            cloneboard[x,y] = false;
        }
        else if (gameBoard[x,y] && aliveNeighbors > 3)
        {
            // Célula muere por sobrepoblación
            cloneboard[x,y] = false;
        }
        else if (!gameBoard[x,y] && aliveNeighbors == 3)
        {
            // Célula nace por reproducción
            cloneboard[x,y] = true;
        }
        else
        {
            // Célula mantiene el estado que tenía
            cloneboard[x,y] = gameBoard[x,y];
        }
    }
}
gameBoard = cloneboard;
```

> `bool[,]` es la declaración de un vector -array- multidimensional. Puedes
> ver
> [aquí](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays)
> más información.

### Leer Archivo

Este *snippet* muestra como leer un archivo y crear una matriz de booleanos
(`bool[,]`) con el contenido —un vector o *array* bi-dimensional—. Se asume
que cada linea del archivo corresponde a una fila de la matriz y cada carácter
de la fila corresponde a un elemento de la fila correspondiente de la matriz.
También se asume que el archivo contiene solamente los caracteres `1` y
`0` correspondientes a `true` y `false` respectivamente y que todas
las filas son de igual largo.

Por ejemplo, el siguiente archivo de texto:

```none
100
011
110
```

se convierte en la siguiente matriz:

```csharp
bool[3,3] {
    {true, false, false},
    {false, true, true},
    {true, true, false}
};
```

> Esta forma incluso tiene nombre y se llama glider
>
> ![Glider](https://upload.wikimedia.org/wikipedia/commons/f/f2/Game_of_life_animated_glider.gif)

*Snippet* de código:

```csharp
string url = "ruta del archivo";
string content = File.ReadAllText(url);
string[] contentLines = content.Split('\n');
bool[,] board = new bool[contentLines.Length, contentLines[0].Length];
for (int  y=0; y<contentLines.Length;y++)
{
    for (int x=0; x<contentLines[y].Length; x++)
    {
        if(contentLines[y][x]=='1')
        {
            board[x,y]=true;
        }
    }
}
```

> La clase `File` está definida en el espacio de nombres `System.IO`.
> Debes incluirlo utilizando una cláusula `using`.

<br>

> [!TIP]
> Este proyecto está configurado para copiar el archivo `board.txt` al
> directorio desde donde se ejecutará tu programa cuando lo depures o lo
> ejecutes desde Rider. Por eso no es necesario indicar la ruta cuando quieras
> abrir el archivo, usa solamente el nombre.

### Imprimir tablero

Aquí se muestra como imprimir un tablero por consola. Observa que este código
requiere invocar el *snippet* de la lógica de juego

```csharp
bool[,] b // Variable que representa el tablero
int width // Variable que representa el ancho del tablero
int height // Variable que representa altura del tablero
while (true)
{
    Console.Clear();
    StringBuilder s = new StringBuilder();
    for (int y = 0; y<height;y++)
    {
        for (int x = 0; x<width; x++)
        {
            if(b[x,y])
            {
                s.Append("|X|");
            }
            else
            {
                s.Append("___");
            }
        }
        s.Append("\n");
    }
    Console.WriteLine(s.ToString());
    //=================================================
    //Invocar método para calcular siguiente generación
    //=================================================
    Thread.Sleep(300);
}
```

> La clase ```StringBuilder``` está definida en el espacio de nombres
> ```System.Text```. Debes incluirlo utilizando una cláusula ```using```.

## Rúbrica corrección

La corrección de este ejercicio la harán los profesores usando la siguiente
rúbrica:

# Rúbrica de evaluación – Conway's Game of Life (POO)

<!-- markdownlint-ignore MD058 -->
| Criterio | Experto | En desarrollo | Incipiente | Insuficiente |
| --- | --- | --- | --- | --- |
| **Correctitud funcional** (lee archivo, simula generaciones, imprime) | Cumple todo correctamente y de forma consistente. | Cumple casi todo; fallos menores. | Funciona parcialmente o con errores frecuentes. | No funciona o no compila. |
| **Distribución de responsabilidades (SRP + Expert)** | Clases con responsabilidades claras, una sola razón de cambio; se evidencia Expert. | Algunas responsabilidades bien distribuidas, otras no. | Distribución confusa o acoplada. | No hay diseño por responsabilidades. |
| **Aplicación de GRASP/SOLID pertinentes** | Aplica SRP/Expert explícitamente y los justifica. | Aplica algunos criterios pero sin consistencia o explicación parcial. | Aplicación débil o poco justificada. | No aplica ni justifica. |
| **Diseño orientado a objetos (colaboraciones y modelo)** | Clases y colaboraciones coherentes con el dominio. | Diseño razonable con algunas inconsistencias. | Diseño pobre; falta claridad en relaciones. | Diseño inexistente o incorrecto. |
| **Comentarios de justificación** | Todas las clases justificadas con claridad. | La mayoría justificadas de forma aceptable. | Pocas justificaciones o poco claras. | Sin justificaciones o incorrectas. |
| **Calidad y convenciones C#** | Nombres, formato y estilo consistentes. | Algunos desvíos menores. | Múltiples problemas de estilo. | Estilo y convenciones ignoradas. |
| **Mantenibilidad** | Cambios futuros serían simples y localizados. | Mantenible con esfuerzo moderado. | Difícil de mantener. | Muy difícil de modificar sin efectos colaterales. |

Otorga puntos según las siguientes reglas:

* Si todos los criterios son "Experto", 100 puntos.

* Si todos los criterios son "Insuficiente", 30 puntos.

* Si la mayoría de los criterios son "En desarrollo", 75 puntos.

* Si la mayoría de los criterios son "Incipiente", 60 puntos.

* En los demás casos, asigna puntos ponderando las reglas anteriores.

## Uso de ![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-000?logo=githubcopilot&logoColor=fff)

Es posible usar GitHub Copilot en este repositorio. Consulta [cómo usar Copilot
para aprender](./COPILOT.md).
