
using MathNet.Numerics.Statistics;

namespace HW1B
{

    class answer
    {
        static void Main(String[] args)
        {
            // File name that contains the data
            String fileName = "D:\\Assignments\\HWK1BAssignments\\HWK1B\\ACS_56_HWK\\HW1B\\dummydata.txt";
            // Read data from file
            string[][] data = ReadDataFromFile(fileName);

            // Show menu to the user
            while (true)
            {
                Console.WriteLine("1. Display data");
                Console.WriteLine("2. Add data");
                Console.WriteLine("3  Perform analysis");
                Console.WriteLine("4. Filter data");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayData(data);
                        break;
                    case 2:
                        AddData(fileName, data); break;
                    case 3:
                        PerformAnalysis(data); break;
                    case 4:
                        FilterData(data);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice. Please try again.");
                        break;
                }
            }
        }
        // Read data from file and convert it to a 2D array
        static string[][] ReadDataFromFile(string fileName)
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(fileName);
            // Create a 2D array to store the data
            string[][] data = new string[lines.Length][];

            // Split each line by tab
            for (int i = 0; i < lines.Length; i++)
            {
                data[i] = lines[i].Split('\t');
            }

            return data;
        }
        // Display data to the user
        static void DisplayData(string[][] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    Console.Write(data[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        // Add new data to the file
        static void AddData(string fileName, string[][] data)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter income: ");
            int income = int.Parse(Console.ReadLine());

            string newData = name + "\t" + age + "\t" + income;

            // Append new data to the file
            File.AppendAllText(fileName, newData + Environment.NewLine);
            // Re-read data from file to update the 2D array
            data = ReadDataFromFile(fileName);
        }
        // Perform analysis on the data
        static void PerformAnalysis(string[][] data)
        {
            // Create arrays to store age and income data
            int[] age = new int[data.Length];
            int[] income = new int[data.Length];

            // Extract age and income data from the 2D array
            for (int i = 0; i < data.Length; i++)
            {
                age[i] = int.Parse(data[i][1]);
                income[i] = int.Parse(data[i][2]);
            }
            // Calculate median and mean for age and income data
            double medianAge = Statistics.Median(age.Select(x => (double)x));
            double medianIncome = Statistics.Median(income.Select(x => (double)x));

            Console.WriteLine("Mean age: " + age.Average());
            Console.WriteLine("Median age: " + medianAge);
            Console.WriteLine("Mean income: " + income.Average());
            Console.WriteLine("Median income: " + medianIncome);
        }
        // Filter data based on user's choice
        static void FilterData(string[][] data)
        {
            Console.WriteLine("1. Filter by age");
            Console.WriteLine("2. Filter by income");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            IEnumerable<string[]> filteredData = null;
            switch (choice)
            {
                case 1:
                    Console.Write("Enter age: ");
                    int age = int.Parse(Console.ReadLine());
                    filteredData = data.Where(x => int.Parse(x[1]) == age);
                    break;
                case 2:
                    Console.Write("Enter income: ");
                    int income = int.Parse(Console.ReadLine());
                    filteredData = data.Where(x => int.Parse(x[2]) == income);
                    break;
                default:
                    Console.WriteLine("Invalid Choice. Please try again.");
                    break;
            }
            if (filteredData != null)
            {
                // Display filtered data to the user
                Console.WriteLine("Name\tAge\tIncome");
                foreach (string[] row in filteredData)
                {
                    Console.WriteLine(string.Join("\t", row));
                }
            }
        }
    }
}






