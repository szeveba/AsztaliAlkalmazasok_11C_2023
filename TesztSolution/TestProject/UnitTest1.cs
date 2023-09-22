namespace TestProject
{
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Test1(bool result)
        {
            if (result)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [TearDown]
        public void TearDown()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }

    }
}