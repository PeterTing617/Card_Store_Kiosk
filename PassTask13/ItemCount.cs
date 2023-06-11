using System;

namespace PassTask13{
    public class ItemCount{
        private Item _item;
        private int _count;
        /// <summary>
        /// This is a constructer to construct an ItemCount object which accepts i.
        /// </summary>
        /// <param name="i"></param>
        public ItemCount(Item i){
            _item = i;
            _count = 1;
        }
        /// <summary>
        /// This is a property to get or set the value of _item.
        /// </summary>
        /// <value></value>
        public Item _Item{
            get{return _item;}
            set{_item = value;}
        }
        /// <summary>
        /// This is a property to get or set the value of _count.
        /// </summary>
        /// <value></value>
        public int _Count{
            get{return _count;}
            set{_count = value;}
        }
    }
}