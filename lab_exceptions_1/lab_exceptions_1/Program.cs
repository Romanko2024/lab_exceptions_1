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
        foreach (string fileName in fileNames)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                int num1, num2;
                
                try
                {
                    num1 = int.Parse(lines[0]);
                    num2 = int.Parse(lines[1]);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new FormatException();  //якщо щось не так з рядками
                }
                catch (FormatException)
                {
                    throw new FormatException();  //якщо не вишло парсити числа
                }
            }
            catch (FileNotFoundException) { noFileList.Add(fileName); }
            catch (FormatException) { badDataList.Add(fileName); }
            catch (OverflowException) { overflowList.Add(fileName); }
        }
    }
}
