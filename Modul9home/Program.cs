using System;

internal class CafeOrderSystem
{
    public interface IBeverage
    {
        string GetDescription();
        double Cost();
    }

    public class Espresso : IBeverage
    {
        public string GetDescription() => "Эспрессо";
        public double Cost() => 2.0;
    }

    public class Tea : IBeverage
    {
        public string GetDescription() => "Чай";
        public double Cost() => 1.5;
    }

    public class Latte : IBeverage
    {
        public string GetDescription() => "Латте";
        public double Cost() => 2.5;
    }

    public class Mocha : IBeverage
    {
        public string GetDescription() => "Мокка";
        public double Cost() => 3.0;
    }

    public abstract class BeverageDecorator : IBeverage
    {
        protected IBeverage beverage;

        protected BeverageDecorator(IBeverage beverage)
        {
            this.beverage = beverage;
        }

        public virtual string GetDescription() => beverage.GetDescription();
        public virtual double Cost() => beverage.Cost();
    }

    public class Milk : BeverageDecorator
    {
        public Milk(IBeverage beverage) : base(beverage) { }

        public override string GetDescription() => $"{beverage.GetDescription()} с молоком";
        public override double Cost() => beverage.Cost() + 0.5;
    }

    public class Sugar : BeverageDecorator
    {
        public Sugar(IBeverage beverage) : base(beverage) { }

        public override string GetDescription() => $"{beverage.GetDescription()} с сахаром";
        public override double Cost() => beverage.Cost() + 0.2;
    }

    public class WhippedCream : BeverageDecorator
    {
        public WhippedCream(IBeverage beverage) : base(beverage) { }

        public override string GetDescription() => $"{beverage.GetDescription()} с взбитыми сливками";
        public override double Cost() => beverage.Cost() + 0.7;
    }

    public class Syrup : BeverageDecorator
    {
        public Syrup(IBeverage beverage) : base(beverage) { }

        public override string GetDescription() => $"{beverage.GetDescription()} с сиропом";
        public override double Cost() => beverage.Cost() + 0.6;
    }

    public static void Main()
    {
        IBeverage beverage = new Espresso();
        beverage = new Milk(beverage);
        beverage = new Sugar(beverage);
        beverage = new WhippedCream(beverage);
        Console.WriteLine($"{beverage.GetDescription()}: {beverage.Cost()} рублей");

        IBeverage beverage2 = new Mocha();
        beverage2 = new Syrup(beverage2);
        beverage2 = new WhippedCream(beverage2);
        Console.WriteLine($"{beverage2.GetDescription()}: {beverage2.Cost()} рублей");
    }
}
