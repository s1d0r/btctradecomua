using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace s1d0r.btctradecomua
{
    public static class BtcTradeComUaApi
    {
        public static async Task<string> BalanceAsync(
                string token,
                HttpClient httpClient,
                int outOrderId,
                int nonce)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://btc-trade.com.ua/api/balance"));

            request.Headers.Add("token", token);

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> BalanceAsync(
            string publicKey,
            string privateKey,
            HttpClient httpClient,
            int outOrderId,
            int nonce
            )
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://btc-trade.com.ua/api/balance"));
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("out_order_id", outOrderId.ToString()),
                new KeyValuePair<string, string>("nonce", nonce.ToString())
            });

            request.Headers.Add("public_key", publicKey);
            request.Headers.Add("api_sign", await ApiSignAsync(content, privateKey));
            request.Content = content;

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> SellAsync(
            string token,
            HttpClient httpClient,
            int outOrderId,
            int nonce,
            string pair,
            float count,
            float price
        )
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"https://btc-trade.com.ua/api/sell/{pair}"));

            request.Headers.Add("token", token);

            request.Content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("count", count.ToString()),
                new KeyValuePair<string,string>("price", price.ToString()),
                new KeyValuePair<string,string>("out_order_id", outOrderId.ToString()),
                new KeyValuePair<string, string>("nonce", nonce.ToString())
            });

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> SellAsync(
            string publicKey,
            string privateKey,
            HttpClient httpClient,
            int outOrderId,
            int nonce,
            string pair,
            float count,
            float price
        )
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"https://btc-trade.com.ua/api/sell/{pair}"));

            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("count", outOrderId.ToString()),
                new KeyValuePair<string,string>("price", outOrderId.ToString()),
                new KeyValuePair<string,string>("out_order_id", outOrderId.ToString()),
                new KeyValuePair<string, string>("nonce", nonce.ToString())
            });

            request.Headers.Add("public_key", publicKey);
            request.Headers.Add("api_sign", await ApiSignAsync(content, privateKey));
            request.Content = content;

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> BuyAsync(
            string publicKey,
            string privateKey,
            HttpClient httpClient,
            int outOrderId,
            int nonce,
            string pair
        )
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"https://btc-trade.com.ua/api/buy/{pair}"));

            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("out_order_id", outOrderId.ToString()),
                new KeyValuePair<string, string>("nonce", nonce.ToString())
            });

            request.Headers.Add("public_key", publicKey);
            request.Headers.Add("api_sign", await ApiSignAsync(content, privateKey));
            request.Content = content;

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> TikerAsync(HttpClient httpClient)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://btc-trade.com.ua/api/ticker"));

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> TikerAsync(HttpClient httpClient, string pair)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri($"https://btc-trade.com.ua/api/ticker/{pair}"));

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> AuthAsync(
            string publicKey,
            string privateKey,
            HttpClient httpClient,
            int outOrderId,
            int nonce
            )
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://btc-trade.com.ua/api/auth"));

            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("out_order_id", outOrderId.ToString()),
                new KeyValuePair<string, string>("nonce", nonce.ToString())
            });

            request.Headers.Add("public_key", publicKey);
            request.Headers.Add("api_sign", await ApiSignAsync(content, privateKey));
            request.Content = content;

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> StatusAsync(
            string publicKey,
            string privateKey,
            HttpClient httpClient,
            int outOrderId,
            int nonce,
            string orderId
        )
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"https://btc-trade.com.ua/api/order/status/{orderId}"));

            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("out_order_id", outOrderId.ToString()),
                new KeyValuePair<string, string>("nonce", nonce.ToString())
            });

            request.Headers.Add("public_key", publicKey);
            request.Headers.Add("api_sign", await ApiSignAsync(content, privateKey));
            request.Content = content;

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> StatusAsync(
            string token,
            HttpClient httpClient,
            int outOrderId,
            int nonce,
            string orderId
        )
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"https://btc-trade.com.ua/api/order/status/{orderId}"));

            request.Headers.Add("token", token);
            request.Content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("out_order_id", outOrderId.ToString()),
                new KeyValuePair<string, string>("nonce", nonce.ToString())
            });

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> OrdersAsync(
            string token,
            HttpClient httpClient,
            int outOrderId,
            int nonce,
            string pair
        )
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"https://btc-trade.com.ua/api/my_orders/{pair}"));

            request.Headers.Add("token", token);

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> RemoveAsync(
            string publicKey,
            string privateKey,
            HttpClient httpClient,
            int outOrderId,
            int nonce,
            string orderId
        )
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"https://btc-trade.com.ua/api/order/remove/{orderId}"));

            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("out_order_id", outOrderId.ToString()),
                new KeyValuePair<string, string>("nonce", nonce.ToString())
            });

            request.Headers.Add("public_key", publicKey);
            request.Headers.Add("api_sign", await ApiSignAsync(content, privateKey));
            request.Content = content;

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> RemoveAsync(
            string token,
            HttpClient httpClient,
            int outOrderId,
            int nonce,
            string orderId
        )
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"https://btc-trade.com.ua/api/order/remove/{orderId}"));

            request.Headers.Add("token", token);
            request.Content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("out_order_id", outOrderId.ToString()),
                new KeyValuePair<string, string>("nonce", nonce.ToString())
            });

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<string> ApiSignAsync(FormUrlEncodedContent formUrlEncodedContent, string privateKey)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(await formUrlEncodedContent.ReadAsStringAsync() + privateKey)))
                .Replace("-", "")
                .ToLower();
        }

        public static string ApiSign(
            int outOrderId,
            int nonce,
            string privateKey
            )
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes($"out_order_id={outOrderId}&nonce={nonce}{privateKey}")))
                .Replace("-", "")
                .ToLower();
        }
    }
}