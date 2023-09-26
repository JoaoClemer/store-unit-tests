using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories.Interaces;
using Store.Tests.Repositories;

namespace Store.Tests.Handlers
{
    [TestClass]

    public class OrderHandlerTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderHandlerTests()
        {
            _customerRepository = new FakeCustomerRepository();
            _deliveryFeeRepository = new FakeDeliveryFeeRepository();
            _discountRepository = new FakeDiscountRepository();
            _orderRepository = new FakeOrderRepository();
            _productRepository = new FakeProductRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]

        public void Given_An_Non_Existent_Customer_The_Order_Should_Not_Be_Generated()
        {
           var command = new CreateOrderCommand();
            command.Customer = null;
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]

        public void Given_An_Invalid_Zip_Code_The_Order_Must_Be_Generated_Normally()
        {
            var command = new CreateOrderCommand();
            command.Customer = "joao";
            command.ZipCode = "";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));
            var handler = new OrderHandler(
                _customerRepository,
                _deliveryFeeRepository,
                _discountRepository,
                _productRepository,
                _orderRepository
            );

            handler.Handle(command);

            Assert.AreEqual(handler.Valid,true);
        }

        [TestMethod]
        [TestCategory("Handlers")]

        public void Given_An_Invalid_Promo_Code_The_Order_Must_Be_Generated_Normally()
        {
            var command = new CreateOrderCommand();
            command.Customer = "joao";
            command.ZipCode = "13411080";
            command.PromoCode = null;
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));
            var handler = new OrderHandler(
                _customerRepository,
                _deliveryFeeRepository,
                _discountRepository,
                _productRepository,
                _orderRepository
            );

            handler.Handle(command);

            Assert.AreEqual(handler.Valid,true);
        }

        [TestMethod]
        [TestCategory("Handlers")]

        public void Given_An_Order_Without_Items_The_Same_Not_Should_Be_Generated()
        {
            var command = new CreateOrderCommand();
            command.Customer = "joao";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        
        }

        [TestMethod]
        [TestCategory("Handlers")]

        public void Given_A_Command_Invalid_The_Order_Not_Must_Be_Generated()
        {
           var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);

        }

        [TestMethod]
        [TestCategory("Handlers")]

        public void Given_A_Command_Valid_The_Order_Must_Be_Generated()
        {
            var command = new CreateOrderCommand();
            command.Customer = "joao";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));

            var handler = new OrderHandler(
                _customerRepository,
                _deliveryFeeRepository,
                _discountRepository,
                _productRepository,
                _orderRepository
            );

            handler.Handle(command);

            Assert.AreEqual(handler.Valid,true);   
        }
    }
}