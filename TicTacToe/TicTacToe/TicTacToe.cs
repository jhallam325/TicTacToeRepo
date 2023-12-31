﻿using System;

public class TicTacToe
{
    private int[,] gameboard = new int[3,3];
    private int player;
    private bool winCondition;

    public TicTacToe() 
    {
        int[,] gameboard = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        player = 1;
        winCondition = false;
    }

    public void PrintInstructions()
    {
        Console.WriteLine("Tic Tac Toe, here we go!");
        Console.WriteLine("The top number in a square is the position number");
        Console.WriteLine("The bottom number is \"0\" if the position is empty");
        Console.WriteLine("The bottom number is \"1\" if the player 1 chose it");
        Console.WriteLine("The bottom number is \"2\" if the player 2 chose it");
    }

    public void PrintBoardGame()
    {
        Console.WriteLine("  1  |  2  |  3  ");
        Console.WriteLine($"  {gameboard[0, 0]}  |  {gameboard[0, 1]}  |  {gameboard[0, 2]}  ");
        Console.WriteLine("-----------------");
        Console.WriteLine("  4  |  5  |  6  ");
        Console.WriteLine($"  {gameboard[1, 0]}  |  {gameboard[1, 1]}  |  {gameboard[1, 2]}  ");
        Console.WriteLine("-----------------");
        Console.WriteLine("  7  |  8  |  9  ");
        Console.WriteLine($"  {gameboard[2, 0]}  |  {gameboard[2, 1]}  |  {gameboard[2, 2]}  ");
    }

    public void PlayGame()
    {
        // Check for any spots left
        while (IsRemainingSpot() && !winCondition)
        {
            Console.Write($"Player {player}, which position do you choose? ");
            string input = Console.ReadLine();
            int position = Convert.ToInt32(input);

            // check input here
            // It must be between 1 and 9
            if (position < 1 || position > 9 )
            {
                Console.WriteLine("Please input a number from 1 to 9");
                continue;
            }

            // check input here
            // it must be an empty space
            bool isAvailable = CheckBoardForEmptySpotAtPosition(position);
            if (isAvailable)
            {
                AssignPositionAPlayer(position, player);
            }
            else
            {
                //Error message and require a new position
                Console.WriteLine("Fool, this spot is taken");
                continue;
            }
            BlankSpaces(7);
            PrintBoardGame();

            //Check for winner
            winCondition = CheckForWinner();

            // Let the next player have a turn
            if (!winCondition)
            {
                ChangePlayer(player);
            }
            else
            {
                BlankSpaces(2);
                WinMessage(player);
            }
        }
    }

    public bool CheckBoardForEmptySpotAtPosition(int position)
    {
        int shiftedPosition = position - 1;

        for (int i = 0; i < 9; i ++)
        {
            if (shiftedPosition == i && gameboard[shiftedPosition/3, shiftedPosition%3] == 0)
            {
                return true;
            }
        }
        return false;
    }

    public void AssignPositionAPlayer(int position, int player)
    {
        int shiftedPosition = position - 1;

        for (int i = 0; i < 9; i++)
        {
            if (shiftedPosition == i)
            {
                gameboard[shiftedPosition / 3, shiftedPosition % 3] = player;
            }
        }
    }

    public bool IsRemainingSpot()
    {
        for (int i = 0; i < gameboard.GetLength(0); i++)
        {
            for (int j = 0;  j < gameboard.GetLength(1); j++)
            {
                if (gameboard[i,j] == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void ChangePlayer(int player)
    {
        if (player == 1)
        {
            this.player = 2;
        }
        else
        {
            this.player = 1;
        }
    }

    public void BlankSpaces(int number)
    {
        for (int i = 0;i < number;i++)
        {
            Console.WriteLine();
        }
    }

    public bool CheckForWinner()
    {
        if (
            (gameboard[0, 0] == player && gameboard[0, 1] == player && gameboard[0, 2] == player) ||
            (gameboard[1, 0] == player && gameboard[1, 1] == player && gameboard[1, 2] == player) ||
            (gameboard[2, 0] == player && gameboard[2, 1] == player && gameboard[2, 2] == player) ||
            (gameboard[0, 0] == player && gameboard[1, 0] == player && gameboard[2, 0] == player) ||
            (gameboard[0, 1] == player && gameboard[1, 1] == player && gameboard[2, 1] == player) ||
            (gameboard[0, 2] == player && gameboard[1, 2] == player && gameboard[2, 2] == player) ||
            (gameboard[0, 0] == player && gameboard[1, 1] == player && gameboard[2, 2] == player) ||
            (gameboard[0, 2] == player && gameboard[1, 1] == player && gameboard[2, 0] == player)
           )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void WinMessage(int player)
    {
        Console.WriteLine($"Congratulations Player {player}! You have bested " +
            $"the enemy. Nicely Job!");
        Console.WriteLine("*Winning Animation*");
        Console.WriteLine("*Winning Fanfare do-do-do-do-doooooo*");
    }
}