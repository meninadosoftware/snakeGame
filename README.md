🐍 Snake Game



Este é um jogo Snake simples desenvolvido em C#, jogado no console. A cobra se move pelo campo, comendo a comida que aparece aleatoriamente. Cada vez que a cobra come, ela cresce, e o jogador ganha pontos. O jogo termina se a cobra bater nas paredes ou em si mesma.

📋 Índice

Pré-requisitos

Instalação e Execução

Como Jogar

Tecnologias Utilizadas

Estrutura do Código

Melhorias Futuras

Créditos
Pré-requisitos
.NET SDK: É necessário o .NET SDK instalado na máquina para compilar e executar o jogo. Você pode fazer o download em dotnet.microsoft.com.
Instalação e Execução
Clone o repositório:

Copiar código
git clone https://github.com/meninadosoftware/snakeGame.git
cd  snakeGame
Compile o projeto:

Copiar código
dotnet build
Execute o jogo:

bash
Copiar código
dotnet run
Como Jogar
Setas: Use as setas do teclado para controlar a direção da cobra.

Seta para cima: Move a cobra para cima.
Seta para baixo: Move a cobra para baixo.
Seta para esquerda: Move a cobra para a esquerda.
Seta para direita: Move a cobra para a direita.
Objetivo: O objetivo é comer a comida representada pelo caractere O. Cada vez que a cobra come, ela cresce e sua pontuação aumenta.

Game Over: O jogo termina se a cobra colidir com as bordas da tela ou com o próprio corpo.

Tecnologias Utilizadas
Linguagem: C#
Ambiente: Console
Framework: .NET Core/SDK
Estrutura do Código
Main(): 
Inicializa o jogo e controla o loop principal.
CaptureInput(): 
Monitora as teclas pressionadas para definir a direção da cobra.
Draw():
Desenha o campo de jogo, a cobra e a comida no console.
Update():
Atualiza a posição da cobra e verifica colisões e condições de fim de jogo.
GenerateFood():
Gera a comida em uma posição aleatória, evitando a posição atual da cobra.
Melhorias Futuras
Algumas ideias de melhorias para o jogo:

Ajustar dificuldade: 
Aumente a velocidade da cobra conforme o jogador avança.
Adicione níveis: 
À medida que sua pontuação aumenta, altere o layout ou adicione obstáculos.
Salvar pontuações: 
use um arquivo de texto ou um banco de dados simples para registrar as pontuações mais altas.
Modo multijogador: 
permite que dois jogadores joguem juntos usando controles diferentes.
