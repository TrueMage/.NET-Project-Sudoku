namespace Sudoku
{
    internal class Program
    {
        static void Main()
        {
            Board board = new Board();

            int selectedRow = -1;
            int selectedCol = -1;

            while (true)
            {
                Console.Clear();
                board.DisplayBoard(selectedRow, selectedCol);
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Выбрать клетку");
                Console.WriteLine("2. Заполнить ячейку");
                Console.WriteLine("3. Завершить игру");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Введите номер строки (1-9): ");
                    selectedRow = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Введите номер столбца (1-9): ");
                    selectedCol = int.Parse(Console.ReadLine()) - 1;
                }
                else if (choice == "2")
                {
                    if (selectedRow != -1 && selectedCol != -1)
                    {
                        Console.Write("Введите значение (1-9): ");
                        int value = int.Parse(Console.ReadLine());

                        if (!board.InsertValue(selectedRow, selectedCol, value))
                        {
                            Console.WriteLine("Недопустимый ход. Пожалуйста, проверьте правила судоку.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Пожалуйста, выберите клетку, в которую хотите вставить цифру.");
                        Console.ReadLine();
                    }
                }
                else if (choice == "3")
                {
                    // Завершение игры
                    break;
                }
            }
        }
    }
}
