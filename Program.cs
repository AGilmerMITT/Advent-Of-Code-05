using System.Text;

namespace Advent_Of_Code_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stacks = GetInitialStacks();

            bool collectingData = true;
            while (collectingData)
            {
                string input = GetInput("Your orders?");
                if (input == "")
                {
                    break;
                }

                string[] orders = input.Split(' ');
                int quantityMoved = int.Parse(orders[1]);
                int sourceStack = int.Parse(orders[3]) - 1;
                int destinationStack = int.Parse(orders[5]) - 1;

                // MoveCrates(stacks, quantityMoved, sourceStack, destinationStack);
                MoveCratesPt2(stacks, quantityMoved, sourceStack, destinationStack);
            }

            string finalPrintout = GetPrintout(stacks);
            Console.WriteLine("Final printout: " + finalPrintout);
        }

        static Stack<char>[] GetInitialStacks()
        {
            Stack<char>[] result =
            {
                new("DLVTMHF"), new("HQGJCTNP"), new("RSDMPH"),
                new("LBVF"), new("NHGLQ"), new("WBDGRMP"),
                new("GMNRCHLQ"), new("CLW"), new("RDLQJZMT")
            };

            return result;
        }

        static string GetInput(string prompt)
        {
            bool validResult = false;
            string? input = null;
            while (!validResult)
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                if (input != null)
                {
                    validResult = true;
                }
            }

            return input!;
        }

        static string GetPrintout(Stack<char>[] stacks)
        {
            StringBuilder result = new();
            foreach (Stack<char> stack in stacks)
            {
                if (stack.TryPeek(out char letter))
                    result.Append(letter);
            }

            return result.ToString();
        }

        static void MoveCrates(Stack<char>[] stacks, int quantityMoved, int sourceStack, int destinationStack)
        {
            for (int i = 0; i < quantityMoved; i++)
            {
                stacks[destinationStack].Push(stacks[sourceStack].Pop());
            }
        }

        static void MoveCratesPt2(Stack<char>[] stacks, int quantityMoved, int sourceStack, int destinationStack)
        {
            Stack<char> temp = new();

            for (int i = 0; i < quantityMoved; i++)
            {
                temp.Push(stacks[sourceStack].Pop());
            }

            while (temp.Count > 0)
            {
                stacks[destinationStack].Push(temp.Pop());
            }
        }
    }
}