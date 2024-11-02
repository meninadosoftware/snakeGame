using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


    class SnakeGame
    {
        static int screenWidth = 40;
        static int screenHeight = 20;
        static List<(int x, int y)> snake = new List<(int, int)> { (20, 10) };
        static (int x, int y) food;
        static int directionX = 1, directionY = 0;
        static int score = 0;
        static Random random = new Random();
        static bool gameOver = false;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(screenWidth, screenHeight);
            GenerateFood();

            // Thread para capturar a entrada de teclado
            Thread inputThread = new Thread(CaptureInput);
            inputThread.Start();

            // Loop principal do jogo
            while (!gameOver)
            {
                Draw();
                Update();
                Thread.Sleep(200); // Velocidade da cobra
            }

            Console.Clear();
            Console.WriteLine("Game Over! Pontuação: " + score);
            Console.ReadKey();
        }

        // Método que captura a entrada do usuário em um thread separado
        static void CaptureInput()
        {
            while (!gameOver)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            if (directionY != 1) // Impede a mudança direta para a direção oposta
                            {
                                directionX = 0;
                                directionY = -1;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (directionY != -1)
                            {
                                directionX = 0;
                                directionY = 1;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (directionX != 1)
                            {
                                directionX = -1;
                                directionY = 0;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (directionX != -1)
                            {
                                directionX = 1;
                                directionY = 0;
                            }
                            break;
                    }
                }
                Thread.Sleep(20); // Pequena pausa para evitar uso excessivo de CPU
            }
        }

        // Desenha o campo, cobra e comida
        static void Draw()
        {
            Console.Clear();

            // Desenha as bordas
            for (int x = 0; x < screenWidth; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("#");
                Console.SetCursorPosition(x, screenHeight - 1);
                Console.Write("#");
            }
            for (int y = 0; y < screenHeight; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("#");
                Console.SetCursorPosition(screenWidth - 1, y);
                Console.Write("#");
            }

            // Desenha a comida
            Console.SetCursorPosition(food.x, food.y);
            Console.Write("O");

            // Desenha a cobra
            foreach (var part in snake)
            {
                Console.SetCursorPosition(part.x, part.y);
                Console.Write("&");
            }

            // Exibe a pontuação
            Console.SetCursorPosition(0, screenHeight - 1);
            Console.Write("Pontuação: " + score);
        }

        // Atualiza o estado do jogo
        static void Update()
        {
            // Calcula a nova posição da cabeça da cobra
            var head = (x: snake.First().x + directionX, y: snake.First().y + directionY);

            // Verifica colisões com a borda ou com o corpo da cobra
            if (head.x <= 0 || head.x >= screenWidth - 1 || head.y <= 0 || head.y >= screenHeight - 1 || snake.Contains(head))
            {
                gameOver = true;
                return;
            }

            // Adiciona a nova cabeça na frente da cobra
            snake.Insert(0, head);

            // Verifica se a cobra comeu a comida
            if (head == food)
            {
                score++;
                GenerateFood(); // Gera nova comida em outra posição
            }
            else
            {
                // Remove o último segmento da cobra para simular o movimento
                snake.RemoveAt(snake.Count - 1);
            }
        }

        // Gera uma nova posição para a comida
        static void GenerateFood()
        {
            food = (random.Next(1, screenWidth - 2), random.Next(1, screenHeight - 2));
            while (snake.Contains(food))
            {
                food = (random.Next(1, screenWidth - 2), random.Next(1, screenHeight - 2));
            }
        }
    }

