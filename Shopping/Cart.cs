namespace Shopping
{
    public class Cart
    {
        #region private attributes
        private List<CartItem> _cartItems = new List<CartItem>();
        #endregion private attributes

        #region public methods
        public void Add(List<CartItem> cartItems)
        {
            _cartItems = cartItems;
        }

        public void Remove(List<CartItem> cartItemsToRemove)
        {
            throw new NotImplementedException();
        }

        public List<CartItem> CartItems
        {
            get
            {
                return _cartItems;
            }
        }

        public float Price(bool average = false)
        {
            float currentCartPrice = 0f;
            foreach(CartItem cartItem in _cartItems)
            {
                currentCartPrice += cartItem.Article.Price * cartItem.Quantity;
            }

            if (average)
            {
                return currentCartPrice / _cartItems.Count;
            }
            return currentCartPrice;
        }

        public bool DoesExist(int articleId)
        {
            foreach (CartItem cartItem in _cartItems) 
            {
                if (cartItem.Article.Id == articleId)
                {
                    return true;
                }
            }
            return false;
        }

        public int Cheapest()
        {
            //TODO Reflexion, order the list and get the first one ?
            int currentChepeastArticleId = _cartItems[0].Article.Id;
            foreach (CartItem cartItem in _cartItems)
            {
                if (cartItem.Article.Price < this.GetArticleById(currentChepeastArticleId).Price)
                {
                    currentChepeastArticleId = cartItem.Article.Id;
                }
            }
            return currentChepeastArticleId;
        }

        public int MostExpensive()
        {
            //TODO Reflexion, order the list and get the first one ?
            int currentChepeastArticleId = _cartItems[0].Article.Id;
            foreach (CartItem cartItem in _cartItems)
            {
                if (cartItem.Article.Price > this.GetArticleById(currentChepeastArticleId).Price)
                {
                    currentChepeastArticleId = cartItem.Article.Id;
                }
            }
            return currentChepeastArticleId;
        }

        public void ApplyDiscountById(float percentageDiscount, int articleIdToApplyDiscount)
        {
            throw new NotImplementedException();
        }
        #endregion public methods

        #region private methods
        private Article GetArticleById(int articleId) 
        {
            foreach(CartItem cartItem in _cartItems)
            {
                if(cartItem.Article.Id == articleId)
                {
                    return cartItem.Article;
                }
            }
            return null;
        }
        #endregion private methods

        public class CartException : Exception { }
        public class ArticleNotFoundException : CartException { }
    }
}
