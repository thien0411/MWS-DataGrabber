using AmazonMWSAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMWS
{
    class Program
    {
        static void Main(string[] args)
        {
            var accessor = new AmazonMwsDataAccessor();

            var result = accessor.ListMatchingAmazonProductsForQuery("brakes");

            Console.Write(result);


        }
    }
}
