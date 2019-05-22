using MarketplaceWebServiceProducts;
using MarketplaceWebServiceProducts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMWSAccessor
{

    public class AmazonMwsDataAccessor
    {
        private const string ACCESSKEY = "AKIAIXZIGTIAMRWUS7MQ";
        private const string SECRETKEY = "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";
        private const string MARKETPLACEID = "ATVPDKIKX0DER";
        private const string SELLERID = "A1FJ1WMPKJVUMQ";
        private const string SERVICEURL = "https://mws.amazonservices.com";
        private readonly MarketplaceWebServiceProductsClient _productClient;

        public AmazonMwsDataAccessor()
        {
            var config = new MarketplaceWebServiceProductsConfig();
            config.ServiceURL = SERVICEURL;
            config.SignatureMethod = "HmacSHA256";
            _productClient = new MarketplaceWebServiceProductsClient("AmazonJavascriptScratchpad", "1.0", ACCESSKEY, SECRETKEY, config);
        }

        public string ListMatchingAmazonProductsForQuery(string query)
        {
            var request = new ListMatchingProductsRequest(SELLERID, MARKETPLACEID, query) ;

            var reponse = _productClient.ListMatchingProducts(request);


            return "Success";
        }

        //GetCompetitivePricingForASIN
        // Amazon throttle - 36000 requests per hour, quota 20 requests, restore 10 items every second
        public string GetCompetitivePricingForAsin(List<string> asin)
        {
            var asinListType = new ASINListType
            {
                ASIN = asin
            };
            var request = new GetCompetitivePricingForASINRequest(SELLERID, MARKETPLACEID, asinListType);

            var response = _productClient.GetCompetitivePricingForASIN(request);

            var result = response.GetCompetitivePricingForASINResult.First();

            return "Success";
        }
        //GetLowerstOfferListingsForASIN
        // Amazon throttle - 36000 requests per hour, quota 20 requests, restore 10 items every second
        public string GetLowestOfferListingsForAsin(List<string> asin)
        {
            var asinListType = new ASINListType
            {
                ASIN = asin
            };
            var request = new GetLowestOfferListingsForASINRequest(SELLERID, MARKETPLACEID, asinListType);

            var response = _productClient.GetLowestOfferListingsForASIN(request);

            var result = response.GetLowestOfferListingsForASINResult.First();

            return "Success";
        }

        //GetLowestPricedOffersForAsin
        // Amazon throttle - 200 requests per hour, quota 10 requests, restore 5 items every second
        public string GetLowestPricedOffersForAsin(string asin, string itemCondition)
        {

            var request = new GetLowestPricedOffersForASINRequest(SELLERID, MARKETPLACEID, asin, itemCondition);

            var response = _productClient.GetLowestPricedOffersForASIN(request);

            var result = response.GetLowestPricedOffersForASINResult;

            return "Success";
        }

    }
}
