using System;
using System.Collections.Generic;
using System.Linq;

namespace PassTask13
{
    public class ItemList
    {
        private List<Item> cardList;
        /// <summary>
        /// This is a constructer of the ItemList which will create a list of Item when initialize.
        /// </summary>
        public ItemList(){
            cardList = new List<Item>();
        }
        /// <summary>
        /// This is a property to get the information of cardList.
        /// </summary>
        /// <value></value>
        public List<Item> CardList{
            get{return cardList;}
            set{cardList = value;}
        }
        /// <summary>
        /// This is a property to get the information of the size of cardList.
        /// </summary>
        /// <value></value>
        public int ItemTotal{
            get{return cardList.Count;}
        }
        /// <summary>
        /// This is a method to add an item object into the list.
        /// </summary>
        /// <param name="i"></param>
        public void AddItemIntoList(Item i){
            cardList.Add(i);
            Console.WriteLine("Added successfully\n");
        }
        /// <summary>
        /// This is a method to remove an item object from the list.
        /// </summary>
        /// <param name="i"></param>
        public void RemoveItemFromList(Item i){
            cardList.Remove(i);
            Console.WriteLine("Removed successfully\n");
        }
        /// <summary>
        /// This is a method to edit an item object from the list.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="edit"></param>
        public void EditItemFromList(Item i, string edit){
            bool validEdit = true;
            if(edit == "Name"){
                Console.Write("Enter name: ");
                string editedName = Console.ReadLine().Trim();
                if(editedName == ""){
                    Console.WriteLine("Cannot be empty\n");
                } else {
                    Item previewItem = new Item(i.SeriesNo, editedName, i.CardColor, i.CardRarity, i.CardFoil, i.CardPrice, i.CardQuantity, i.PromotionItem);
                    if(SearchSimilar(previewItem)){
                        validEdit = false;
                        Console.WriteLine("Unable to edit object due to similar item found\n");
                    }
                    if(validEdit){
                        i.CardName = editedName;
                        Console.WriteLine("Editted successfully\n");
                    }
                }
            
            } else if(edit == "Color"){
                Console.Write("Enter color: ");
                string editedColor = Console.ReadLine().Trim();
                if(editedColor == ""){
                    Console.WriteLine("Cannot be empty\n");
                } else {
                    Item previewItem = new Item(i.SeriesNo, i.CardName, editedColor, i.CardRarity, i.CardFoil, i.CardPrice, i.CardQuantity, i.PromotionItem);
                    if(SearchSimilar(previewItem)){
                        validEdit = false;
                        Console.WriteLine("Unable to edit object due to similar item found\n");
                    }
                    if(validEdit){
                        i.CardColor = editedColor;
                        Console.WriteLine("Editted successfully\n");
                    }
                }


            } else if(edit == "Rarity"){
                Console.Write("Choose Rarity(1)Common, (2)Uncommon, (3)Rare: ");
                string cardR = Console.ReadLine().Trim();
                Rarity editedRare;
                if(cardR == "1"){
                    editedRare = Rarity.Common;
                    Item previewItem = new Item(i.SeriesNo, i.CardName, i.CardColor, editedRare, i.CardFoil, i.CardPrice, i.CardQuantity, i.PromotionItem);
                    if(SearchSimilar(previewItem)){
                        validEdit = false;
                        Console.WriteLine("Unable to edit object due to similar item found\n");
                    }
                    if(validEdit){
                        i.CardRarity = editedRare;
                        Console.WriteLine("Editted successfully\n");
                    }
                } else if(cardR == "2"){
                    editedRare = Rarity.Uncommon;
                    Item previewItem = new Item(i.SeriesNo, i.CardName, i.CardColor, editedRare, i.CardFoil, i.CardPrice, i.CardQuantity, i.PromotionItem);
                    if(SearchSimilar(previewItem)){
                        validEdit = false;
                        Console.WriteLine("Unable to edit object due to similar item found\n");
                    }
                    if(validEdit){
                        i.CardRarity = editedRare;
                        Console.WriteLine("Editted successfully\n");
                    }
                } else if(cardR == "3"){
                    editedRare = Rarity.Rare;
                    Item previewItem = new Item(i.SeriesNo, i.CardName, i.CardColor, editedRare, i.CardFoil, i.CardPrice, i.CardQuantity, i.PromotionItem);
                    if(SearchSimilar(previewItem)){
                        validEdit = false;
                        Console.WriteLine("Unable to edit object due to similar item found\n");
                    }
                    if(validEdit){
                        i.CardRarity = editedRare;
                        Console.WriteLine("Editted successfully\n");
                    }
                } else {
                    Console.WriteLine("Invalid Input\n");
                }

            } else if(edit == "Foil"){
                Console.Write("Card Foil(1)Yes, (2)No: ");
                string cardF = Console.ReadLine().Trim();
                bool editedFoil;
                if(cardF == "1"){
                    editedFoil = true;
                    Item previewItem = new Item(i.SeriesNo, i.CardName, i.CardColor, i.CardRarity, editedFoil, i.CardPrice, i.CardQuantity, i.PromotionItem);
                    if(SearchSimilar(previewItem)){
                        validEdit = false;
                        Console.WriteLine("Unable to edit object due to similar item found\n");
                    }
                    if(validEdit){
                        i.CardFoil = editedFoil;
                        Console.WriteLine("Editted successfully\n");
                    }
                } else if(cardF == "2"){
                    editedFoil = false;
                    Item previewItem = new Item(i.SeriesNo, i.CardName, i.CardColor, i.CardRarity, editedFoil, i.CardPrice, i.CardQuantity, i.PromotionItem);
                    if(SearchSimilar(previewItem)){
                        validEdit = false;
                        Console.WriteLine("Unable to edit object due to similar item found\n");
                    }
                    if(validEdit){
                        i.CardFoil = editedFoil;
                        Console.WriteLine("Editted successfully\n");
                    }
                } else {
                    Console.WriteLine("Invalid Input\n");
                }

            } else if(edit == "Price"){
                Console.Write("Enter Price(RM): ");
                double editCardPrice;
                string eCPrice = Console.ReadLine().Trim();
                bool validInput = double.TryParse(eCPrice, out editCardPrice);
                if(!validInput){
                    Console.WriteLine("Invalid Input\n");
                } else {
                    if(editCardPrice<=0){
                        Console.WriteLine("Invalid amount\n");

                    } else {
                        i.CardPrice = editCardPrice;
                        Console.WriteLine("Editted successfully\n");
                    }
                }

            } else if(edit == "Quantity"){
                Console.Write("Enter Quantity: ");
                int editCardQuantity;
                string eCQuantity = Console.ReadLine().Trim();
                bool validInput = Int32.TryParse(eCQuantity, out editCardQuantity);
                if(!validInput){
                    Console.WriteLine("Invalid Input\n");
                } else {
                    if(editCardQuantity<=0){
                        Console.WriteLine("Invalid amount\n");
                    } else {
                        i.CardQuantity = editCardQuantity;
                        Console.WriteLine("Editted successfully\n");
                    }
                }

            } else if(edit == "Promotion"){
                Console.Write("Promotion Item(1)Yes, (2)No: ");
                string cardD = Console.ReadLine().Trim();
                if(cardD == "1"){
                    i.PromotionItem = true;
                    Console.WriteLine("Editted successfully\n");
                } else if(cardD == "2"){
                    i.PromotionItem = false;
                    Console.WriteLine("Editted successfully\n");
                } else {
                    Console.WriteLine("Invalid Input\n");
                }
            }
        }
        /// <summary>
        /// This is a method to replenish item from list.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="amount"></param>
        public void ReplenishItemFromList(Item i, int amount){
            i.CardQuantity = i.CardQuantity + amount;
            Console.WriteLine("Replenished successfully\n");
        }
        /// <summary>
        /// This is a method to search similar item from list and returns a boolean.
        /// </summary>
        /// <param name="tst"></param>
        /// <returns></returns>
        public bool SearchSimilar(Item tst){
            bool similar = false;
            foreach(Item i in cardList){
                if(i.CardName == tst.CardName && i.CardRarity == tst.CardRarity && i.CardColor == tst.CardColor && i.CardFoil == tst.CardFoil){
                    similar = true;
                }
            }
            return similar;
        }
        /// <summary>
        /// This is a method to search an item from list using item's ID.
        /// </summary>
        public void SearchItemIDFromList(){
            Console.Write("Enter Series No: ");
            string searchCardNo = Console.ReadLine().Trim(); 
            bool search = false;
            foreach(Item i in cardList){
                if(i.SeriesNo == searchCardNo){
                    Console.WriteLine("============================");
                    Console.WriteLine("Card Info:");
                    Console.WriteLine("============================");
                    i.PrintCardInfo();
                    Console.WriteLine();
                    search = true;
                }
            }
            if(search == false){
                Console.WriteLine("Card Not Found\n");
            }
        }
        /// <summary>
        /// This is a method to search an item from list using item's name.
        /// </summary>
        public void SearchItemNameFromList(){
            Console.Write("Enter Card Name: ");
            string searchCardName = Console.ReadLine().Trim(); 
            bool search = false;
            foreach(Item i in cardList){
                if(i.CardName.Contains(searchCardName)){
                    Console.WriteLine("============================");
                    Console.WriteLine("Card Info:");
                    Console.WriteLine("============================");
                    i.PrintCardInfo();
                    Console.WriteLine();
                    search = true;
                }
            }
            if(search == false){
                Console.WriteLine("Card Not Found\n");
            }
        }
        /// <summary>
        /// This is a method to print the inventory.
        /// </summary>
        public void PrintInventory(){
            Console.WriteLine("============================");
            Console.WriteLine("Inventory:");
            Console.WriteLine("============================");
            foreach(Item i in cardList){
                i.PrintCardInfo();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// This is a method to print sort inventory.
        /// </summary>
        /// <param name="sortBy"></param>
        public void PrintSortInventory(string sortBy){
            Console.WriteLine("============================");
            Console.WriteLine("Sorted Inventory:");
            Console.WriteLine("============================");
            if(sortBy == "Name"){
                List<Item> sortList = cardList.OrderBy(item => item.CardName).ToList();
                foreach(Item i in sortList){
                    i.PrintCardInfo();
                    Console.WriteLine();
                }
            } else if(sortBy == "Color"){
                List<Item> sortList = cardList.OrderBy(item => item.CardColor).ToList();
                foreach(Item i in sortList){
                    i.PrintCardInfo();
                    Console.WriteLine();
                }
            } else if(sortBy == "Rarity"){
                List<Item> sortList = cardList.OrderBy(item => item.CardRarity).ToList();
                foreach(Item i in sortList){
                    i.PrintCardInfo();
                    Console.WriteLine();
                }
            } else if(sortBy == "Foil"){
                List<Item> sortList = cardList.OrderBy(item => item.CardFoil).ToList();
                foreach(Item i in sortList){
                    i.PrintCardInfo();
                    Console.WriteLine();
                }
            } else if(sortBy == "Price"){
                List<Item> sortList = cardList.OrderBy(item => item.CardPrice).ToList();
                foreach(Item i in sortList){
                    i.PrintCardInfo();
                    Console.WriteLine();
                }
            } else if(sortBy == "Quantity"){
                List<Item> sortList = cardList.OrderBy(item => item.CardQuantity).ToList();
                foreach(Item i in sortList){
                    i.PrintCardInfo();
                    Console.WriteLine();
                }
            } else if(sortBy == "Promotion"){
                List<Item> sortList = cardList.OrderBy(item => item.PromotionItem).ToList();
                foreach(Item i in sortList){
                    i.PrintCardInfo();
                    Console.WriteLine();
                }
            } else if(sortBy == "SeriesNo"){
                List<Item> sortList = cardList.OrderBy(item => item.SeriesNo).ToList();
                foreach(Item i in sortList){
                    i.PrintCardInfo();
                    Console.WriteLine();
                }
            }
        }
        /// <summary>
        /// This is a method to filter the inventory.
        /// </summary>
        /// <param name="il"></param>
        public void Filter(){
            Console.WriteLine("Filter by:");
            Console.WriteLine("(1)Rarity");
            Console.WriteLine("(2)Foil");
            Console.WriteLine("(3)Promotion");
            Console.Write("Choose an option: ");
            string filter = Console.ReadLine();
            Console.WriteLine();
            if(filter == "1"){
                Console.Write("Rarity(1)Common, (2)Uncommon, (3)Rare: ");
                string filterRare = Console.ReadLine().Trim();
                if(filterRare == "1"){
                    foreach(Item i in cardList){
                        if(i.CardRarity == Rarity.Common){
                            i.PrintCardInfo();
                            Console.WriteLine();
                        }
                    }
                } else if(filterRare == "2"){
                    foreach(Item i in cardList){
                        if(i.CardRarity == Rarity.Uncommon){
                            i.PrintCardInfo();
                            Console.WriteLine();
                        }
                    }
                } else if(filterRare == "3"){
                    foreach(Item i in cardList){
                        if(i.CardRarity == Rarity.Rare){
                            i.PrintCardInfo();
                            Console.WriteLine();
                        }
                    }
                } else {
                    Console.WriteLine("Invalid input\n");
                }
            } else if(filter == "2"){
                Console.Write("Foil(1)Yes, (2)No: ");
                string filterFoil = Console.ReadLine().Trim();
                if(filterFoil == "1"){
                    foreach(Item i in cardList){
                        if(i.CardFoil == true){
                            i.PrintCardInfo();
                            Console.WriteLine();
                        }
                    }
                } else if(filterFoil == "2"){
                    foreach(Item i in cardList){
                        if(i.CardFoil == false){
                            i.PrintCardInfo();
                            Console.WriteLine();
                        }
                    }
                } else {
                    Console.WriteLine("Invalid input\n");
                }
            } else if(filter == "3"){
                Console.Write("Promotion(1)Yes, (2)No: ");
                string filterPromo = Console.ReadLine().Trim();
                if(filterPromo == "1"){
                    foreach(Item i in cardList){
                        if(i.CardFoil == true){
                            i.PrintCardInfo();
                            Console.WriteLine();
                        }
                    }
                } else if(filterPromo == "2"){
                    foreach(Item i in cardList){
                        if(i.CardFoil == false){
                            i.PrintCardInfo();
                            Console.WriteLine();
                        }
                    }
                } else {
                    Console.WriteLine("Invalid input\n");
                }
            } else {
                Console.WriteLine("Invalid input\n");
            }
        }
        /// <summary>
        /// This is a c# indexer which will return an item object from list.
        /// </summary>
        /// <value></value>
        public Item this[int i]{
            get{return cardList[i];}
        }

    }
    
}