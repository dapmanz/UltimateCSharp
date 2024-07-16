// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var dateforTest = DateTime.Now.AddYears(-2).AddMonths(7);
FastForwardToSummer(ref dateforTest);
Console.WriteLine(dateforTest);

void FastForwardToSummer(/*your code goes here*/ref DateTime inputDate)
{
    //your code goes here
    int summerDay = 21;
    int summerMonth = 6;
    var summerDayOfCurrentYear = new DateTime(inputDate.Year, summerMonth, summerDay);
  
    if (inputDate < summerDayOfCurrentYear)
    {
        inputDate = summerDayOfCurrentYear;
    }

}
