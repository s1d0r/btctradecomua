using System;
using System.Net.Http;
using System.Threading.Tasks;
using s1d0r.marketplace;

namespace s1d0r.btctradecomua
{
    public class BtcTradeComUa : IMarketPlace
    {
        public BtcTradeComUa(string publicKey, string privateKey, HttpClient httpClient)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
            this.HttpClient = httpClient;
        }

        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public HttpClient HttpClient { get; set; }
        public int Nonce { get; set; } = 0;
        public int OutOrderId { get; set; } = 1;
        public string Token { get; set; }
        public Auth Auth { get; set; }

        public Task<string> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<string> PlaseBuyOrder()
        {
            throw new NotImplementedException();
        }

        public Task<string> PlaseSellOrder()
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveOrder()
        {
            throw new NotImplementedException();
        }

        public Task<string> StatusOrder()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetBalance()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTiker()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTikerCertainSymbolAsync(string symbol)
        {
            throw new NotImplementedException();
        }
    }
}
