using System;
using System.Collections.Generic;

namespace PassTask13
{
    public class Admin:User
    {
        /// <summary>
        ///  This is a constructer to build an Admin object which is a child to User and it accepts adID and adPass.
        /// </summary>
        /// <param name="adID"></param>
        /// <param name="adPass"></param>
        /// <returns></returns>
        public Admin(string adID, string adPass):base(adID, adPass){}
        public override string Menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("(1)Manage customer");
            Console.WriteLine("(2)Manage inventory");
            Console.WriteLine("(3)Manage booking");
            Console.WriteLine("(4)Transaction");
            Console.WriteLine("(5)View Transaction");
            Console.WriteLine("(6)Log out");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine().Trim();
            Console.WriteLine();
            return option;
        }
        /// <summary>
        /// This is a method where the admin can choose options on managing the customers.
        /// </summary>
        /// <param name="cl"></param>
        public void ManageCustomer(CustomerList cl, BookingList bl){
            Console.WriteLine("(1)Add customer");
            Console.WriteLine("(2)Remove customer");
            Console.WriteLine("(3)Edit customer");
            Console.WriteLine("(4)Update membership");
            Console.WriteLine("(5)Search customer");
            Console.WriteLine("(6)View customer base");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine().Trim();
            Console.WriteLine();
            if(option == "1"){
                AddCust(cl);
            } else if(option == "2"){
                DeleteCust(cl,bl);
            } else if (option == "3"){
                EditCust(cl);
            } else if (option == "4"){
                UpdateCustMember(cl);
            } else if (option == "5"){
                Console.Write("Search by(1)Customer ID, (2)Customer Name: ");
                string choice = Console.ReadLine().Trim();
                if(choice == "1"){
                    cl.SearchCustIDFromList();
                } else if(choice == "2"){
                    cl.SearchCustNameFromList();
                } else {
                    Console.WriteLine("Invalid Input\n");
                }
            } else if (option == "6"){
                cl.PrintCustBase();
            } else {
                Console.WriteLine("Invalid Input\n");
            }
        }
        /// <summary>
        /// This is a method where the admin can choose options on managing the inventory.
        /// </summary>
        /// <param name="il"></param>
        public void ManageInventory(ItemList il){
            Console.WriteLine("(1)Add stock");
            Console.WriteLine("(2)Remove stock");
            Console.WriteLine("(3)Replenish stock");
            Console.WriteLine("(4)Edit item");
            Console.WriteLine("(5)Search item");
            Console.WriteLine("(6)Filter");
            Console.WriteLine("(7)View item");
            Console.WriteLine("(8)Sort inventory");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine().Trim();
            Console.WriteLine();
            if(option == "1"){
                AddItem(il);
            } else if(option == "2"){
                RemoveItem(il);
            } else if(option == "3"){
                ReplenishItem(il);
            } else if(option == "4"){
                EditItem(il);
            } else if(option == "5"){
                Console.Write("Search by(1)Item Series No, (2)Item Name: ");
                string choice = Console.ReadLine().Trim();
                if(choice == "1"){
                    il.SearchItemIDFromList();
                } else if(choice == "2"){
                    il.SearchItemNameFromList();
                } else {
                    Console.WriteLine("Invalid Input\n");
                }
            } else if(option == "6"){
                il.Filter();
            } else if(option == "7"){
                il.PrintInventory();
            } else if(option == "8"){
                SortInventory(il);
            } else {
                Console.WriteLine("Invalid input\n");
            }
        }
        /// <summary>
        /// This is a method where allows admin to handle transactions for both member and non-member.
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="il"></param>
        /// <param name="tl"></param>
        public void ManageTransaction(CustomerList cl, ItemList il, TransactionList tl){
            Console.Write("Customer status(1)Member, (2)Non-Member: ");
            string customerStatus = Console.ReadLine().Trim();
            if(customerStatus == "1"){
                MemberTransaction(cl, il, tl);
            } else if(customerStatus == "2"){
                NonMemberTransaction(il, tl);
            } else {
                Console.WriteLine("Invalid Input\n");
            }
        }
        /// <summary>
        /// This is a method where the admin can choose options on managing the booking.
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="gl"></param>
        /// <param name="cl"></param>
        public void ManageBooking(BookingList bl, GamesList gl, CustomerList cl){
            Console.WriteLine("(1)Add Booking");
            Console.WriteLine("(2)Cancel Booking");
            Console.WriteLine("(3)Edit Booking");
            Console.WriteLine("(4)View Booking");
            Console.WriteLine("(5)View Ongoing Booking");
            Console.WriteLine("(6)Search Booking");
            Console.WriteLine("(7)Add Games");
            Console.WriteLine("(8)Remove Games");
            Console.WriteLine("(9)Search Games");
            Console.WriteLine("(10)Games List");
            Console.WriteLine("(11)Sort Games List");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine().Trim();
            Console.WriteLine();
            if(option == "1"){
                AddBooking(bl, gl, cl);
            } else if(option == "2"){
                CancelBooking(bl);
            } else if(option == "3"){
                EditBooking(bl);
            } else if(option == "4"){
                bl.PrintBooking();
            } else if(option == "5"){
                bl.PrintOngoingBooking();
            } else if(option == "6"){
                Console.Write("Search by(1)Booking ID, (2)Customer ID: ");
                string choice = Console.ReadLine().Trim();
                if(choice == "1"){
                    bl.SearchBookIDFromList();
                } else if(choice == "2"){
                    bl.SearchBookingUsingCustIDFromList();
                } else {
                    Console.WriteLine("Invalid Input\n");
                }
            } else if(option == "7"){
                AddGames(gl);  
            } else if(option == "8"){
                RemoveGames(gl, bl);
            } else if(option == "9"){
                Console.Write("Search by(1)Game ID, (2)Game Name: ");
                string choice = Console.ReadLine().Trim();
                if(choice == "1"){
                    gl.SearchGameIDFromList(bl);
                } else if(choice == "2"){
                    gl.SearchGameNameFromList();
                } else {
                    Console.WriteLine("Invalid Input\n");
                }
            } else if(option == "10"){
                gl.PrintGamesList();
            } else if(option == "11"){
                SortGames(gl);
            } else {
                Console.WriteLine("Invalid Input\n");
            }
            
        }
        /// <summary>
        /// This is a method which allows admin to add customer into the customer list.
        /// </summary>
        /// <param name="cl"></param>
        public void AddCust(CustomerList cl){
            Console.Write("Enter Customer ID: ");
            string inputID = Console.ReadLine().Trim();
            bool added = true;
            foreach(Customer c in cl.CustList){
                if(c.CustID == inputID){
                    Console.WriteLine("ID used\n");
                    added = false;
                }
            }
            if(added == true){
                Console.Write("Enter Customer Name: ");
                string inputName = Console.ReadLine().Trim();
                Console.Write("Enter Customer Phone Number: ");
                string inputPhone = Console.ReadLine().Trim();
                if(inputID == "" || inputPhone == "" || inputName == ""){
                    Console.WriteLine("Cannot be empty\n");
                } else {
                    Customer newCust = new Customer(inputID, inputName, inputPhone);
                    Console.WriteLine("Please pay RM20 to start membership");
                    Console.Write("Enter Amount(RM):");
                    double payment;
                    string amount  = Console.ReadLine().Trim();
                    bool validInput = double.TryParse(amount, out payment);
                    if(validInput){
                        if(payment<20){
                            Console.WriteLine("Invalid Amount\n");
                        } else {
                            double change = payment - 20;
                            Console.WriteLine("Change(RM): " + change);
                            Console.WriteLine("Membership valid: " + DateTime.Now + " till " + DateTime.Now.AddYears(1) + "\n");
                            newCust.UpdateCustMembership();
                            cl.AddCustIntoList(newCust);
                        }
                    } else {
                        Console.WriteLine("Invalid Input\n");
                    }
                }
            }
        }
        /// <summary>
        /// This is a method which allows admin to delete customer from the customer list.
        /// </summary>
        /// <param name="cl"></param>
        public void DeleteCust(CustomerList cl, BookingList bl){
            Console.Write("Enter deleted Customer ID:");
            string deleteID = Console.ReadLine().Trim(); 
            bool deleted = false;
            for(int i = 0; i < cl.CustTotal; i++){
                if(cl[i].CustID == deleteID){
                    Console.WriteLine("============================");
                    Console.WriteLine("Cancelled Booking:");
                    Console.WriteLine("============================");
                    for(int k = 0; k < bl.BookTotal; k++){
                        if(bl[k].BookCustID == deleteID){
                            bl[k].PrintBookingInfo();
                            bl.RemoveBooking(bl[k]);
                            Console.WriteLine("Return(RM): " + bl[k].BookDuration * 5);
                            Console.WriteLine();
                        }
                    }
                    cl.DeleteCustFromList(cl[i]);
                    deleted = true;
                }
            }
            if(deleted == false){
                Console.WriteLine("User Not Found\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to edit customer from the customer list.
        /// </summary>
        /// <param name="cl"></param>
        public void EditCust(CustomerList cl){
            Console.Write("Enter Customer ID:");
            string editID = Console.ReadLine().Trim();
            bool edited = false;
            foreach(Customer c in cl.CustList){
                if(c.CustID == editID){
                    Console.Write("Edit new phone number:");
                    string editphone = Console.ReadLine().Trim();
                    if(editphone == ""){
                        Console.WriteLine("Cannot be empty\n");
                    } else {
                        cl.EditCustFromList(c, editphone);
                        edited = true;
                    }
                }
            }
            if(edited == false){
                Console.WriteLine("User Not Found\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to update customer's membership.
        /// </summary>
        /// <param name="cl"></param>
        public void UpdateCustMember(CustomerList cl){
            Console.Write("Enter Customer ID:");
            string targetID = Console.ReadLine().Trim();
            bool updated = false;
            foreach(Customer c in cl.CustList){
                if(c.CustID == targetID){
                    c.CheckValid(DateTime.Now);
                    if(c.ValidMembership == true){
                        updated = true;
                        Console.WriteLine("You have a valid Membership\n");
                    } else {
                        Console.WriteLine("Please pay RM20 to renew membership");
                        Console.Write("Enter Amount(RM):");
                        double payment;
                        string amount  = Console.ReadLine().Trim();
                        bool validInput = double.TryParse(amount, out payment);
                        if(validInput){
                            if(payment<20){
                                Console.WriteLine("Invalid Amount\n");
                            } else {
                                double change = payment - 20;
                                Console.WriteLine("Change(RM): " + change);
                                Console.WriteLine("Membership valid: " + DateTime.Now + " till " + DateTime.Now.AddYears(1));
                                c.UpdateCustMembership();
                                Console.WriteLine("Renew successfully\n");
                            }
                        } else {
                            Console.WriteLine("Invalid Input\n");
                        }
                    }
                }
            }
            if(updated == false){
                Console.WriteLine("User Not Found\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to add item into the item list.
        /// </summary>
        /// <param name="il"></param>
        public void AddItem(ItemList il){
            Console.Write("Enter card Series No: ");
            string inputCardNo = Console.ReadLine().Trim();
            bool added = true;
            foreach(Item i in il.CardList){
                if(i.SeriesNo == inputCardNo){
                    Console.WriteLine("Card Series No used\n");
                    added = false;
                }
            }
            if(added == true){
                bool validItem = true;
                bool similarItem = false;
                Console.Write("Enter Card Name: ");
                string inputCardName = Console.ReadLine().Trim();
                Console.Write("Enter Card Color: ");
                string inputCardColor = Console.ReadLine().Trim();
                if(inputCardName == "" || inputCardNo == "" || inputCardColor == ""){
                    validItem = false;
                }
                Console.Write("Enter Price(RM): ");
                double inputCardPrice;
                string cPrice = Console.ReadLine().Trim();
                bool validInput = double.TryParse(cPrice, out inputCardPrice);
                if(!validInput){
                    validItem = false;
                }
                if(inputCardPrice<=0){
                    validItem = false;
                }
                Console.Write("Enter Quantity: ");
                int inputCardQuantity;
                string cQuantity = Console.ReadLine().Trim();
                validInput = Int32.TryParse(cQuantity, out inputCardQuantity);
                if(!validInput){
                    validItem = false;
                }
                if(inputCardQuantity<=0){
                    validItem = false;
                }

                while(validItem){
                    Console.Write("Choose Rarity(1)Common, (2)Uncommon, (3)Rare: ");
                    string inputRare = Console.ReadLine().Trim();
                    Rarity inputCardRare;

                    if(inputRare == "1"){
                        inputCardRare = Rarity.Common;
                        Console.Write("Card Foil(1)Yes, (2)No: ");
                        string inputFoil = Console.ReadLine().Trim();
                        bool inputCardFoil;
                        if(inputFoil == "1"){
                            inputCardFoil = true;
                            Console.Write("Promotion Item(1)Yes, (2)No: ");
                            string inputPromo = Console.ReadLine().Trim();
                            bool inputCardPromo;

                            if(inputPromo == "1"){
                                inputCardPromo = true;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else if(inputPromo == "2"){
                                inputCardPromo = false;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else {
                                validItem = false;
                            }
                        } else if(inputFoil == "2"){
                            inputCardFoil = false;
                            Console.Write("Promotion Item(1)Yes, (2)No: ");
                            string inputPromo = Console.ReadLine().Trim();
                            bool inputCardPromo;

                            if(inputPromo == "1"){
                                inputCardPromo = true;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else if(inputPromo == "2"){
                                inputCardPromo = false;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else {
                                validItem = false;
                            }
                        } else {
                            validItem = false;
                        }

                    } else if(inputRare == "2"){
                        inputCardRare = Rarity.Uncommon;
                        inputCardRare = Rarity.Common;
                        Console.Write("Card Foil(1)Yes, (2)No: ");
                        string inputFoil = Console.ReadLine().Trim();
                        bool inputCardFoil;
                        if(inputFoil == "1"){
                            inputCardFoil = true;
                            Console.Write("Promotion Item(1)Yes, (2)No: ");
                            string inputPromo = Console.ReadLine().Trim();
                            bool inputCardPromo;

                            if(inputPromo == "1"){
                                inputCardPromo = true;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else if(inputPromo == "2"){
                                inputCardPromo = false;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else {
                                validItem = false;
                            }
                        } else if(inputFoil == "2"){
                            inputCardFoil = false;
                            Console.Write("Promotion Item(1)Yes, (2)No: ");
                            string inputPromo = Console.ReadLine().Trim();
                            bool inputCardPromo;

                            if(inputPromo == "1"){
                                inputCardPromo = true;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else if(inputPromo == "2"){
                                inputCardPromo = false;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else {
                                validItem = false;
                            }
                        } else {
                            validItem = false;
                        }

                    } else if(inputRare == "3"){
                        inputCardRare = Rarity.Rare;
                        inputCardRare = Rarity.Common;
                        Console.Write("Card Foil(1)Yes, (2)No: ");
                        string inputFoil = Console.ReadLine().Trim();
                        bool inputCardFoil;
                        if(inputFoil == "1"){
                            inputCardFoil = true;
                            Console.Write("Promotion Item(1)Yes, (2)No: ");
                            string inputPromo = Console.ReadLine().Trim();
                            bool inputCardPromo;

                            if(inputPromo == "1"){
                                inputCardPromo = true;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else if(inputPromo == "2"){
                                inputCardPromo = false;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else {
                                validItem = false;
                            }
                        } else if(inputFoil == "2"){
                            inputCardFoil = false;
                            Console.WriteLine("Promotion Item(1)Yes, (2)No: ");
                            string inputPromo = Console.ReadLine().Trim();
                            bool inputCardPromo;

                            if(inputPromo == "1"){
                                inputCardPromo = true;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else if(inputPromo == "2"){
                                inputCardPromo = false;
                                Item newItem = new Item(inputCardNo, inputCardName, inputCardColor, inputCardRare, inputCardFoil, inputCardPrice, inputCardQuantity, inputCardPromo);
                                if(il.SearchSimilar(newItem)){
                                    similarItem = true;
                                } else {
                                    il.AddItemIntoList(newItem);
                                }
                                break;
                            } else {
                                validItem = false;
                            }
                        } else {
                            validItem = false;
                        }

                    } else {
                        validItem = false;
                    }
                }
                if(validItem == false){
                    Console.WriteLine("Unable to build item due to invalid inputs\n");
                }
                if(similarItem == true){
                    Console.WriteLine("Unable to build object due to similar item found\n");
                }  
            }
        }
        /// <summary>
        /// This is a method which allows admin to remove item from itemList.
        /// </summary>
        /// <param name="il"></param>
        public void RemoveItem(ItemList il){
            Console.Write("Enter Series No: ");
            string deleteSeries = Console.ReadLine().Trim(); 
            bool deleted = false;
            for(int i = 0; i < il.ItemTotal; i++){
                if(il[i].SeriesNo == deleteSeries){
                    il.RemoveItemFromList(il[i]);
                    deleted = true;
                }
            }
            if(deleted == false){
                Console.WriteLine("Item Not Found\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to edit item from itemList.
        /// </summary>
        /// <param name="il"></param>
        public void EditItem(ItemList il){
            Console.Write("Enter Series No: ");
            string editSeries = Console.ReadLine().Trim(); 
            bool edited = false;
            foreach(Item i in il.CardList){
                if(i.SeriesNo == editSeries){
                    Console.Write("Edit(1)Name, (2)Color, (3)Rarity, (4)Foil, (5)Price, (6)Quantity, (7)Promotion: ");
                    string option = Console.ReadLine().Trim();
                    if(option == "1"){
                        il.EditItemFromList(i, "Name");
                    } else if(option == "2"){
                        il.EditItemFromList(i, "Color");
                    } else if(option == "3"){
                        il.EditItemFromList(i, "Rarity");
                    } else if(option == "4"){
                        il.EditItemFromList(i, "Foil");
                    } else if(option == "5"){
                        il.EditItemFromList(i, "Price");
                    } else if(option == "6"){
                        il.EditItemFromList(i, "Quantity");
                    } else if(option == "7"){
                        il.EditItemFromList(i, "Promotion");
                    }
                    edited = true;
                }
            }
            if(edited == false){
                Console.WriteLine("Item Not Found\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to replenish item from itemList.
        /// </summary>
        /// <param name="il"></param>
        public void ReplenishItem(ItemList il){
            Console.Write("Enter Series No: ");
            string replenishSeries = Console.ReadLine().Trim(); 
            bool replenished = false;
            foreach(Item i in il.CardList){
                if(i.SeriesNo == replenishSeries){
                    Console.Write("Enter amount: ");
                    int inputReplenishQuantity;
                    string rQuantity = Console.ReadLine().Trim();
                    bool validInput = Int32.TryParse(rQuantity, out inputReplenishQuantity);
                    if(!validInput){
                        Console.WriteLine("Invalid Input");
                    } else {
                        if(inputReplenishQuantity <= 0){
                            Console.WriteLine("Invalid Amount\n");
                        } else {
                            il.ReplenishItemFromList(i, inputReplenishQuantity);
                        }
                        replenished = true;
                    }
                }
            }
            if(replenished == false){
                Console.WriteLine("Item Not Found\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to print a sorted inventory.
        /// </summary>
        /// <param name="il"></param>
        public void SortInventory(ItemList il){
            Console.Write("Sorted By(1)Series No, (2)Name, (3)Color, (4)Rarity, (5)Foil, (6)Price, (7)Quantity, (8)Promotion: ");
            string sortOption = Console.ReadLine().Trim(); 
            if(sortOption == "1"){
                il.PrintSortInventory("SeriesNo");
            } else if(sortOption == "2"){
                il.PrintSortInventory("Name");
            } else if(sortOption == "3"){
                il.PrintSortInventory("Color");
            } else if(sortOption == "4"){
                il.PrintSortInventory("Rarity");
            } else if(sortOption == "5"){
                il.PrintSortInventory("Foil");
            } else if(sortOption == "6"){
                il.PrintSortInventory("Price");
            } else if(sortOption == "7"){
                il.PrintSortInventory("Quantity");
            } else if(sortOption == "8"){
                il.PrintSortInventory("Promotion");
            } else {
                Console.WriteLine("Invalid input\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to handle a transaction with a member customer.
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="il"></param>
        /// <param name="tl"></param>
        public void MemberTransaction(CustomerList cl, ItemList il, TransactionList tl){
            Console.Write("Enter Customer ID: ");
            bool verifyCust = false;
            bool custValidMember = false;
            string inputCustID = Console.ReadLine().Trim();
            for(int i = 0; i < cl.CustTotal; i++){
                if(cl[i].CustID == inputCustID){
                    verifyCust = true;
                    int testDate = DateTime.Compare(DateTime.Now,cl[i].DateEnd);
                    if(testDate <= 0){
                        custValidMember = true;
                    } else {
                        custValidMember = false;
                    }
                }
            }
            if(verifyCust == true){
                Transaction newTransaction = new Transaction(true);
                while(true){
                    il.PrintInventory();
                    Console.WriteLine("Cart item: " + newTransaction.ItemTransTotal);
                    Console.WriteLine("Total Spent(RM): " + newTransaction.TotalSpent);
                    Console.Write("Enter Command(add [Series No],delete,finish,close): ");
                    string transCommand = Console.ReadLine().Trim();
                    if(transCommand.Length <= 3){
                        transCommand = "Invalid input";
                    }
                    string transOption = transCommand.Substring(0, 3);
                    string transSeriesNo;
                    if(transCommand.Length > 3){
                        transSeriesNo = transCommand.Substring(4);
                    } else {
                        transSeriesNo = "";
                    }
                    if(transOption == "add"){
                        bool addedTrans = false;
                        for(int i = 0; i < il.ItemTotal; i++){
                            if(il[i].SeriesNo == transSeriesNo){
                                if(il[i].CardQuantity == 0){
                                    Console.WriteLine("Out of stock\n");
                                    addedTrans = true;
                                } else {
                                    il[i].CardQuantity -= 1;
                                    newTransaction.AddBuy(il[i]);
                                    newTransaction.UpdateSpent(custValidMember);
                                    addedTrans = true;
                                }
                            }
                        }
                        if(addedTrans == false){
                            Console.WriteLine("Item Not Found\n");
                        }
                    } else if(transOption == "del"){
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Cart:");
                        Console.WriteLine("----------------------------");
                        foreach(Item i in newTransaction.BuyList){
                            i.PrintCardInfoTrans();
                            Console.WriteLine();
                        }
                        Console.WriteLine("Total Spent(RM): " + newTransaction.TotalSpent);
                        Console.WriteLine("Discount(RM): " + newTransaction.TotalDiscount);
                        bool deletedTrans = false;
                        Console.WriteLine("Enter series No: ");
                        string deleteCard = Console.ReadLine().Trim();
                        for(int i = 0; i < newTransaction.ItemTransTotal; i++){
                            if(newTransaction[i].SeriesNo == deleteCard){
                                for(int t = 0; t < il.ItemTotal; t++){
                                    if(il[t].SeriesNo == newTransaction[t].SeriesNo){
                                        il[t].CardQuantity += 1;
                                    }
                                }
                                newTransaction.RemoveBuy(newTransaction[i]);
                                newTransaction.UpdateSpent(custValidMember);
                                deletedTrans = true;
                            }
                        }
                        if(deletedTrans == false){
                            Console.WriteLine("Item Not Found\n");
                        }
                    } else if(transOption == "fin"){
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Final Transaction:");
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Cart:");
                        foreach(Item i in newTransaction.BuyList){
                            i.PrintCardInfoTrans();
                            Console.WriteLine();
                        }
                        Console.WriteLine("Total Spent(RM): " + newTransaction.TotalSpent);
                        Console.WriteLine("Discount(RM): " + newTransaction.TotalDiscount);
                        Console.Write("Enter Amount(RM):");
                        double payment;
                        string amount  = Console.ReadLine().Trim();
                        bool validInput = double.TryParse(amount, out payment);
                        if(validInput){
                            if(payment<newTransaction.TotalSpent){
                                Console.WriteLine("Invalid Amount");
                            } else {
                                double change = payment - newTransaction.TotalSpent;
                                Console.WriteLine("Change(RM): " + change);
                                Console.WriteLine("You have earned: " + Convert.ToInt32((newTransaction.TotalSpent / 20)*10) + " points\n");
                                for(int i = 0; i < cl.CustTotal; i++){
                                    if(cl[i].CustID == inputCustID){
                                        newTransaction.TransDate = DateTime.Now;
                                        newTransaction.CustIDBought = cl[i].CustID;
                                        newTransaction.CustNameBought = cl[i].CustName;
                                        cl[i].AddTransCust(newTransaction);
                                        cl[i].UpdateTotalPurchases();
                                        cl[i].UpdatePoints();
                                        tl.AddShopTrans(newTransaction);
                                    }
                                }
                                break;
                            }
                        } else {
                            Console.WriteLine("Invalid Input\n");
                        }
                    } else if(transOption == "clo"){
                        foreach(Item i in newTransaction.BuyList){
                            foreach(Item t in il.CardList){
                                if(i.SeriesNo == t.SeriesNo){
                                    t.CardQuantity += 1;
                                }
                            }
                        }
                        break;
                    } else {
                        Console.WriteLine("Invalid input\n");
                    }      
                }

            } else {
                Console.WriteLine("ID not found\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to handle transaction with a non-member customer.
        /// </summary>
        /// <param name="il"></param>
        /// <param name="tl"></param>
        public void NonMemberTransaction(ItemList il, TransactionList tl){
            Transaction newTransaction = new Transaction(false);
            while(true){
                il.PrintInventory();
                Console.WriteLine("Cart item: " + newTransaction.ItemTransTotal);
                Console.WriteLine("Total Spent(RM): " + newTransaction.TotalSpent);
                Console.Write("Enter Command(add [Series No],delete,finish,close): ");
                string transCommand = Console.ReadLine().Trim();
                if(transCommand.Length <= 3){
                    transCommand = "Invalid input";
                }
                string transOption = transCommand.Substring(0, 3);
                string transSeriesNo;
                if(transCommand.Length > 3){
                    transSeriesNo = transCommand.Substring(4);
                } else {
                    transSeriesNo = "";
                }
                if(transOption == "add"){
                    bool addedTrans = false;
                    for(int i = 0; i < il.ItemTotal; i++){
                        if(il[i].SeriesNo == transSeriesNo){
                            if(il[i].CardQuantity == 0){
                                Console.WriteLine("Out of stock");
                                addedTrans = true;
                            } else {
                                il[i].CardQuantity -= 1;
                                newTransaction.AddBuy(il[i]);
                                newTransaction.UpdateSpent(false);
                                addedTrans = true;
                            }
                        }
                    }
                    if(addedTrans == false){
                        Console.WriteLine("Item Not Found\n");
                    }

                } else if(transOption == "del"){
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Cart:");
                    Console.WriteLine("----------------------------");
                    foreach(Item i in newTransaction.BuyList){
                        i.PrintCardInfoTrans();
                        Console.WriteLine();
                    }
                    Console.WriteLine("Total Spent(RM): " + newTransaction.TotalSpent);
                    Console.WriteLine("Discount(RM): " + newTransaction.TotalDiscount);
                    bool deletedTrans = false;
                    Console.WriteLine("Enter series No: ");
                    string deleteCard = Console.ReadLine().Trim();
                    for(int i = 0; i < newTransaction.ItemTransTotal; i++){
                        if(newTransaction[i].SeriesNo == deleteCard){
                            for(int t = 0; t < il.ItemTotal; t++){
                                if(il[t].SeriesNo == newTransaction[t].SeriesNo){
                                    il[t].CardQuantity += 1;
                                }
                            }
                            newTransaction.RemoveBuy(newTransaction[i]);
                            newTransaction.UpdateSpent(false);
                            deletedTrans = true;
                        }
                    }
                    if(deletedTrans == false){
                        Console.WriteLine("Item Not Found\n");
                    }

                } else if(transOption == "fin"){
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Final Transaction:");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Cart:");
                    foreach(Item i in newTransaction.BuyList){
                        i.PrintCardInfoTrans();
                        Console.WriteLine();
                    }
                    Console.WriteLine("Total Spent(RM): " + newTransaction.TotalSpent);
                    Console.WriteLine("Discount(RM): " + newTransaction.TotalDiscount);
                    Console.Write("Enter Amount(RM):");
                    double payment;
                    string amount  = Console.ReadLine().Trim();
                    bool validInput = double.TryParse(amount, out payment);
                    if(validInput){
                        if(payment<newTransaction.TotalSpent){
                            Console.WriteLine("Invalid Amount");
                        } else {
                            double change = payment - newTransaction.TotalSpent;
                            Console.WriteLine("Change(RM): " + change + "\n");
                            newTransaction.TransDate = DateTime.Now;
                            tl.AddShopTrans(newTransaction);
                            break;
                        }
                    } else {
                        Console.WriteLine("Invalid Input\n");
                    }
                } else if(transOption == "clo"){
                    foreach(Item i in newTransaction.BuyList){
                        foreach(Item t in il.CardList){
                            if(i.SeriesNo == t.SeriesNo){
                                t.CardQuantity += 1;
                            }
                        }
                    }
                    break;
                } else {
                    Console.WriteLine("Invalid input\n");
                }      
            }
        }
        /// <summary>
        /// This is a method which allows admin to add game into gameList.
        /// </summary>
        /// <param name="gl"></param>
        public void AddGames(GamesList gl){
            Console.Write("Enter Game ID: ");
            string inputGameID = Console.ReadLine().Trim();
            bool added = true;
            foreach(Games g in gl.GameList){
                if(g.GameID == inputGameID){
                    Console.WriteLine("ID used\n");
                    added = false;
                }
            }
            if(added){
                Console.Write("Enter Game Name: ");
                string inputGameName = Console.ReadLine().Trim();
                if(inputGameID == "" || inputGameName == "" || inputGameID == "cancel"){
                    Console.WriteLine("Cannot be empty\n");
                } else {
                    Games newG = new Games(inputGameID, inputGameName);
                    gl.AddGamesIntoList(newG);
                }
            }
        }
        /// <summary>
        /// This is a method which allows admin to remove game from gameList.
        /// </summary>
        /// <param name="gl"></param>
        /// <param name="bl"></param>
        public void RemoveGames(GamesList gl, BookingList bl){
            Console.Write("Enter Game ID: ");
            string deleteGame = Console.ReadLine().Trim(); 
            bool deleted = false;
            for(int i = 0; i < gl.GameTotal; i++){
                if(gl[i].GameID == deleteGame){
                    gl.RemoveGamesFromList(gl[i]);
                    deleted = true;
                    Console.WriteLine("============================");
                    Console.WriteLine("Cancelled Booking:");
                    Console.WriteLine("============================");
                    for(int k = 0; k < bl.BookTotal; k++){
                        if(bl[k].BookGame.GameID == deleteGame){
                            bl[k].PrintBookingInfo();
                            bl.RemoveBooking(bl[k]);
                            Console.WriteLine("Return(RM): " + bl[k].BookDuration * 5);
                            Console.WriteLine();
                        }
                    }
                }
            }
            if(deleted == false){
                Console.WriteLine("Game Not Found\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to print a sorted gameList.
        /// </summary>
        /// <param name="gl"></param>
        public void SortGames(GamesList gl){
            Console.Write("Sorted By(1)Game ID, (2)Name: ");
            string sortOption = Console.ReadLine().Trim(); 
            if(sortOption == "1"){
                gl.PrintSortGameList("GameID");
            } else if(sortOption == "2"){
                gl.PrintSortGameList("GameName");
            } else {
                Console.WriteLine("Invalid input\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to add a booking object into the bookingList.
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="gl"></param>
        /// <param name="cl"></param>
        public void AddBooking(BookingList bl, GamesList gl, CustomerList cl){
            Console.Write("Enter Customer ID: ");
            bool verifyCust = false;
            string inputCustID = Console.ReadLine().Trim();
            for(int i = 0; i < cl.CustTotal; i++){
                if(cl[i].CustID == inputCustID){
                    verifyCust = true;
                }
            }
            if(verifyCust == true){
                bool done = false;
                while(!done){
                    gl.PrintGamesList();
                    Console.Write("Enter Game ID [cancel to close booking]: ");
                    string custGameID = Console.ReadLine().Trim();
                    if(custGameID == "cancel"){
                        Console.WriteLine("Cancelled\n");
                        break;
                    } else {
                        bool found = false;
                        foreach(Games g in gl.GameList){
                            if(g.GameID == custGameID){
                                found = true;
                                Console.Write("Enter year: ");
                                int year;
                                string inputYear  = Console.ReadLine().Trim();
                                bool validYear = int.TryParse(inputYear, out year);
                                Console.Write("Enter month: ");
                                int month;
                                string inputMonth  = Console.ReadLine().Trim();
                                bool validMonth = int.TryParse(inputMonth, out month);
                                Console.Write("Enter date: ");
                                int date;
                                string inputDate  = Console.ReadLine().Trim();
                                bool validDate = int.TryParse(inputDate, out date);
                                Console.Write("Enter time: ");
                                int time;
                                string inputTime  = Console.ReadLine().Trim();
                                bool validTime = int.TryParse(inputTime, out time);
                                Console.Write("Enter duration(hours): ");
                                int duration;
                                string inputDuration  = Console.ReadLine().Trim();
                                bool validDuration = int.TryParse(inputDuration, out duration);
                                if(validYear && validMonth && validDate && validTime && validDuration){
                                    DateTime startDate = new DateTime(year, month, date, time, 0, 0);
                                    DateTime endDate = startDate.AddHours(duration);
                                    if(startDate < DateTime.Now){
                                        Console.WriteLine("Invalid Date\n");
                                    } else {
                                        bool clash = false;
                                        foreach(Booking b in bl.BookList){
                                            if(b.BookGame.GameID == custGameID){
                                                if(b.CheckClash(startDate,endDate)){
                                                    clash = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if(!clash){
                                            int bookingNumber;
                                            while(true){
                                                bl.ClearHistory();
                                                Random _rdm = new Random();
                                                bookingNumber = _rdm.Next(1000,9999);
                                                bool validBookNo = true;
                                                foreach(Booking b in bl.BookList){
                                                    if(b.BookingNo == bookingNumber){
                                                        validBookNo = false;
                                                    }
                                                }
                                                if(validBookNo){
                                                    break;
                                                }
                                            }
                                            Booking newBook = new Booking(bookingNumber,g, inputCustID, cl.SearchNameUsingID(inputCustID), startDate, duration);
                                            Console.WriteLine("============================");
                                            Console.WriteLine("Booking Information");
                                            Console.WriteLine("============================");
                                            newBook.PrintBookingInfo();
                                            Console.WriteLine("Fee(RM): " + duration*5);
                                            Console.Write("Enter Amount(RM):");
                                            int payment;
                                            string amount  = Console.ReadLine().Trim();
                                            bool validInput = int.TryParse(amount, out payment);
                                            if(validInput){
                                                if(payment<duration*5){
                                                    Console.WriteLine("Invalid Amount");
                                                } else {
                                                    int change = payment - duration*5;
                                                    Console.WriteLine("Change(RM): " + change + "\n");
                                                    bl.AddBooking(newBook);
                                                    done = true;
                                                }
                                            } else {
                                                Console.WriteLine("Invalid Input\n");
                                            }
                                            done = true;

                                        } else {
                                            Console.WriteLine("Time clash\n");
                                        }
                                    }
                                } else {
                                    Console.WriteLine("Invalid Input\n");
                                }
                            }
                        }
                        if(found == false){
                            Console.WriteLine("Game Not Found\n");
                        }
                    }
                }
            } else {
                Console.WriteLine("ID not found\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to cancel booking from bookingList.
        /// </summary>
        /// <param name="bl"></param>
        public void CancelBooking(BookingList bl){
            Console.Write("Enter Booking Number: ");
            int bookNo;
            string inputBookNo  = Console.ReadLine().Trim();
            bool validInput = int.TryParse(inputBookNo, out bookNo);
            if(validInput){
                bool searchBooking = false;
                for(int i = 0; i < bl.BookTotal; i++){
                    if(bl[i].BookingNo == bookNo){
                        searchBooking = true;
                        Console.Write("Enter Customer ID: ");
                        string inputCustID  = Console.ReadLine().Trim();
                        if(bl[i].BookCustID == inputCustID){
                            if(bl[i].CheckCancelBook(DateTime.Now)){
                                bl.RemoveBooking(bl[i]);
                                Console.WriteLine("Cancel successfully\n");
                            } else {
                                Console.WriteLine("Unable to cancel booking\n");
                            }
                        } else {
                            Console.WriteLine("Wrong Customer ID\n");
                        }
                    }
                }
                if(searchBooking == false){
                    Console.WriteLine("Booking Not Found\n");
                }
            } else {
                Console.WriteLine("Invalid Input\n");
            }
        }
        /// <summary>
        /// This is a method which allows admin to edit booking from bookingList.
        /// </summary>
        /// <param name="bl"></param>
        public void EditBooking(BookingList bl){
            Console.Write("Enter Booking Number: ");
            int bookNo;
            string inputBookNo  = Console.ReadLine().Trim();
            bool validInput = int.TryParse(inputBookNo, out bookNo);
            if(validInput){
                bool searchBooking = false;
                for(int i = 0; i < bl.BookTotal; i++){
                    if(bl[i].BookingNo == bookNo){
                        searchBooking = true;
                        Console.Write("Enter Customer ID: ");
                        string inputCustID  = Console.ReadLine().Trim();
                        if(bl[i].BookCustID == inputCustID){
                            Console.Write("Enter year: ");
                            int year;
                            string inputYear  = Console.ReadLine().Trim();
                            bool validYear = int.TryParse(inputYear, out year);
                            Console.Write("Enter month: ");
                            int month;
                            string inputMonth  = Console.ReadLine().Trim();
                            bool validMonth = int.TryParse(inputMonth, out month);
                            Console.Write("Enter date: ");
                            int date;
                            string inputDate  = Console.ReadLine().Trim();
                            bool validDate = int.TryParse(inputDate, out date);
                            Console.Write("Enter time: ");
                            int time;
                            string inputTime  = Console.ReadLine().Trim();
                            bool validTime = int.TryParse(inputTime, out time);
                            if(validYear && validMonth && validDate && validTime){
                                DateTime startDate = new DateTime(year, month, date, time, 0, 0);
                                DateTime endDate = startDate.AddHours(bl[i].BookDuration);
                                if(startDate < DateTime.Now){
                                    Console.WriteLine("Invalid Date\n");
                                } else {
                                    bool clash = false;
                                    BookingList previewBook = new BookingList();
                                    foreach(Booking b in bl.BookList){
                                        previewBook.AddBooking(b);
                                    }
                                    previewBook.RemoveBooking(bl[i]);
                                    foreach(Booking b in previewBook.BookList){
                                        if(b.BookGame.GameID == bl[i].BookGame.GameID){
                                            if(b.CheckClash(startDate,endDate)){
                                                clash = true;
                                                break;
                                            }
                                        }
                                    }
                                    if(!clash){
                                        bl[i].StartTime = startDate;
                                        bl[i].EndTime = startDate.AddHours(bl[i].BookDuration);
                                        Console.WriteLine("Editted successfully\n");
                                        Console.WriteLine("============================");
                                        Console.WriteLine("Editted Booking Information:");
                                        Console.WriteLine("============================");
                                        bl[i].PrintBookingInfo();
                                        Console.WriteLine();
                                    } else {
                                        Console.WriteLine("Time clash\n");
                                    }
                                }

                            } else {
                                Console.WriteLine("Invalid Input\n");
                            }

                        } else {
                            Console.WriteLine("Wrong Customer ID\n");
                        }
                    }
                }
                if(searchBooking == false){
                    Console.WriteLine("Booking Not Found\n");
                }
            } else {
                Console.WriteLine("Invalid Input\n");
            }
        }
    }
}