using System.Collections.Generic;
using CounosPayClient.Api.V1.Models;

namespace CounosPayClient.Api.V1.Inf
{
    public class Consts
    {
	    public static List<Ticker> AllTickers = new List<Ticker>
	    {
		    new Ticker(id: 1,title: "Counos Coin",name: "counoscoin",shortname: "cca",type: TickerTypes.Crypto),
		    new Ticker(id: 2,title: "Counos Cash",name: "counoscash",shortname: "cch",type: TickerTypes.Crypto),
		    new Ticker(id: 3,title: "Counos USD" ,name: "counosu"   ,shortname: "ccu",type: TickerTypes.Crypto),
		    new Ticker(id: 4,title: "Counos Euro",name: "counose"   ,shortname: "cce",type: TickerTypes.Crypto),
		    new Ticker(id: 5,title: "Counos CAD" ,name: "counoscad" ,shortname: "ccc",type: TickerTypes.Crypto),
		    new Ticker(id: 6,title: "Counos X"   ,name: "counosx"   ,shortname: "ccx",type: TickerTypes.Crypto),
		    new Ticker(id: 7,title: "Bitcoin"    ,name: "bitcoin"   ,shortname: "btc",type: TickerTypes.Crypto),
		    new Ticker(id: 8,title: "Ethereum"   ,name: "ethereum"  ,shortname: "eth",type: TickerTypes.Crypto),
		    new Ticker(id: 9,title: "Litecoin"   ,name: "litecoin"  ,shortname: "ltc",type: TickerTypes.Crypto),

	        new Ticker(id: 10001, title: "United States Dollar", name: "dollar", shortname: "usd",type:TickerTypes.Currency),
		    new Ticker(id: 10002, title: "Euro", name: "euro", shortname: "eur",type:TickerTypes.Currency),
		    new Ticker(id: 10003, title: "Japanese Yen", name: "yen", shortname: "jpy",type:TickerTypes.Currency),
		    new Ticker(id: 10004, title: "Pound Sterling", name: "pound", shortname: "gbp",type:TickerTypes.Currency),
		    new Ticker(id: 10005, title: "Australian Dollar", name: "audollar", shortname: "aud",type:TickerTypes.Currency),
		    new Ticker(id: 10006, title: "Canadian Dollar", name: "cadollar", shortname: "cad",type:TickerTypes.Currency),
		    new Ticker(id: 10007, title: "Swiss Franc", name: "chfollar", shortname: "chf",type:TickerTypes.Currency),
		    new Ticker(id: 10008, title: "Renminbi", name: "renminbi", shortname: "cny",type:TickerTypes.Currency),
		    new Ticker(id: 10009, title: "Swedish Krona", name: "swedishkrona", shortname: "sek",type:TickerTypes.Currency),
		    new Ticker(id: 10010, title: "New Zealand Dollar", name: "nzdollar", shortname: "nzd",type:TickerTypes.Currency),
		    new Ticker(id: 10011, title: "Mexican Peso", name: "mexicanpeso", shortname: "mxn",type:TickerTypes.Currency),
		    new Ticker(id: 10012, title: "Singapore Dollar", name: "sgdollar", shortname: "sgd",type:TickerTypes.Currency),
		    new Ticker(id: 10013, title: "Hong Kong Dollar", name: "hkdollar", shortname: "hkd",type:TickerTypes.Currency),
		    new Ticker(id: 10014, title: "Norwegian Krone", name: "norwegiankrone", shortname: "nok",type:TickerTypes.Currency),
		    new Ticker(id: 10015, title: "South Korean Won", name: "southkoreanwon", shortname: "krw",type:TickerTypes.Currency),
		    new Ticker(id: 10016, title: "Turkish Lira", name: "turkishlira", shortname: "try",type:TickerTypes.Currency),
		    new Ticker(id: 10017, title: "Russian Ruble", name: "russianruble", shortname: "rub",type:TickerTypes.Currency),
		    new Ticker(id: 10018, title: "Indian Rupee", name: "indianrupee", shortname: "inr",type:TickerTypes.Currency),
		    new Ticker(id: 10019, title: "Brazilian Real", name: "brazilianreal", shortname: "brl",type:TickerTypes.Currency),
		    new Ticker(id: 10020, title: "South African Rand", name: "southafricanrand", shortname: "zar",type:TickerTypes.Currency),
		    new Ticker(id: 10021, title: "Iran Rial", name: "iranrial", shortname: "irr",type:TickerTypes.Currency),

	        new Ticker(id: 11000, title: "Gold", name: "gold", shortname: "gold",type:TickerTypes.PreciousMetal),
	        //new Ticker(id: 11002, title: "Gold 23k", name: "gold23k", shortname: "gold23k",type:TickerTypes.PreciousMetals),
	        //new Ticker(id: 11003, title: "Gold 22k", name: "gold22k", shortname: "gold22k",type:TickerTypes.PreciousMetals),
	        //new Ticker(id: 11004, title: "Gold 21k", name: "gold21k", shortname: "gold21k",type:TickerTypes.PreciousMetals),
         //   new Ticker(id: 11004, title: "Gold 20k", name: "gold20k", shortname: "gold20k",type:TickerTypes.PreciousMetals),
	        //new Ticker(id: 11004, title: "Gold 19k", name: "gold19k", shortname: "gold19k",type:TickerTypes.PreciousMetals),
         //   new Ticker(id: 11005, title: "Gold 18k", name: "gold18k", shortname: "gold18k",type:TickerTypes.PreciousMetals),
	        //new Ticker(id: 11005, title: "Gold 17k", name: "gold17k", shortname: "gold17k",type:TickerTypes.PreciousMetals),
         //   new Ticker(id: 11006, title: "Gold 16k", name: "gold16k", shortname: "gold16k",type:TickerTypes.PreciousMetals),
	        //new Ticker(id: 11006, title: "Gold 15k", name: "gold15k", shortname: "gold15k",type:TickerTypes.PreciousMetals),
         //   new Ticker(id: 11007, title: "Gold 14k", name: "gold14k", shortname: "gold14k",type:TickerTypes.PreciousMetals),
	        //new Ticker(id: 11007, title: "Gold 13k", name: "gold13k", shortname: "gold13k",type:TickerTypes.PreciousMetals),
         //   new Ticker(id: 11008, title: "Gold 12k", name: "gold12k", shortname: "gold12k",type:TickerTypes.PreciousMetals),
	        //new Ticker(id: 11008, title: "Gold 11k", name: "gold11k", shortname: "gold11k",type:TickerTypes.PreciousMetals),
         //   new Ticker(id: 11009, title: "Gold 10k", name: "gold10k", shortname: "gold10k",type:TickerTypes.PreciousMetals),

        };

    }
}
