using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PraticalTask3_LinearAndBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //initial build lists
            /*List<string> movieList = new List<string> { "movie1", "movie2", "movie3" };
            Console.WriteLine("Expected position for movie1 is 0 and for movie4 is -1");
            Console.WriteLine("Movie position for movie1 is at: {0}", LinearSearch.Search(movieList, "movie1"));
            Console.WriteLine("Movie position for movie4 is at: {0}", LinearSearch.Search(movieList, "movie4"));

            List<string> movieList2 = new List<string> { "movie1", "movie2", "movie3", "movie4", "movie5", "movie6" };
            Console.WriteLine("Expected position for movie1 is 0 and for movie4 is 3 and movie7 is -1");
            Console.WriteLine("Movie position for movie1 is at: {0}", BinarySearch.Search(movieList2, "movie1", 0, movieList2.Count - 1));
            Console.WriteLine("Movie position for movie4 is at: {0}", BinarySearch.Search(movieList2, "movie4", 0, movieList2.Count - 1));
            Console.WriteLine("Movie position for movie7 is at: {0}", BinarySearch.Search(movieList2, "movie7", 0, movieList2.Count - 1));
            Console.WriteLine("Movie position for movie3 is at: {0}", BinarySearch.Search(movieList2, "movie3", 0, movieList2.Count - 1));*/

            //test works with movie list data
            //create list variables for coresponding movie data files
            List<string> movieList20 = new List<string>();
            List<string> movieList100 = new List<string>();
            List<string> movieList200 = new List<string>();
            List<string> movieList100k = new List<string>();
            List<string> movieList400k = new List<string>();
            List<string> movieList2mil = new List<string>();
            //load movie files to coresponding movie list
            //20 list
            string movieFile20Path = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\movieTitles20.txt";
            movieList20 = File.ReadAllLines(movieFile20Path).ToList();
            //precheck file being loaded correctly into list
            //foreach(string item in movieList20) { Console.WriteLine(item); }
            //100 list
            string movieFile100Path = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\moviesTopGrossing100.txt";
            movieList100 = File.ReadAllLines(movieFile100Path).ToList();
            //200 list
            string movieFile200Path = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\moviesTopGrossing200.txt";
            movieList200 = File.ReadAllLines(movieFile200Path).ToList();
            //100k list
            string movieFile100kPath = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\movieTitles100K.txt";
            movieList100k = File.ReadAllLines(movieFile100kPath).ToList();
            //400k list
            string movieFile400kPath = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\movieTitles400K.txt";
            movieList400k = File.ReadAllLines(movieFile400kPath).ToList();
            //2mil list
            string movieFile2milPath = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\MovieTitles_2million.txt";
            movieList2mil = File.ReadAllLines(movieFile2milPath).ToList();
        }
        
    }
    class LinearSearch
    {
        public static int Search(List<string> movieList, string searchItem)
        {
            bool flag = false;
            int recordPosition = 0;
            //itterate through list till item is found or not
            foreach(string movie in movieList)
            {
                if(movie == searchItem) 
                {
                    flag = true;
                    break;
                }
                //movie not at current index increase recordPosition
                recordPosition++;
            }
            if (flag == false) { return recordPosition = -1; }
            else { return recordPosition; }
        }
    }
    class BinarySearch
    {
        public static int Search(List<string> movieList, string searchItem, int left, int right)
        {
            int recordPosition = 0;
            
            //check to see if left is smaller as it means the list hasn't been fully searched
            if (left < right)
            {
                int middle = (left + right-1) / 2;     
                //if middle indexed item == searchItem then found, otherwise compare to see if larger or smaller
                if (movieList[middle] == searchItem)
                {
                    // movie found
                    recordPosition = middle;
                    return recordPosition;
                }
                //check to see if larger than middle
                else if(searchItem.CompareTo(movieList[middle]) > 0)
                {
                    //movie can't be in left partition
                    return Search(movieList, searchItem, middle + 1, right);
                }
                //check to see if smaller than middle
                else if(searchItem.CompareTo(movieList[middle]) < 0)
                {
                    //movie can't be in right partition
                    return Search(movieList, searchItem, left, middle - 1);
                }
                else
                {
                    return Search(movieList, searchItem, left, right - 1);
                }
            }
            recordPosition = -1;
            return recordPosition;
        }
    }
}
