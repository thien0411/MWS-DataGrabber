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
            var result1 = accessor.GetCompetitivePricingForAsin(new List<string> { "B0773ZLW9J" });
            var result2 = accessor.GetLowestOfferListingsForAsin(new List<string> { "B0773ZLW9J" });
            var result3 = accessor.GetLowestPricedOffersForAsin("B0773ZLW9J", "new");   
            Console.Write(result);


        }
    }
}
