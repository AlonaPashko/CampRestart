
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






