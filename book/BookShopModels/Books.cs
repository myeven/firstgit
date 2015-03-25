using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//|5|1|a|s|p|x
namespace BookShopModels
{
   public  class Books
    {
        private int _id;
        private string _title;
        private string _author;
        private Publishers _publishers;
        private DateTime _publishdate;
        private string _isbn;
        private int _wordscount;
        private decimal _unitprice;
        private string _contentdescription;
        private string _aurhordescription;
        private string _editorcomment;
        private string _toc;
        private Categories _categories;
        private int _clicks;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }
        public Publishers Publishers
        {
            get
            {
                return _publishers;
            }
            set
            {
                _publishers = value;
            }
        }
        public DateTime PublishDate
        {
            get
            {
                return _publishdate;
            }
            set
            {
                _publishdate = value;
            }
        }
        public string ISBN
        {
            get
            {
                return _isbn;
            }
            set
            {
                _isbn = value;
            }
        }
        public int WordsCount
        {
            get
            {
                return _wordscount;
            }
            set
            {
                _wordscount = value;
            }
        }
        public decimal UnitPrice
        {
            get
            {
                return _unitprice;
            }
            set
            {
                _unitprice = value;
            }
        }
        public string ContentDescription
        {
            get
            {
                return _contentdescription;
            }
            set
            {
                _contentdescription = value;
            }
        }
        public string AuthorDescription
        {
            get
            {
                return _aurhordescription;
            }
            set
            {
                _aurhordescription = value;
            }
        }
        public string EditorComment
        {
            get
            {
                return _editorcomment;
            }
            set
            {
                _editorcomment = value;
            }
        }
        public string TOC
        {
            get
            {
                return _toc;
            }
            set
            {
                _toc = value;
            }
        }
        public Categories Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
            }
        }
        public int Clicks
        {
            get
            {
                return _clicks;
            }
            set
            {
                _clicks = value;
            }
        }
    }
}
