class Program
{
    static void Main()
    {

        string[] fileNames = new string[]
        {
            "10.txt", "11.txt", "12.txt", "13.txt", "14.txt", "15.txt", "16.txt", "17.txt",
            "18.txt", "19.txt", "20.txt", "21.txt", "22.txt", "23.txt", "24.txt", "25.txt",
            "26.txt", "27.txt", "28.txt", "29.txt"
        };
        //ліст з відсутніми файлами
        List<string> noFileList = new List<string>();
        //ліст з некоректними данними у файлі
        List<string> badDataList = new List<string>();
        //ліст з оефрвловами..
        List<string> overflowList = new List<string>();
        //добутки
        List<int> validProducts = new List<int>();
        foreach (string fileName in fileNames)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                                              
                int num1 = int.Parse(lines[0]);
                int num2 = int.Parse(lines[1]);                          
                //
                try
                {
                    int product = num1 * num2;
                    validProducts.Add(product);
                }
                catch (OverflowException)
                {
                    overflowList.Add(fileName);
                }
                //
            }
            catch (FileNotFoundException) { noFileList.Add(fileName); }
            catch (FormatException) { badDataList.Add(fileName); }
            catch (OverflowException) { overflowList.Add(fileName); }
            
        }
        try
        {
            //запис результатів у файли
            File.WriteAllLines("no_file.txt", noFileList);
            File.WriteAllLines("bad_data.txt", badDataList);
            File.WriteAllLines("overflow.txt", overflowList);
            //
            double average = validProducts.Average();
            Console.WriteLine($"Середнє арифметичне: {average}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Помилка при створенні або записі файлів: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Не вдалося обчислити добутки. {ex.Message}");
        }
    }
}
