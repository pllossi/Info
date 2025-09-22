using Lamp;

Lampadina lampadina = new Lampadina(false, true, 15);
Lampadina lampadina1 = new Lampadina(false, false, 1);
Console.WriteLine("Lampadina 1");
Console.WriteLine(lampadina._isOn);
Console.WriteLine("Lampadina 2");
Console.WriteLine(lampadina._isOn);
Console.WriteLine("Lampadina 1 click");
lampadina.Click();
Console.WriteLine(lampadina._isOn);
Console.WriteLine(lampadina._isBroken);
Console.WriteLine("Lampadina 2 click");
lampadina1.Click();
Console.WriteLine(lampadina1._isOn);
Console.WriteLine(lampadina1._isBroken);