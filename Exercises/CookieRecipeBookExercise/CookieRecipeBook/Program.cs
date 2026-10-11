using CookieRecipeBook.App;
using CookieRecipeBook.FileAcess;
using CookieRecipeBook.Recipe.IngredientsRepo;
using CookieRecipeBook.DataAccess;


const FileFormat Format = FileFormat.Json;
const string FileName = "recipes";
var fileMetaData = new FileMetaData(FileName,Format);
var ingredientMenu = new IngredientsMenu();
IStringRepository stringRepository = Format == FileFormat.Json ?
 new StringJsonRepository() : new StringTextualRepository();


var cookBookApp = new CookBookApp(new UserInterFace(ingredientMenu),new RecipeRepository(stringRepository,ingredientMenu));// to do the implementation

cookBookApp.Run(fileMetaData.Path());




