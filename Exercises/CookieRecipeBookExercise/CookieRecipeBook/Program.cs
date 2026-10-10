using CookieRecipeBook.Services;

UserInterFace interFace = new();
Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
interFace.ShowAvaliableIngredients();
interFace.GetUserInput();



