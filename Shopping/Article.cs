namespace Shopping
{
    public class Article
    {
        #region private attributes
        private int _id;
        private string _description = "";
        private float _price = 0f;
        #endregion private attributes

        #region public methods
        public Article(int id, string description, float price)
        {
            _id = id;
            _description = description;
            _price = price;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                CheckDescription(value);
                _description = value;
            }
        }

        public float Price
        {
            get
            {
                return _price;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion public methods

        #region private methods
        private bool CheckDescription(string descriptionToCheck)
        {
            char[] specialChars = { '!', '*', '+', '/' };
            bool find = false;
            foreach (char specialChar in specialChars)
            {
                if (descriptionToCheck.Contains(specialChar))
                {
                    find = true;
                }
            }
            if (find)
            {
                throw new SpecialCharInDescriptionException();
            }

            if (descriptionToCheck.Split(' ').Length == 1)
            {
                throw new TooShortDescriptionException();
            }

            if(descriptionToCheck.Length > 50)
            {
                throw new TooLongDescriptionException();
            }
            return true;
        }
        #endregion private methods

        public class ArticleException : Exception { }
        public class TooShortDescriptionException : ArticleException { }
        public class SpecialCharInDescriptionException : ArticleException { }
        public class TooLongDescriptionException : ArticleException { }
        public class WrongPriceException : ArticleException { }
    }
}
