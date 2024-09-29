// set up the basic features of the ASP.NET Core platform

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

// Enregistrement d'un service 
// Assurez vous que cette ligne soit placée avant : var app = builder.Build();
//builder.Services.AddSingleton<IMyFirstService, MyFirstService>();
// Nous n'avons maintenant plus à nous soucier à creer une instance de MyFristServie
// au sein de notre application, le service d'injection de dependance s'en
// chargera pour nous ! 

// set up middleware components
var app = builder.Build();


// Par défaut les fichiers contenus au sein du dossier wwwroot ne 
// sont pas accessible coté client
// Le composant middleware UseStaticFiles le permet
app.UseStaticFiles(); // give access to files in wwwroot

// Au sein de notre projet UseStaticFiles() sera appelé avant 
// UseAuthentication() ce qui permettra l'accès aux fichiers 
// statiques aux utilisateurs non authentifiés, attention 
// à ne pas stocker des données sensibles dans le dossier wwwroot

// Pour l'accès aux fichiers statiques vous pouvez utiliser un chemin
// relatif au web root, par exemple l'acces au fichier wwwroot/images/image01.jpg,
// on utilisera le chemin http://localhost:5245/images/image01.jpg


app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
