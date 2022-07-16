
using Task8;

Visit visit1 = new Visit();

DateTime date1 = new DateTime(2008, 11, 12, 23, 28, 26);

Visit visit2 = new Visit("139.18.150.126", date1, "Myday");

List<Visit> visits = new List<Visit>();
visits.Add(visit1);
visits.Add(visit2);

VisitStatistic statistic1 = new VisitStatistic();
statistic1.Visits = visits;
Console.WriteLine(statistic1);

Console.WriteLine("---------------------------");
VisitStatistic statistic2 = new VisitStatistic("WebsiteVisitStatistics.txt");


Console.WriteLine(statistic2);
Console.WriteLine(statistic2.GetQuantityIP());

Console.WriteLine("The most popular day is " + statistic2.MostPopularDay());
Console.WriteLine();

VisitStatistic statistic3 = new VisitStatistic();
List<string> compareList = new List<string>();

for (int i = 0; i < statistic2.Visits.Count; i++)//I think I have to take the most popular day and other for each IP without using Main.
    //I saw some LINQ methods in internet
{
    statistic3 = statistic2.MakeStatisticForOneIP(statistic2.Visits[i].AddressIP);

    if (!compareList.Contains(statistic2.Visits[i].AddressIP))
    {
        Console.WriteLine("IP: " + statistic2.Visits[i].AddressIP + " The most popular day is " + statistic3.MostPopularDay());
        compareList.Add(statistic2.Visits[i].AddressIP);
    }
}












