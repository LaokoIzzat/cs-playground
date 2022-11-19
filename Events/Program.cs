
using Events;

var keyPressHandler = new KeyPressHandler();

#region Single Publisher, Single Subscriber
keyPressHandler.KeyPressed += (sender, eventArgs) =>
{
    Console.WriteLine($"Key {eventArgs.KeyCode} was pressed");
};
#endregion

var counter = 0;

while(counter < 3)
{
    var keyPressed = Console.ReadKey(true).KeyChar;

    keyPressHandler.OnKeyPressed(keyPressed);

    counter++;
}

#region Single Publisher, Multiple Subscribers
//keyPressHandler.KeyPressed += (sender, eventArgs) =>
//{
//    Console.WriteLine($"Key {eventArgs.KeyCode} was pressed from another handler");
//};

//keyPressHandler.KeyPressed += (sender, eventArgs) =>
//{
//    Console.WriteLine($"Key {eventArgs.KeyCode} was pressed from different handler");
//};

//counter = 0;

//while (counter < 3)
//{
//    var keyPressed = Console.ReadKey(true).KeyChar;

//    keyPressHandler.OnKeyPressed(keyPressed);

//    counter++;
//}
#endregion
