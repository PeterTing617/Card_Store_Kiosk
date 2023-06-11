using System;
using System.Collections.Generic;

namespace PassTask13{
    public class Sales{
        private DateTime _date;
        private List<ItemCount> _itemC;
        private double _earned;
        /// <summary>
        /// This is a constructer to construct a Sales object which accepts d.
        /// </summary>
        /// <param name="d"></param>
        public Sales(DateTime d){
            _date = d;
            _itemC = new List<ItemCount>();
            _earned = 0;
        }
        /// <summary>
        /// This is a property to get or set the value of _date.
        /// </summary>
        /// <value></value>
        public DateTime _Date{
            get{return _date;}
            set{_date = value;}
        }
        /// <summary>
        /// This is a property to get or set the value of _itemC.
        /// </summary>
        /// <value></value>
        public List<ItemCount> _ItemC{
            get{return _itemC;}
            set{_itemC = value;}
        }
        /// <summary>
        /// This is a property to get or set the value of _earned.
        /// </summary>
        /// <value></value>
        public double _Earned{
            get{return _earned;}
            set{_earned = value;}
        }
        /// <summary>
        /// This is a method to add an ItemCount object into the list, _itemC where it will check for similarities.
        /// </summary>
        /// <param name="ic"></param>
        public void AddIC(ItemCount ic){
            bool similar = false;
            foreach(ItemCount l in _itemC){
                if(l._Item.SeriesNo == ic._Item.SeriesNo && l._Item.CardName == ic._Item.CardName && l._Item.CardColor == ic._Item.CardColor && l._Item.CardRarity == ic._Item.CardRarity && l._Item.CardFoil == ic._Item.CardFoil){
                    l._Count += 1;
                    similar = true;
                }
            }
            if(!similar){
                _itemC.Add(ic);
            }

        }
    }
}