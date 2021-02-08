using System;
using s1d0r.marketplace;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace s1d0r.btctradecomua
{
    public class BtcTradeUa : IMarketPlace
    {
        private int outOrderId;
        private int nonce;

        public BtcTradeUa(HttpClient httpClient, String publicKey)
        {
            HttpClient = httpClient;
            PublicKey = publicKey;
        }

        public HttpClient HttpClient { get; }
        public string PublicKey { get; }

        /// <summary>
        /// https://btc-trade.com.ua/api/balance
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetBalanceAsync()
        {
            using (var request = new HttpRequestMessage(
                HttpMethod.Post,
                new Uri("https://btc-trade.com.ua/api/balance")
                ))
            {
                request.Headers.Authorization = SetAuthenticationHeader(PublicKey);

                var data = new Dictionary<string, string>();
                data.Add("out_order_id", outOrderId.ToString());
                data.Add("nonce", nonce.ToString());
                request.Content = new FormUrlEncodedContent(data);

                using (var response = await HttpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                        return await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                    else
                        return null;
                }
            }
        }

        private AuthenticationHeaderValue SetAuthenticationHeader(string publicKey)
        {
            throw new NotImplementedException();
        }

        public string GetOrders()
        {
            throw new NotImplementedException();
        }

        public string GetTiker()
        {
            throw new NotImplementedException();
        }

        public bool PlaseBuyOrder()
        {
            throw new NotImplementedException();
        }

        public bool PlaseSellOrder()
        {
            throw new NotImplementedException();
        }

        public bool RemoveOrder()
        {
            throw new NotImplementedException();
        }

        public bool StatusOrder()
        {
            throw new NotImplementedException();
        }
    }
}
