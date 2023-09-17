using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Domain
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer = new Customer("João CLemer","joao@email.com");
        private readonly Product _product = new Product("Product 1", 10, true);
        private readonly Discount _discount = new Discount(10,DateTime.Now.AddDays(5));

        [TestMethod]
        [TestCategory("Domain")]
        public void Given_A_New_Valid_Order_It_Must_Generate_A_Number_Whit_8_Characteres()
        {
            var order = new Order(_customer, 0, null);
            Assert.AreEqual(8, order.Number.Length);
        } 

        [TestMethod]
        [TestCategory("Domain")]
        public void Given_A_New_Valid_Order_Its_Status_Must_Be_Awaiting_Payment()
        {
            var order = new Order(_customer,0,null);
            Assert.AreEqual(EOrderStatus.WaitingPayment,order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Once_The_Order_Has_Been_Paid_Its_Status_Must_Be_Awaiting_Delivery()
        {
            var order = new Order(_customer,0,null);
            order.AddItem(_product,1);
            order.Pay(10);
            Assert.AreEqual(EOrderStatus.WaitingDelivery,order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Given_An_Order_Canceled_Its_Status_Must_Be_Canceled()
        {
            var order = new Order(_customer,0,null);
            order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled,order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Given_A_New_Item_Without_A_Product_It_Must_Not_Be_Added()
        {
            var order = new Order(_customer,0,null);
            order.AddItem(null,10);
            Assert.AreEqual(0,order.Items.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Given_An_Item_With_A_Quantity_Of_Zero_Or_Less_It_Must_Not_Be_Added()
        {
            var order = new Order(_customer,0,null);
            order.AddItem(_product,0);
            Assert.AreEqual(0,order.Items.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Given_A_Valid_Order_You_Total_Must_Be_50()
        {
            var order = new Order(_customer,0,null);
            order.AddItem(_product,5);
            Assert.AreEqual(50,order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Given_An_Expired_Discount_The_Order_Value_Must_Be_60()
        {
            var expiredDiscount = new Discount(10,DateTime.Now.AddDays(-5));
            
            var order = new Order(_customer,10,expiredDiscount);
            order.AddItem(_product,5);
            Assert.AreEqual(60,order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Given_An_Invalid_Discount_The_Order_Value_Must_Be_60()
        {
            var order = new Order(_customer,10,null);
            order.AddItem(_product,5);
            Assert.AreEqual(60,order.Total());

        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Given_A_Discount_Of_10_The_Order_Value_Must_Be_50()
        {
            var order = new Order(_customer,10,_discount);
            order.AddItem(_product,5);
            Assert.AreEqual(50,order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Given_A_Delivery_Fee_Of_10_The_Order_Value_Must_Be_60()
        {
            var order = new Order(_customer,10,null);
            order.AddItem(_product,5);
            Assert.AreEqual(60,order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Given_An_Order_Without_A_Customer_It_Must_Be_Invalid()
        {
            var order = new Order(null,10,_discount);
            Assert.AreEqual(false,order.Valid);
        }

    }
}