using System;
using System.Collections.Generic;

namespace SolidTask
{
    // Принцип единственной ответственности (SRP)
    // Класс Order отвечает только за хранение данных заказа
    public class Order
    {
        public int Id { get; set; }
        public required string CustomerEmail { get; set; }
        public bool IsValid { get; set; }
    }

    // Принцип разделения интерфейсов (ISP)
    public interface IRepository<T>
    {
        void Save(T entity);
    }

    public interface IEmailSender
    {
        void SendEmail(string email, string message);
    }

    // Принцип открытости/закрытости (OCP)
    // Мы можем легко добавить новую реализацию репозитория
    public class SqlDatabase : IRepository<Order>
    {
        public void Save(Order order)
        {
            Console.WriteLine($"Saving order #{order.Id} to SQL database...");
        }
    }

    // Принцип открытости/закрытости (OCP)
    // Мы можем легко добавить новую реализацию отправителя email
    public class SmtpEmailSender : IEmailSender
    {
        public void SendEmail(string email, string message)
        {
            Console.WriteLine($"Sending email to {email}: {message}");
        }
    }

    // Принцип инверсии зависимостей (DIP)
    // OrderService зависит от абстракций, а не от конкретных реализаций
    public class OrderService
    {
        private readonly IRepository<Order> _repository;
        private readonly IEmailSender _emailSender;

        // Внедрение зависимостей через конструктор
        public OrderService(IRepository<Order> repository, IEmailSender emailSender)
        {
            _repository = repository;
            _emailSender = emailSender;
        }

        public bool ProcessOrder(Order order)
        {
            if (!order.IsValid)
                return false;

            _repository.Save(order);
            _emailSender.SendEmail(order.CustomerEmail, "Order confirmed!");

            return true;
        }
    }

    // Принцип единственной ответственности (SRP)
    // Отдельный класс для создания заказов
    public class OrderFactory
    {
        private readonly Random _random = new Random();

        public Order CreateValidOrder()
        {
            return new Order()
            {
                Id = _random.Next(),
                CustomerEmail = $"user{_random.Next()}@example.ru",
                IsValid = true
            };
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Настройка зависимостей
            IRepository<Order> repository = new SqlDatabase();
            IEmailSender emailSender = new SmtpEmailSender();
            
            // Внедрение зависимостей
            OrderService orderService = new OrderService(repository, emailSender);
            OrderFactory orderFactory = new OrderFactory();

            // Создание и обработка заказов
            for (int i = 0; i < 8; i++)
            {
                Order order = orderFactory.CreateValidOrder();
                orderService.ProcessOrder(order);
            }
        }
    }
}
