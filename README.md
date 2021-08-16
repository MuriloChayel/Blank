# Nome da Aplicação

# Equipe 

# Instalar ou executar a aplicação
## Instalar a Unity
## Como compilar o código de vocês
## Executável
[fulano.exe](http://github.com/MuriloChayel/Blank/bin/fulano.exe)

# Funcionalidades
| Requisitos                    | Descrição                                                                                                                                               | Função ou Classe | Arquivo   | Status   |
|-------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------|------------------|-----------|----------|
| RF0003: Movimentar personagem | Como usuário, posso guiar a personagem por qualquer direção acessível, podendo explorar o cenário para que encontre os itens necessários para progredir | playerBehavior   | player.cs | Completa |
|                               |                                                                                                                                                         | fulano           | fulano.cs |          |
|                               |                                                                                                                                                         |                  |           |          |

# Funcionalidades

<table>
  <tr>
   <td><strong>Requisitos</strong>
   </td>
   <td><strong>Descrição</strong>
   </td>
   <td><strong>Classe</strong>
   </td>
   <td><strong>Arquivos</strong>
   </td>
   <td><strong>Status</strong>
   </td>
  </tr>
  <tr>
   <td>RF001: Movimentar Personagem
   </td>
   <td>Como usuário, posso guiar a personagem por qualquer direção acessível, podendo explorar o cenário para que encontre os itens necessários para progredir.
   </td>
   <td>PlayerBehaviour
   </td>
   <td>PlayerBehaviour.cs
   </td>
   <td>Implementando
   </td>
  </tr>
  <tr>
   <td>RF002: ResolvePuzzles
   </td>
   <td>Essa função seta um número predeterminado de passos que, após concluidos, outros scripts acessam ela para determinar se o jogador passa de nível ou não.
   </td>
   <td>ResolvePuzzles
   </td>
   <td>ResolvePuzzles.cs
   </td>
   <td>Completo
   </td>
  </tr>
  <tr>
   <td>RF003: Levels
   </td>
   <td>Eu posso acessar a função ResolvePuzzles para acessar dados determina o número de passos a serem feitos para em cada instância de seu objeto.
   </td>
   <td>Levels
   </td>
   <td>Levels.cs
   </td>
   <td>Completo
   </td>
  </tr>
  <tr>
   <td>RF004: Narrator
   </td>
   <td>O narrator é uma função responsável por inicializar o AudioSource para que o mesmo toque as faixas de áudio gravadas
   </td>
   <td>Narrator
   </td>
   <td>Narrator.cs
   </td>
   <td>Completo
   </td>
  </tr>
  <tr>
   <td>RF005: CameraBehavior
   </td>
   <td>Camera behaviour controla a câmera do jogo que é fixa
   </td>
   <td>CameraBehavior
   </td>
   <td>CameraBehavior.cs
   </td>
   <td>Implementando
   </td>
  </tr>
  <tr>
   <td>RF006: ItemClass
   </td>
   <td>Essa classe determina a classe dos itens encontrados durante o jogo
   </td>
   <td>ItemClass
   </td>
   <td>ItemClass.cs
   </td>
   <td>Completo
   </td>
  </tr>
  <tr>
   <td>RF007: IconType
   </td>
   <td>Essa função pega associa um ícone no inventário de acordo com a classeTipos de ícones que estão na área do inventário baseado na classe do item (determinada no ItemClass)
   </td>
   <td>IconType
   </td>
   <td>IconType.cs
   </td>
   <td>Completo
   </td>
  </tr>
  <tr>
   <td>RF008: Inventario
   </td>
   <td>Como usuário, posso armazenar itens econtrados em um inventário para serem utilizados para resolver os desafios.
   </td>
   <td>UI_Inventory
   </td>
   <td>InventorySetup.cs e UI Inventory.cs
   </td>
   <td>Completo
   </td>
  </tr>
  <tr>
   <td>RF009: InventorySetup
   </td>
   <td>Essa função adiciona itens na lista de itens do inventário. Define as funções de usar itens.
   </td>
   <td>InventorySetup
   </td>
   <td>InventorySetup.cs
   </td>
   <td>Completo
   </td>
  </tr>
</table>

# Blank
