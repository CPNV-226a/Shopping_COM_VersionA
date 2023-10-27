using Shopping;
using static Shopping.Article;
using static Shopping.CartItem;

namespace TestShopping
{
    public class TestArticle
    {
        #region private attributes
        private Article? _article = null;
        private int _id;
        private string _description;
        private float _price = 0f;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            _id = 1;
            _description = "product description";
            _price = 20.45f;
            _article = new Article(_id, _description, _price);
        }

        [Test]
        public void AllProperties_AfterInstantiation_Success()
        {
            //given
            //refer to Setup

            //when
            //Event will be triggered by constructor

            //then
            Assert.That(_article.Id, Is.EqualTo(_id));
            Assert.That(_article.Description, Is.EqualTo(_description));
            Assert.That(_article.Price, Is.EqualTo(_price));
        }

        #region Description
        /*
         * A article description must meet theses specifications:
         *  * 2 words minimum
         *  * No special chars like {!,*,+,/}
         *  * Max 50 chars (blank spaces count)
         */

        //TODO add test case for constructor

        [Test]
        public void Description_ShortDescription_ReturnNewValue()
        {
            //given
            string expectedDescription = "After Shave";

            //when
            _article.Description = expectedDescription;

            //then
            Assert.That(_article.Description, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void Description_LongDescription_ReturnNewValue()
        {
            //given
            string expectedDescription = "A very long long long long long long descriptionn";

            //when
            _article.Description = expectedDescription;

            //then
            Assert.That(_article.Description, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void Description_SingleWordDescription_ThrowException()
        {
            //given

            //when
            Assert.Throws<TooShortDescriptionException>(() => _article.Description = "TooShort");

            //then
            //throws exception
        }

        [Test]
        public void Description_DescriptionContainingSpecialChars_ThrowException()
        {
            //given

            //when
            Assert.Throws<SpecialCharInDescriptionException>(() => _article.Description = "Jacques+Daniel");

            //then
            //throws exception
        }

        [Test]
        public void Description_TooLongDescription_ThrowException()
        {
            //given

            //when
            Assert.Throws<TooLongDescriptionException>(() => _article.Description = "A very very very very very looonnng descriptioooooon");

            //then
            //throws exception
        }
        #endregion Description

        #region Price
        /*
         * A article price must meet theses specifications:
         *  * Only positive value
         *  * When updating the price:
         *      * only a price reduction is tolerated.
         *      * the new price must be different from the current one.
         */

        //TODO add test case for constructor

        [Test]
        public void Price_UpdatePrice_GetNewValue()
        {
            //given
            float expectedNewPrice = 22.0f;

            //when
            _article.Price = expectedNewPrice;

            //then
            Assert.That(_article.Price, Is.EqualTo(expectedNewPrice));
        }

        [Test]
        public void Price_UpdatePriceWithNegativeValue_ThrowException()
        {
            //given
            float expectedNewPrice = -22.0f;

            //when
            Assert.Throws<WrongPriceException>(() => _article.Price = expectedNewPrice);

            //then
            //throws exception
        }

        [Test]
        public void Price_UpdatePriceWithSameValueAsCurrent_ThrowException()
        {
            //given
            //refer to setup method

            //when
            Assert.Throws<WrongPriceException>(() => _article.Price = _price);

            //then
            //throws exception
        }

        #endregion Price
    }
}