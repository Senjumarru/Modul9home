using System;

internal class PaymentIntegrationSystem
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Обработка платежа через PayPal: {amount} рублей");
        }
    }

    public class StripePaymentService
    {
        public void MakeTransaction(double totalAmount)
        {
            Console.WriteLine($"Обработка платежа через Stripe: {totalAmount} рублей");
        }
    }

    public class StripePaymentAdapter : IPaymentProcessor
    {
        private readonly StripePaymentService stripeService;

        public StripePaymentAdapter(StripePaymentService stripeService)
        {
            this.stripeService = stripeService;
        }

        public void ProcessPayment(double amount)
        {
            stripeService.MakeTransaction(amount);
        }
    }

    public class SquarePaymentService
    {
        public void ExecutePayment(double payment)
        {
            Console.WriteLine($"Обработка платежа через Square: {payment} рублей");
        }
    }

    public class SquarePaymentAdapter : IPaymentProcessor
    {
        private readonly SquarePaymentService squareService;

        public SquarePaymentAdapter(SquarePaymentService squareService)
        {
            this.squareService = squareService;
        }

        public void ProcessPayment(double amount)
        {
            squareService.ExecutePayment(amount);
        }
    }

    public class YandexPaymentService
    {
        public void CompletePayment(double amount)
        {
            Console.WriteLine($"Обработка платежа через Yandex: {amount} рублей");
        }
    }

    public class YandexPaymentAdapter : IPaymentProcessor
    {
        private readonly YandexPaymentService yandexService;

        public YandexPaymentAdapter(YandexPaymentService yandexService)
        {
            this.yandexService = yandexService;
        }

        public void ProcessPayment(double amount)
        {
            yandexService.CompletePayment(amount);
        }
    }

    public static void Main()
    {
        IPaymentProcessor paypalProcessor = new PayPalPaymentProcessor();
        paypalProcessor.ProcessPayment(150.0);

        IPaymentProcessor stripeProcessor = new StripePaymentAdapter(new StripePaymentService());
        stripeProcessor.ProcessPayment(200.0);

        IPaymentProcessor squareProcessor = new SquarePaymentAdapter(new SquarePaymentService());
        squareProcessor.ProcessPayment(300.0);

        IPaymentProcessor yandexProcessor = new YandexPaymentAdapter(new YandexPaymentService());
        yandexProcessor.ProcessPayment(350.0);
    }
}
