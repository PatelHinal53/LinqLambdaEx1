using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambdaEx
{
   public class Program
    {
        static void Main(string[] args)
        {
            List<string> cities = new List<string>
            {

                "Mumbai",
                "Delhi",
                "Ahmedabad",
                "Surat",
                "Valsad",
                "Varanasi",
                "Chennai",
                "Bhopal",
                "Darjeeling"
                
            };
            //1.Descending Order.
            var orderedcitiesLinq = (from city in cities
                                     orderby city descending
                                     select city).ToList();

            var orderedcitiesLambda = cities.OrderByDescending(Cities => Cities).ToList();
            DisplayCities(orderedcitiesLambda);

            //2.ascending order.
            var orderedascendingcitiesLinq = (from city in cities
                                              orderby city ascending
                                              select city).ToList();

            var orderedascendingcitiesLambda = cities.OrderBy(Cities => Cities).ToList();
            DisplayCities(orderedascendingcitiesLambda);

            //3.descending order gy its length.
            var ordereddescendinglengthcitiesLinq = (from city in cities
                                                     orderby city.Length descending
                                                     select city).ToList();

            var ordereddescendinglengthcitiesLambda = cities.OrderByDescending(city => city.Length).ToList();
            DisplayCities(ordereddescendinglengthcitiesLambda);

            //4.ascending order gy its length.
            var orderedascendinglengthcitiesLinq = (from city in cities
                                                    orderby city.Length ascending
                                                    select city).ToList();

            var orderedascendinglengthcitiesLambda = cities.OrderBy(Cities => Cities.Length).ToList();
            DisplayCities(orderedascendinglengthcitiesLambda);

            //5.cities name startswith v and d letter.
            var startwithVandDLinq = (from city in cities
                                      where city.StartsWith("V") || city.StartsWith("D")
                                      select city).ToList();

            var startwithVandDLambda = cities.Where(city => city.StartsWith("V") || city.StartsWith("D")).ToList();
            DisplayCities(startwithVandDLambda);

            //6.Count of city names starts with A letter.
            var startwithALinq = (from city in cities
                                  where city.StartsWith("A")
                                  select city).Count();

            var startwithALambda = cities.Count(city => city.StartsWith("A"));
            Console.WriteLine("City Name that start with A is: " + startwithALinq);
            Console.WriteLine("City Name that start with A is: " + startwithALambda);
            Console.ReadKey();

            //7.Group ordered city names by its first letter.
            var citiesOrderedFirstLetterLinq = from city in cities
                                               group city by city[0] into cityGroup
                                               orderby cityGroup.Key
                                               select cityGroup;

            var citiesOrderedFirstLetterLambda = cities.GroupBy(city => city[0]).OrderBy(city => city.Key);

            foreach (var cityGroup in citiesOrderedFirstLetterLambda)
            {
                Console.WriteLine(cityGroup.Key);

                foreach (var city in cityGroup)
                {

                    Console.WriteLine(city);
                }

            }
            Console.ReadKey();
    }
        static void DisplayCities(List<string> cities)
        {
            foreach (var Cities in cities)
            {
                Console.WriteLine(Cities);
            }
            Console.ReadKey();
        }
    }
    
}
