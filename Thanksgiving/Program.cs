namespace Thanksgiving
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
           var model = new Model();

            Console.WriteLine(model.ToString());

            Console.WriteLine("Mês(1/12): ");
            int inputMonth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ano: ");
            var inputYear = Convert.ToInt32(Console.ReadLine());

            var newOvolutionDate = model.OvulationOriginalDate;

            while (newOvolutionDate.Month != inputMonth || newOvolutionDate.Year != inputYear)
            {
                newOvolutionDate = newOvolutionDate.AddDays(model.CiclyeTime);
            }

            Console.WriteLine($"Thanksgiving Day: {newOvolutionDate.ToString("dd-MM-yyyy")}");
        }

    }
}



