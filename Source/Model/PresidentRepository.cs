using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PresidentRepository
    {
        public static IQueryable<President> GetAllPresidents()
        {
            var people = new List<President>();

            people.Add(new President("George", "Washington"){
                PresidentNumber = 1,
                TookOffice = new DateTime(1789,4,30),
                LeftOffice = new DateTime(1797,3,4),
                Party = "Independent",
                Terms = new Term[]{new Term(1, 1789), new Term(2,1792)}
            });

            people.Add(new President("John", "Adams"){
                PresidentNumber = 2,
                TookOffice = new DateTime(1797,3,4),
                LeftOffice = new DateTime(1801,3,4),
                Party = "Federalist",
                Terms = new Term[]{new Term(1,1796)}
            });

            people.Add(new President("Thomas", "Jefferson"){
                PresidentNumber = 3,
                TookOffice = new DateTime(1801,3,4),
                LeftOffice = new DateTime(1809,3,4),
                Party = "Democratic-Republican",
                Terms = new Term[]{new Term(1,1800), new Term(2,1804)}
            });

            people.Add(new President("James", "Madison") { 
                PresidentNumber = 4,
                TookOffice = new DateTime(1809,3,4),
                LeftOffice = new DateTime(1817,3,4),
                Party = "Democratic-Republican",
                Terms = new Term[] { new Term(1,1808), new Term(2,1812)}
            });

            people.Add(new President("James", "Monroe") { 
                PresidentNumber = 5,
                TookOffice = new DateTime(1817,3,4),
                LeftOffice = new DateTime(1825,3,4),
                Party = "Democratic-Republican",
                Terms = new Term[] { new Term(1,1816), new Term(2,1820)}
            });

            people.Add(new President("John Quincy", "Adams") { 
                PresidentNumber =6,
                TookOffice = new DateTime(1825,3,4),
                LeftOffice = new DateTime(1829,3,4),
                Party = "Democratic-Republican",
                Terms = new Term[] { new Term(1,1824)}
            });

            people.Add(new President("Andrew", "Jackson") { 
                PresidentNumber = 7,
                TookOffice = new DateTime(1829,3,4),
                LeftOffice = new DateTime(1837,3,4),
                Party = "Democratic",
                Terms = new Term[] { new Term(1,1828), new Term(2,1832)}
            });

            people.Add(new President("Martin", "Van Buren") { 
                PresidentNumber = 8,
                TookOffice = new DateTime(1837,3,4),
                LeftOffice = new DateTime(1841,3,4),
                Party = "Democratic",
                Terms = new Term[] { new Term(1,1836)}
            });

            people.Add(new President("William", "Harrison") { 
                PresidentNumber = 9,
                TookOffice = new DateTime(1841,3,4),
                LeftOffice = new DateTime(1841,4,4),
                Party = "Whig",
                Terms = new Term[] { new Term(1,1840)}
            });

            people.Add(new President("John", "Tyler") { 
                PresidentNumber = 10,
                TookOffice = new DateTime(1841,4,4),
                LeftOffice = new DateTime(1845,3,4),
                Party = "Whig-Independent",
                Terms = new Term[]{ new Term(1,1840)}
            });

            people.Add(new President("James", "Polk"){
                PresidentNumber = 11,
                TookOffice = new DateTime(1845,3,4),
                LeftOffice = new DateTime(1849,3,4),
                Party = "Democratic",
                Terms = new Term[]{ new Term(1,1844)}
            });

            people.Add(new President("Zachary", "Taylor"){
                PresidentNumber = 12,
                TookOffice = new DateTime(1849,3,4),
                LeftOffice = new DateTime(1850,7,9),
                Party = "Whig",
                Terms = new Term[]{ new Term(1,1848)}
            });

            people.Add(new President("Millard", "Fillmore"){
                PresidentNumber = 13,
                TookOffice = new DateTime(1850,7,9),
                LeftOffice = new DateTime(1853,3,4),
                Party = "Whig",
                Terms = new Term[]{ new Term(1,1848)}
            });

            people.Add(new President("Franklin", "Pierce"){
                PresidentNumber = 14,
                TookOffice = new DateTime(1853,3,4),
                LeftOffice = new DateTime(1857,3,4),
                Party = "Democratic",
                Terms = new Term[]{new Term(1,1852)}
            });

            people.Add(new President("James", "Buchanan"){
                PresidentNumber = 15,
                TookOffice = new DateTime(1857,3,4),
                LeftOffice = new DateTime(1861,3,4),
                Party = "Democratic",
                Terms = new Term[]{new Term(1,1856)}
            });

            people.Add(new President("Abraham", "Lincoln"){
                PresidentNumber = 16,
                TookOffice = new DateTime(1861,3,4),
                LeftOffice = new DateTime(1865,4,15),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1860), new Term(2,1864)}
            });

            people.Add(new President("Andrew", "Johnson"){
                PresidentNumber = 17,
                TookOffice = new DateTime(1865,4,15),
                LeftOffice = new DateTime(1869,3,4),
                Party = "Democratic-Independent",
                Terms = new Term[]{new Term(1,1864)}
            });

            people.Add(new President("Ulysses", "Grant"){
                PresidentNumber = 18,
                TookOffice = new DateTime(1869,3,4),
                LeftOffice = new DateTime(1877,3,4),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1868), new Term(2,1872)}
            });

            people.Add(new President("Rutherford", "Hayes"){
                PresidentNumber = 19,
                TookOffice = new DateTime(1877,3,4),
                LeftOffice = new DateTime(1881,3,4),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1876)}
            });

            people.Add(new President("James", "Garfield"){
                PresidentNumber = 20,
                TookOffice = new DateTime(1881,3,4),
                LeftOffice = new DateTime(1881,9,19),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1880)}
            });

            people.Add(new President("Chester", "Arthur"){
                PresidentNumber = 21,
                TookOffice = new DateTime(1881,9,19),
                LeftOffice = new DateTime(1885,3,4),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1880)}
            });

            people.Add(new President("Grover", "Cleveland"){
                PresidentNumber = 22,
                TookOffice = new DateTime(1885,3,4),
                LeftOffice = new DateTime(1889,3,4),
                Party = "Democratic",
                Terms = new Term[]{new Term(1,1884)}
            });

            people.Add(new President("Benjamin", "Harrison"){
                PresidentNumber = 23,
                TookOffice = new DateTime(1889,3,4),
                LeftOffice = new DateTime(1893,3,4),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1888)}
            });

            people.Add(new President("Grover", "Cleveland"){
                PresidentNumber = 24,
                TookOffice = new DateTime(1893,3,4),
                LeftOffice = new DateTime(1897,3,4),
                Party = "Democratic",
                Terms = new Term[]{new Term(1,1892)}
            });

            people.Add(new President("William", "McKinley"){
                PresidentNumber = 25,
                TookOffice = new DateTime(1897,3,4),
                LeftOffice = new DateTime(1901,9,14),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1896), new Term(2,1900)}
            });

            people.Add(new President("Theodore", "Roosevelt"){
                PresidentNumber = 26,
                TookOffice = new DateTime(1901,9,14),
                LeftOffice = new DateTime(1909,3,4),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1900), new Term(2,1904)}
            });

            people.Add(new President("William", "Taft"){
                PresidentNumber = 27,
                TookOffice = new DateTime(1909,3,4),
                LeftOffice = new DateTime(1913,3,4),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1908)}
            });

            people.Add(new President("Woodrow", "Wilson"){
                PresidentNumber = 28,
                TookOffice = new DateTime(1913,3,4),
                LeftOffice = new DateTime(1921,3,4),
                Party = "Democratic",
                Terms = new Term[]{new Term(1,1912), new Term(2,1916)}
            });

            people.Add(new President("Warren", "Harding"){
                PresidentNumber = 29,
                TookOffice = new DateTime(1921,3,4),
                LeftOffice = new DateTime(1923,8,2),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1920)}
            });

            people.Add(new President("Calvin", "Coolidge"){
                PresidentNumber = 30,
                TookOffice = new DateTime(1923,8,2),
                LeftOffice = new DateTime(1929,3,4),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1920),new Term(2,1924)}
            });

            people.Add(new President("Herbert", "Hoover"){
                PresidentNumber = 31,
                TookOffice = new DateTime(1929,3,4),
                LeftOffice = new DateTime(1933,3,4),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1928)}
            });

            people.Add(new President("Franklin", "Roosevelt"){
                PresidentNumber = 32,
                TookOffice = new DateTime(1933,3,4),
                LeftOffice = new DateTime(1945,4,12),
                Party = "Democratic",
                Terms = new Term[]{new Term(1,1932), new Term(2,1936), new Term(3, 1940), new Term(4, 1944)}
            });

            people.Add(new President("Harry", "Truman"){
                PresidentNumber = 33,
                TookOffice = new DateTime(1945,4,12),
                LeftOffice = new DateTime(1953,1,20),
                Party = "Democratic",
                Terms = new Term[]{new Term(1,1944), new Term(2,1948)}
            });

            people.Add(new President("Dwight", "Eisenhower"){
                PresidentNumber = 34,
                TookOffice = new DateTime(1953,1,20),
                LeftOffice = new DateTime(1961,1,20),
                Party = "Republican",
                Terms = new Term[]{new Term(1,1952), new Term(2,1956)}
            });

            people.Add(new President("John", "Kennedy"){
                PresidentNumber = 35,
                TookOffice = new DateTime(1961,1,20),
                LeftOffice = new DateTime(1963,11,22),
                Party = "Democratic",
                Terms = new Term[]{new Term(1,1960)}
            });

            people.Add(new President("Lyndon", "Johnson")
            {
                PresidentNumber = 36,
                TookOffice = new DateTime(1963, 11, 22),
                LeftOffice = new DateTime(1969, 1, 20),
                Party = "Democratic",
                Terms = new Term[] { new Term(1, 1960), new Term(2, 1964) }
            });

            people.Add(new President("Richard", "Nixon") { 
                PresidentNumber = 37,
                TookOffice = new DateTime(1969,1,20),
                LeftOffice = new DateTime(1974,8,9),
                Party = "Republican",
                Terms = new Term[] { new Term(1,1968), new Term(2,1972)}
            });

            people.Add(new President("Gerald", "Ford") {
                PresidentNumber = 38,
                TookOffice = new DateTime(1974,8,9),
                LeftOffice = new DateTime(1977,1,20),
                Party="Republican",
                Terms = new Term[] { new Term(1,1972)}
            });

            people.Add(new President("Jimmy", "Carter") { 
                PresidentNumber = 39,
                TookOffice = new DateTime(1977,1,20),
                LeftOffice = new DateTime(1981,1,20),
                Party = "Democratic",
                Terms = new Term[] { new Term(1,1976)},
                IsAlive = true
            });

            people.Add(new President("Ronald", "Reagan") { 
                PresidentNumber = 40,
                TookOffice = new DateTime(1981,1,20),
                LeftOffice = new DateTime(1989,1,20),
                Party = "Republican",
                Terms = new Term[] { new Term(1,1980), new Term(2,1984)}
            });

            people.Add(new President("George H.W.", "Bush"){
                PresidentNumber = 41,
                TookOffice = new DateTime(1989,1,20),
                LeftOffice = new DateTime(1993,1,20),
                Party = "Republican",
                Terms = new Term[] { new Term(1,1988)},
                IsAlive = true
            });

            people.Add(new President("Bill", "Clinton") { 
                PresidentNumber = 42,
                TookOffice = new DateTime(1993,1,20),
                LeftOffice = new DateTime(2001,1,20),
                Party = "Democratic",
                Terms = new Term[] { new Term(1,1992), new Term(2,1996)},
                IsAlive = true,
            });

            people.Add(new President("George W.", "Bush") { 
                PresidentNumber = 43,
                TookOffice = new DateTime(2001,1,20),
                LeftOffice = new DateTime(2009,1,20),
                Party = "Republican",
                Terms = new Term[] { new Term(1,2000), new Term(2,2004)},
                IsAlive = true,
            });

            people.Add(new President("Barack", "Obama") { 
                PresidentNumber = 44,
                TookOffice = new DateTime(2009,1,20),
                LeftOffice = new DateTime(2017,1,20),
                Party = "Democratic",
                Terms = new Term[] { new Term(1,2008), new Term(2,2012)},
                IsAlive = true
            });


            return people.AsQueryable();
        }

        
    }
}
