# Hexagonal Match 3 Line Drawer - Unity
Made with Unity 2018.4.0f1

## Instructions:
```
-> Open Scene MainScene.unity inside Scenes Folder.
-> Press Play

```

## Calibrationn:
```
-> Open gameManagaer.cs inside Scripts Folder.
-> Inside Awake function 
-> Example:
   void Awake()
   {
       //Init Value
       padding=112f;
       cellSize = 128f;
       cellsOdd = 7;
       cellsEven = 6;
       cols = 7;
       moves=10;
   }
-> Change these parameters for following effect
   padding - Changes Horizaontal padding of the field
   cellSize - Changes the size of individual cell
   cellsOdd - No of cells in odd column
   cellsEven - No of cells in even column
   cols - No of columns
   moves - Total no of moves allowed before gameover

```

## Features:
```
- Gamefield with hexagonal cells
- Randomly generated
- Any number of different block colors
- Adjacent blocks can be selected if they have the same color
- Blocks can be removed if at least 3 were selected, blocks above will “fall down”, when some upmost field is empty a random block will be generated.
- Highlights will be cleared when drawing backwards
- Mouse controls
- Scoring system (+ Basic UI)
- Game ends after x moves
- Basic combo system

```
## About:

The game field consisting of hexagonal cells. The player needs to connect adjacent
blocks which belong to the same type in order to get points and remove them. Therefore, the player
needs to draw a connected line which can contain each block only once. After the player selected at
least 3 blocks and releases the mouse button, the selected blocks will be destroyed, and all other
fields slide column by column downwards to fill up the empty regions. The upper ones which then
stay empty will be filled up with random blocks. Depending on the amount of destroy blocks, the
player gets different amount of points. After a predefined amount of moves the game is over.

