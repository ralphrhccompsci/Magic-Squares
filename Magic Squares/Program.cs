namespace Magic_Squares
{

class Program
    {
        static void Main()
        {
            bool matrixIsMagic = false;
            int counter = 1;
            int[,] theMatrix = new int[3, 3];

            while (!matrixIsMagic)
            {
                theMatrix = PopulateArray();
                //PrintArray(theMatrix);
                bool rowsAreMagic = PerformRowCheck(theMatrix);
                bool colsAreMagic = PerformColCheck(theMatrix);

                counter++;

                if (rowsAreMagic && colsAreMagic)
                {
                    Console.WriteLine("Squares produced: " + counter);
                    Console.WriteLine("Magic square found");
                    PrintArray(theMatrix);
                    matrixIsMagic = true;
                }
            }
        }

        static int[,] PopulateArray()
        {
            int[,] tempArray = new int[3, 3];
            // TODO: Randomly allocate the numbers 1 to 9 in a 3x3 grid without repetition
            int[] numbers = new int[9];

            // Fill list with numbers 1 to 9
            for (int i = 0; i < 9; i++)
            {
                numbers[i]= i+1;
            }
            
            // Shuffle using Fisher-Yates
            Random rand = new Random();
            for (int i = 8; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }

            // Fill 3x3 grid
            int index = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    tempArray[row, col] = numbers[index++];
                }
            }
            return tempArray;
        }

        static void PrintArray(int[,] tempArray)
        {
            // TODO: Display the 3x3 grid on the screen
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(tempArray[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static bool PerformRowCheck(int[,] tempArray)
        {
            bool isMagic = true;
            // TODO: Check if each row adds up to 15
            if (tempArray[0,0] + tempArray[0,1] + tempArray[0,2] != 15)
            {
                isMagic = false;
            }
            if (tempArray[1, 0] + tempArray[1, 1] + tempArray[1, 2] != 15)
            {
                isMagic = false;
            }
            if (tempArray[2, 0] + tempArray[2, 1] + tempArray[2, 2] != 15)
            {
                isMagic = false;
            }

            return isMagic;
        }

        static bool PerformColCheck(int[,] tempArray)
        {
            bool isMagic = true;
            // TODO: Check if each column adds up to 15

            if (tempArray[0, 0] + tempArray[1, 0] + tempArray[2, 0] != 15)
            {
                isMagic = false;
            }
            if (tempArray[0, 1] + tempArray[1, 1] + tempArray[2, 1] != 15)
            {
                isMagic = false;
            }
            if (tempArray[0, 2] + tempArray[1, 2] + tempArray[2, 2] != 15)
            {
                isMagic = false;
            }

            return isMagic;
        }
    }
}
