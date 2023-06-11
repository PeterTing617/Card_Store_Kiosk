using System;

namespace PassTask13
{
    public class Item
    {
        private string seriesNo;
        private string cardName;
        private string cardColor;
        private Rarity cardRarity;
        private bool cardFoil;
        private double cardPrice;
        private int cardQuantity;
        private bool promotionItem;
        /// <summary>
        /// This is a constructer to construct an item object which accept no, name, color, rare, foil, price, quantity and promotion.
        /// </summary>
        /// <param name="no"></param>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="rare"></param>
        /// <param name="foil"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <param name="promotion"></param>
        public Item(string no, string name, string color, Rarity rare, bool foil, double price, int quantity, bool promotion){
            seriesNo = no;
            cardName = name;
            cardColor = color;
            cardRarity = rare;
            cardFoil = foil;
            cardPrice = price;
            cardQuantity = quantity;
            promotionItem = promotion;
        }
        /// <summary>
        /// This is a property to get the information of seriesNo.
        /// </summary>
        /// <value></value>
        public string SeriesNo{
            get{return seriesNo;}
        }
        /// <summary>
        /// This is a property to get or set the information of cardName.
        /// </summary>
        /// <value></value>
        public string CardName{
            get{return cardName;}
            set{cardName = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of cardRarity.
        /// </summary>
        /// <value></value>
        public Rarity CardRarity{
            get{return cardRarity;}
            set{cardRarity = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of cardColor.
        /// </summary>
        /// <value></value>
        public string CardColor{
            get{return cardColor;}
            set{cardColor = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of cardFoil.
        /// </summary>
        /// <value></value>
        public bool CardFoil{
            get{return cardFoil;}
            set{cardFoil = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of cardPrice.
        /// </summary>
        /// <value></value>
        public double CardPrice{
            get{return cardPrice;}
            set{cardPrice = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of cardQuantity.
        /// </summary>
        /// <value></value>
        public int CardQuantity{
            get{return cardQuantity;}
            set{cardQuantity = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of promotionItem.
        /// </summary>
        /// <value></value>
        public bool PromotionItem{
            get{return promotionItem;}
            set{promotionItem = value;}
        }
        /// <summary>
        /// This is a method to print the card information.
        /// </summary>
        public void PrintCardInfo(){
            Console.WriteLine("Series No: " + seriesNo);
            Console.WriteLine("Card Name: " + cardName);
            Console.WriteLine("Card Rarity: " + cardRarity);
            Console.WriteLine("Card Color: " + cardColor);
            Console.WriteLine("Foil: " + cardFoil);
            Console.WriteLine("Price(RM): " + cardPrice);
            Console.WriteLine("Quantity: " + cardQuantity);
            Console.WriteLine("Promotion Item: " + promotionItem);
        }
        /// <summary>
        /// This is a method to print the card information for transaction object.
        /// </summary>
        public void PrintCardInfoTrans(){
            Console.WriteLine("Series No: " + seriesNo);
            Console.WriteLine("Card Name: " + cardName);
            Console.WriteLine("Card Rarity: " + cardRarity);
            Console.WriteLine("Card Color: " + cardColor);
            Console.WriteLine("Foil: " + cardFoil);
            Console.WriteLine("Price(RM): " + cardPrice);
            Console.WriteLine("Promotion Item: " + promotionItem);
        }
        /// <summary>
        /// This is a method to print the card information for sales.
        /// </summary>
        public void PrintCardInfoSales(){
            Console.WriteLine("Series No: " + seriesNo);
            Console.WriteLine("Card Name: " + cardName);
            Console.WriteLine("Card Rarity: " + cardRarity);
            Console.WriteLine("Card Color: " + cardColor);
            Console.WriteLine("Foil: " + cardFoil);
        }
    }
}