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

    }
}
