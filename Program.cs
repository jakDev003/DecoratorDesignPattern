using System;

namespace DecoratorDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IPizza pizza = new Pizza();
            IPizza cheeseDecorator = new CheeseDecorator(pizza);
            IPizza onionDecorator = new OnionDecorator(cheeseDecorator);
            IPizza tomatoDecorator = new TomatoDecorator(onionDecorator);
            Console.WriteLine(tomatoDecorator.GetPizzaType());
        }
    }

    // base interface
    interface IPizza{
        string GetPizzaType();
    }

    // concrete implimentation
    class Pizza: IPizza{
        public string GetPizzaType(){
            return "This is a normal Pizza";
        }
    }

    // base decorator
    class PizzaDecorator: IPizza{
        private IPizza _pizza;
        public PizzaDecorator(IPizza pizza){
            _pizza = pizza;
        }

        public virtual string GetPizzaType(){
            return _pizza.GetPizzaType();
        }
    }

    // concrete decorator
    class CheeseDecorator: PizzaDecorator{
        public CheeseDecorator(IPizza pizza): base(pizza) {  }

        public override string GetPizzaType(){
            string type = base.GetPizzaType();
            type += "\r\n with extra cheese";
            return type;
        }
    }

    class TomatoDecorator: PizzaDecorator{
        public TomatoDecorator(IPizza pizza): base(pizza) {  }

        public override string GetPizzaType(){
            string type = base.GetPizzaType();
            type += "\r\n with tomato";
            return type;
        }
    }

    class OnionDecorator: PizzaDecorator{
        public OnionDecorator(IPizza pizza): base(pizza) {  }

        public override string GetPizzaType(){
            string type = base.GetPizzaType();
            type += "\r\n with onion";
            return type;
        }
    }

}
