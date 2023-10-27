using Shopping;
using static Shopping.CartItem;

namespace TestShopping
{
    public class TestCartItem
    {
        #region private attributes
        private CartItem? _cartItem = null;
        private float _price = 0f;
        private int _quantity = 0;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            List<Article> articles = ArticleGenerator.Generate(1);
            _quantity = 1;
            _cartItem = new CartItem(articles[0], _quantity);
        }

        [Test]
        public void AllProperties_AfterInstantiationDefaultValue_GetValues()
        {
            //given
            //refer to Setup
            _price = 2.0f;

            //when
            //Event will be triggered by constructor

            //then
            Assert.That(_cartItem.Article.Price, Is.EqualTo(_price));
            Assert.That(_cartItem.Quantity, Is.EqualTo(_quantity));
            Assert.IsFalse(_cartItem.ForAdultOnly);
        }

        [Test]
        public void AllProperties_AfterInstantiationWithForAdultOnlyOption_GetTrue()
        {
            //given
            //refer to Setup

            //when
            _cartItem.ForAdultOnly = true;

            //then
            Assert.That(_cartItem.Article.Price, Is.EqualTo(_price));
            Assert.That(_cartItem.Quantity, Is.EqualTo(_quantity));
            Assert.IsTrue(_cartItem.ForAdultOnly);
        }

        [Test]
        public void SetQuantity_CorrectValue_GetNewValue()
        {
            //given
            int expectedQuantity = 2;

            //when
            _cartItem.Quantity = expectedQuantity;

            //then
            Assert.That(expectedQuantity, Is.EqualTo(_cartItem.Quantity));
        }

        [Test]
        public void SetQuantity_WrongValue_ThrowException()
        {
            //given
            int expectedQuantity = -2;

            //when
            Assert.Throws<WrongQuantityException>(() => _cartItem.Quantity = expectedQuantity);
            
            //then
            //throws exception
        }
    }
}