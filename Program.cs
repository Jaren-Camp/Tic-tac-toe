// See https://aka.ms/new-console-template for more information
// Jaren Camp CS1400 Final Project "Tic-Tac-Toe" 7/29/22
using System.Diagnostics;

//Metod checks each row array and column array, as well as the diagonal to see if there is three in a row
bool gameWon(ref char[][] grid)
{
    //The method goes to each of the 8 ways to win and checks them if they are full of x's or o's. It then displays that the letter in the first coordinate possiton of the winning line wins.
    if ((grid[0][0] == 'x' && grid[1][0] == 'x' && grid[2][0] == 'x') || (grid[0][0] == 'o' && grid[1][0] == 'o' && grid[2][0] == 'o'))
    {
        Console.WriteLine(grid[0][0] + " wins");
        return true;
    }
    if ((grid[0][1] == 'x' && grid[1][1] == 'x' && grid[2][1] == 'x') || (grid[0][1] == 'o' && grid[1][1] == 'o' && grid[2][1] == 'o'))
    {
        Console.WriteLine(grid[0][1] + " wins");
        return true;
    }
    if ((grid[0][2] == 'x' && grid[1][2] == 'x' && grid[2][2] == 'x') || (grid[0][2] == 'o' && grid[1][2] == 'o' && grid[2][2] == 'o'))
    {
        Console.WriteLine(grid[0][2] + " wins");
        return true;
    }
    if ((grid[0][0] == 'x' && grid[0][1] == 'x' && grid[0][2] == 'x') || (grid[0][0] == 'o' && grid[0][1] == 'o' && grid[0][2] == 'o'))
    {
        Console.WriteLine(grid[0][0] + " wins");
        return true;
    }
    if ((grid[1][0] == 'x' && grid[1][1] == 'x' && grid[1][2] == 'x') || (grid[1][0] == 'o' && grid[1][1] == 'o' && grid[1][2] == 'o'))
    {
        Console.WriteLine(grid[1][0] + " wins");
        return true;
    }
    if ((grid[2][0] == 'x' && grid[2][1] == 'x' && grid[2][2] == 'x') || (grid[2][0] == 'o' && grid[2][1] == 'o' && grid[2][2] == 'o'))
    {
        Console.WriteLine(grid[2][0] + " wins");
        return true;
    }
    if ((grid[0][0] == 'x' && grid[1][1] == 'x' && grid[2][2] == 'x') || (grid[0][0] == 'o' && grid[1][1] == 'o' && grid[2][2] == 'o'))
    {
        Console.WriteLine(grid[0][0] + " wins");
        return true;
    }
    if ((grid[2][0] == 'x' && grid[1][1] == 'x' && grid[0][2] == 'x')|| (grid[2][0] == 'o' && grid[1][1] == 'o' && grid[0][2] == 'o'))
    {
        Console.WriteLine(grid[2][0] + " wins");
        return true;
    }
    //This for loop makes sure that the game continues to play if the game has not been won and their are still places to be filled
    // it then displays that the game ended in a draw if no one won and if all the places are filled
    for(int i = 0; i < 3; i ++)
    {

        for(int j = 0; j < 3; j ++)
        {
            if(grid[i][j] != 'x' && grid[i][j] != 'o')
            {
                return false;
            }
        }
    }
    Console.WriteLine("It's a draw");
    return true;
}

// this method prints out a grid
//pass grid by reference
void printGrid(ref char[][] grid)
{
    Console.Clear();
    for(int i = 0; i < 3; i ++)
    {
        Console.WriteLine(grid[i][0] + "|" + grid[i][1] + "|" + grid[i][2]);
        if(i != 2)
        {
            Console.WriteLine("-----");
        }
    }
}

//this is a test code to make sure that the gameWon method is working
char[][] testOne = 
{
    // 5. jagged array used to make a grid
    new char[] {'x', 'x', 'x' },
    new char[] { 'x', 'o', 'o' },
    new char[] { 'o', 'x', 'o' }
};

printGrid(testOne);

//test for gameWon method
Debug.Assert(gameWon(testOne));
testOne[0][0] = 'o';
testOne[0][1] = ' ';
printGrid(testOne);
Debug.Assert(gameWon(testOne));
testOne[2][2] = ' ';
printGrid(testOne);
Debug.Assert(!gameWon(testOne));
testOne[0][1] = 'o';
testOne[2][2] = 'x';
printGrid(testOne);
Debug.Assert(gameWon(testOne));

//this method makes the getMove method cleaner, by allowing me to have the one big if statement in this method to make the if statements in the getMove method smaller.
bool placemove(ref char[][] grid, char token, int row, int col)
{
    //if/else statement to check if the coordiante place on the grid has been taken, if so can't place an 'x' or 'o' there else you can place one in that coordinate
  if(grid[row][col] == 'x' || grid[row][col] == 'o')
        {
            Console.WriteLine("Place taken. Please choose another number.");
            return false;
        }
        else
        {
            grid[row][col] = token;
            return true;
        }
}

//This second grid is so I can test the placemove method
char[][] testTwo = 
{
    new char[] {'x', 'x', 'x' },
    new char[] { 'x', 'o', 'o' },
    new char[] { 'o', 'x', 'o' }
};
//placemove method test
Debug.Assert(!placemove(testTwo, 'x', 1, 2));
testTwo[0][0] = ' ';
Debug.Assert(placemove(testTwo, 'o', 0, 0));

//This method assigns the key numbers with a coordinate on the the grid.
void getMove(ref char[][] grid, char token)
{
    //gets user input each number is assigned with a coordinate place. The user has to push a number on the number to place an 'x' or an 'o'
    ConsoleKeyInfo cki;
    bool isvalid = false;
    do
    {
    cki = Console.ReadKey(true);
    if (cki.Key == ConsoleKey.NumPad1 || cki.Key == ConsoleKey.D1)
    {
       isvalid = placemove(grid, token, 2, 0);
    }
    if (cki.Key == ConsoleKey.NumPad2 || cki.Key == ConsoleKey.D2)
    {
        isvalid = placemove(grid, token, 2, 1);
    }
    if (cki.Key == ConsoleKey.NumPad3 || cki.Key == ConsoleKey.D3)
    {
        isvalid = placemove(grid, token, 2, 2);
    }
    if (cki.Key == ConsoleKey.NumPad4 || cki.Key == ConsoleKey.D4)
    {
        isvalid = placemove(grid, token, 1, 0);
    }
    if (cki.Key == ConsoleKey.NumPad5 || cki.Key == ConsoleKey.D5)
    {
        isvalid = placemove(grid, token, 1, 1);
    }
    if (cki.Key == ConsoleKey.NumPad6 || cki.Key == ConsoleKey.D6)
    {
        isvalid = placemove(grid, token, 1, 2);
    }
    if (cki.Key == ConsoleKey.NumPad7 || cki.Key == ConsoleKey.D7)
    {
        isvalid = placemove(grid, token, 0, 0);
    }
    if (cki.Key == ConsoleKey.NumPad8 || cki.Key == ConsoleKey.D8)
    {
        isvalid = placemove(grid, token, 0, 1);
    }
    if (cki.Key == ConsoleKey.NumPad9 || cki.Key == ConsoleKey.D9)
    {
        isvalid = placemove(grid, token, 0, 2);
    }
    }
    while(!isvalid);
}

bool playAgian()
{
    Console.WriteLine("Do you want to play again?");
    int selection = Convert.ToInt32(Console.ReadLine());
    switch(selection)
    {
        case 1:
        {
            return true;
        }
        case 2:
        {
            return false;
        }
        default: 
        {
            return false;
        }
    }
}


//This method allows you to play the game
void playGame()
{
    //introduce the game
    Console.WriteLine("Let's play Tic-Tac-Toe.");
Console.WriteLine("X will start. Chose a number 1-9 on the number key pad. Each number corrisponds to the placement on the grid.");
    //crerates a grid to play on
 char[][] grid = 
{
    new char[] {' ', ' ', ' ' },
    new char[] { ' ', ' ', ' ' },
    new char[] { ' ', ' ', ' ' }
};
bool gameGoing = true;
// A while loop is used to continue wile the game is not over
    while(gameGoing)
    {
        //print grid
        printGrid(grid);
        // check if won
        if(gameWon(grid))
        {
            break;
        }
        //player 1
        // get move
        getMove(grid, 'x');
        //print grid
        printGrid(grid);
        //check if won
        if(gameWon(grid))
        {
            break;
        }
        // player 2
        //get move
        getMove(grid, 'o');
        
    }
  using (StreamWriter sw = new StreamWriter("Results"))
  {
    for(int i = 0; i < 3; i ++)
    {
        sw.WriteLine(grid[i][0] + "|" + grid[i][1] + "|" + grid[i][2]);
        if(i != 2)
        {
            sw.WriteLine("-----");
        }
    }
  }
}


bool repeat = true;
do
{
    playGame();
    repeat = playAgian();
}
while(repeat);






