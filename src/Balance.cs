//{
//     "msg_count": 0,
//     "accounts":
//       [
//           {"currency": "UAH", "balance": "1744.2104180000"},
//           {"currency": "BTC", "balance": "0.1205538600"},
//           {"currency": "LTC", "balance": "1.0266850207"},
//           {"currency": "NVC", "balance": "0.0000000000"},
//           {"currency": "DRK", "balance": "0.0000000000"},
//           {"currency": "VTC", "balance": "0.0000000000"},
//           {"currency": "PPC", "balance": "0.0000000000"},
//           {"currency": "HIRO", "balance": "999.5000000000"}
//     ],
//     "notify_count": 0
// }

using System.Collections.Generic;

public class Balance
{
    int msg_count;
    List<CurrencyBalance> accounts;
    int motify_count;
}

public class CurrencyBalance
{
    string currency;
    float balance;
}

