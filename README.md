# ASP NET .CORE MVC (.NET 8.0)

## Concepts essentiels MVC et cycle de vie d'une requete HTTP

Passons en revue rapidement quelques concepts essentiels de MVC.

- Les **models** sont les classes qui représentent les différents types d'objets gérés par l'application web. Ces objets représentent l'état de l'application. Par exemple (pensez à une application web comme Amazon, Canvas, Moodle, etc.), nous pourrions avoir les classes de **model** suivantes : **Course**, **User**, **Student**, **Instructor**, **Administrator**, **Product**, **Seller**, **Buyer**, etc.

- Les **views** constituent l'interface utilisateur. Nous présenterons du contenu aux utilisateurs via les **views** (plus précisément, nous utiliserons les **views** pour construire des pages web qui seront finalement affichées dans le navigateur d'un utilisateur). Nous en verrons plus à ce sujet plus tard.

Par exemple (pensez à une application web comme Amazon, Canvas, Moodle, etc.), nous pourrions avoir une **view** utilisée pour afficher une liste de tous les cours suivis par un étudiant, ou une liste de tous les ordinateurs portables disponibles à l'achat. Nous pourrions utiliser une autre **view** pour créer une page permettant à nos utilisateurs de changer leur mot de passe.

- Les **controllers** vont gérer l'interaction utilisateur. Nous les verrons plus en détail ci-dessous.

Par exemple (pensez à une application web comme Amazon, Canvas, Moodle, etc.). Que se passe-t-il lorsque vous cliquez sur un bouton ? Ou sur un lien ? Ou lorsque vous chargez la première page d'accueil ? Dans chacun de ces cas, vos requêtes seront (éventuellement) envoyées à un **Controller** (plus précisément à une **Action** de ce **Controller**). Dans de nombreux cas, le **Controller** créera une instance d'un **Model**, puis la passera à une **View** pour construire une page qui s'affichera finalement dans le navigateur de l'utilisateur.

Voyons maintenant le cycle de vie d'une requête (voir Fig. 7.1). Ceci est juste une introduction pour que vous ayez une idée générale de ce que nous abordons. Nous entrerons dans plus de détails plus loin. Que se passe-t-il lorsque l'utilisateur demande une page (soit en tapant une URL, soit en cliquant sur un lien ou un bouton) :

**Étape 1** : L'utilisateur envoie une requête HTTP.  
Par exemple, l'utilisateur entre l'URL suivante : `http://www.mysite.com/instructor/show/1`.  
Pour notre livre, nous exécuterons le serveur depuis un **localhost**. Ainsi, au lieu de `http://www.mysite.com`, nous utiliserons `http://localhost:5125`.

**Étape 2** : Un objet **controller** est instancié pour répondre à cette requête.

- Le routage de l'URL détermine quel **controller** et quelle **action** géreront la requête HTTP.
- Dans notre cas, le **StudentController** sera instancié.

**Étape 3** : Une méthode **action** est ensuite appelée par le **controller**.

- Une **Show action** sera appelée par le **controller**.
- Un **model binder** nous aide à déterminer les valeurs passées à l'**action** en tant que paramètres (par exemple, 1).
- Si nécessaire, l'**action** peut créer une nouvelle instance d'une classe de **model**. Dans notre exemple, un objet **Student**.
- En général, l'**action** passera l'objet **model** à une **view** pour afficher les résultats demandés.

**Étape 4 :**

Nous utiliserons des views pour produire la sortie qui sera envoyée au navigateur du client.

**Notes :**

En général, nous avons une classe de controller pour chaque classe de model.
Par exemple, pour le model Student, nous avons un StudentController qui nous permettra d'ajouter, modifier, supprimer et afficher les données des étudiants.
Un autre exemple : pour le model User, nous aurons un AccountController qui nous permettra d'enregistrer, de connecter et de déconnecter les utilisateurs.
Cependant, pour le HomeController, nous n'aurons pas de classe de model.
Chaque controller peut avoir plusieurs views :
Nous verrons cela ci-dessous, mais en général, nous créons une view pour chaque action.
Et comme vu précédemment, un controller peut avoir plusieurs actions.

## Détails avec un exemple : Instructor MVC

### Le model Instructor

Ici, nous allons ajouter un autre **model**, **controller** et les **views** correspondantes. Mais cette fois, nous allons approfondir le concept de MVC. En particulier, nous allons nous concentrer davantage sur les **views**, et nous introduirons la syntaxe **Razor** (qui permet essentiellement d'intégrer du code C# à l'intérieur des **views**).

Commençons par ajouter un nouveau **model**. Pour cet exemple, nous allons créer une nouvelle classe appelée **Instructor**. Assurez-vous d'ajouter cette nouvelle classe dans le dossier **Models** (dans la fenêtre **Solution Explorer**, cliquez avec le bouton droit sur le dossier **Models**, puis sélectionnez **le bouton ajouter un fichier**).

Ensuite, nous devons choisir quelles caractéristiques ajouter à cette classe. Dans notre exemple ci-dessous, nous avons ajouté les éléments suivants :

(cf code source)

### Le controller Instructor

Ajout d'un nouveau Controller avec le solution Explorer de VS Code, en cliquant avec le bouton droit sur le dossier **Controllers**, puis en sélectionnant **Add > Controller**. Dans la fenêtre qui s'ouvre, sélectionnez **MVC Controller - Empty**. Ensuite, nommez le **controller** **InstructorController**.

Au sein de ce controller vous pouvez ajouter de fausses données pour les tests, par exemple :

```csharp
List<Instructor> InstructorsList = new List<Instructor>()
{
new Instructor() {InstructorId = 100,
FirstName = "Maegan", LastName = "Borer",
IsTenured=false, HiringDate=DateTime.Parse("2018-08-15"),
Rank = Ranks.AssistantProfessor},
new Instructor() {InstructorId = 200,
FirstName = "Antonietta ", LastName = "Emmerich",
IsTenured=true, HiringDate=DateTime.Parse("2022-08-15"),
Rank = Ranks.AssociateProfessor},
new Instructor() {InstructorId = 300,
FirstName = "Antonietta", LastName = "Lesch",
IsTenured=false, HiringDate=DateTime.Parse("2015-01-09"),
Rank = Ranks.FullProfessor},
new Instructor() {InstructorId = 400,
FirstName = "Anjali", LastName = "Jakubowski",
IsTenured=true, HiringDate=DateTime.Parse("2016-01-10"),
Rank = Ranks.Adjunct}
};
```

Il est preferable d'ajouter vos propres données à ce stade.

#### Ajout d'actions dans le controller

Lorsque vous pensez aux données d'un **Instructor**, quelles opérations/actions aimeriez-vous pouvoir effectuer ?  
Voici les actions que nous allons ajouter à notre classe de **controller** :

- **Index** : Utilisée pour afficher une liste d'instructeurs.
  - **ShowAll** : Identique à la précédente, nous l'utiliserons pour démontrer la redirection vers une action.
  - **DisplayAll** : Identique à la précédente, nous l'utiliserons pour démontrer une **view** avec un nom spécifique.
- **Show(int id)** : Utilisée pour afficher tous les détails d'un seul instructeur.
- **Add** : Utilisée pour créer/ajouter un nouvel instructeur. Comme nous le verrons, c'est un processus en deux étapes (nous aurons donc deux actions).
- **Edit(int id)** : Utilisée pour modifier un instructeur existant. Ceci est également un processus en deux étapes (nous aurons donc deux actions).
- **Delete(int id)** : Utilisée pour supprimer un instructeur existant. Cela pourrait également, en option, être un processus en deux étapes.

IMPORTANT : Comme mentionné, plusieurs **actions** ont la même instruction `return View();`. Comme nous le verrons ci-dessous, elles renverront en réalité des **views** ou des résultats différents. Ici, nous faisons usage du principe de **convention over configuration**. En particulier :

- L'instruction `return View();` de l'**action Edit** renverra la **view Edit** ;
- L'instruction `return View();` de l'**action Add** renverra la **view Add**.

Les fichiers de **view** utilisés sont des fichiers **Razor view** (également appelés modèles de vue basés sur **Razor**). Ces fichiers ont l'extension `.cshtml` et contiendront à la fois du code C# et HTML. Le moteur **Razor** utilisera le code C# et HTML d'une **view** pour générer le contenu HTML correspondant (la réponse HTML) qui sera renvoyé au client ayant fait la requête (et sera finalement affiché dans un navigateur). Pour en savoir plus sur les **views**, voir également [56].

Notez que les **actions** mentionnées ci-dessus devraient vous rappeler les opérations **CRUD**, souvent vues dans un cours sur les bases de données. **CRUD** signifie :

- **Create** : Utilisé pour créer/ajouter de nouvelles données.
- **Read** : Utilisé pour récupérer/chercher/afficher des données existantes.
- **Update** : Utilisé pour mettre à jour/modifier des données existantes.
- **Delete** : Utilisé pour supprimer des données existantes.

Un **controller** implémente souvent les opérations **CRUD**.

##### Index

Nous aimerions définir cette **action** pour être utilisée lors des requêtes qui afficheront finalement (dans la **view**) une liste d'instructeurs.

L'**action Index** ressemble pour l'instant à ceci :

(cf code)

Toutes les **views** sont situées dans le dossier **Views**, à l'intérieur d'un sous-dossier qui correspond au nom du **controller**.

- Toutes les **views** pour l'**InstructorController** seront créées sous le dossier **Views**, dans le sous-dossier **Instructor**.
- Toutes les **views** pour le **StudentController** seront créées sous le dossier **Views**, dans le sous-dossier **Student**.

Lorsque vous utilisez l'URL ci-dessus et appuyez sur Entrée pour envoyer une requête HTTP au serveur, selon le routing par défaut (que nous avons configuré dans notre projet), votre requête sera envoyée à l'action Index du InstructorController.

Dans le chapitre précédent, nous avons vu comment utiliser l'objet dynamique ViewBag pour transmettre des informations d'une action à sa vue. Ici, nous allons voir une approche meilleure (lorsque c'est approprié), à savoir les vues fortement typées.

Une vue peut être :

- **fortement typée** :
  — si elle a une déclaration @model en haut de la page de la vue.
  – Le @model déclarera le type d'objet avec lequel cette vue travaille.
  – Une vue peut travailler avec une instance d'un modèle : @model ASPBookProject.Models.Instructor
  – Une vue peut travailler avec une collection d'instances d'un modèle : @model IEnumerable<ASPBookProject.Models.Instructor>
  Dans ce cas, nous utiliserons @foreach pour itérer à travers la collection
  – Important : Vous ne pouvez pas avoir plus d'une directive @model dans une vue !
- **typée dynamiquement**:
  — si elle n'a pas de déclaration @model en haut de la page de la vue.
  – Nous utilisons ce type si la vue ne travaille avec aucun modèle ou
  – Nous utilisons ce type si la vue doit travailler avec plus d'un modèle.
  – Important : Avant d'utiliser le modèle à l'intérieur de la vue, vous devrez vérifier qu'il n'est pas null !

Revenons à notre exemple, nous voudrions passer InstructorsList à la vue pour l'afficher. Pour cela, nous faisons ce qui suit :
. À l'intérieur de l'action Index, assurez-vous de passer ceci comme paramètre à la méthode View.
– Remplacez return View(); par return View(InstructorsList);

. À l'intérieur de la vue Index, en haut de la page, nous devons ajouter la directive @model (cela rend la vue fortement typée) :
– @model IEnumerable<ASPBookProject.Models.Instructor>

##### Razor syntax et Razor view

Avant d'aller plus loin modifiez le fichier program.cs afin que le routing par defaut pointe sur le controller Instructor et l'action Index.

```csharp
app.MapControllerRoute(
name: "default",
pattern: "{controller=Instructor}/{action=Index}/{id?}");
});
```

Pour afficher toutes les valeurs de la liste des instructeurs, nous devrons utiliser C#. C'est là que Razor devient pratique.

"Razor est une syntaxe de balisage pour intégrer du code basé sur .NET dans des pages web" (voir plus dans [58]). Par conséquent, en utilisant la syntaxe Razor, nous pouvons intégrer du code C# dans nos vues (Razor).

Ensuite, un mécanisme appelé Razor Engine parcourra la vue et exécutera le code C# et HTML, ne nous donnant que du contenu HTML, qui est ce que nous envoyons comme réponse à la requête du client.

Razor utilise le symbole @ pour passer de HTML à C#. Pour la transition de C# vers HTML, il n'y a pas de symbole, Razor déduira (généralement correctement) où cela doit être fait. Ce sont ce qu'on appelle les expressions Razor implicites et en voici un exemple :

`@DateTime.Now`

Lorsque les expressions implicites n'interprètent pas correctement une expression Razor, nous pouvons utiliser des expressions Razor explicites en utilisant des parenthèses @(), par exemple,

`@(DateTime.Now - TimeSpan.FromDays(7))`.

Pour les blocs de code Razor, nous utilisons des accolades, @{}. Nous verrons des exemples ci-dessous. Tout comme C#, Razor prend en charge :

. Les conditions : @if, else if, else, et @switch. Par exemple (pouvez-vous deviner ce que cela fait ?),

```csharp
@if (User.Identity.IsAuthenticated) //si l'utilisateur est connecté
{
<li class="nav-item">
<a class="nav-link" asp-action="Logout" asp-controller="Account">Logout</a>
</li>
}
else
{
<li class="nav-item">
<a class="nav-link" asp-action="Login" asp-controller="Account">Login</a>
</li>
}
```

. Les boucles : @for, @foreach, @while, et @do while. Nous verrons un exemple de ceci ci-dessous.

. Les commentaires : @_ … _@.

. Les commentaires C# (// et /_…_/) sont également pris en charge.

Si vous voulez qu'une action utilise/retourne une vue avec le même nom (pour l'action Index, utiliser la vue Index), nous avons simplement utilisé return View(); et plus tard nous avons utilisé return View(InstructorsList);

Dans les deux cas, nous n'avons pas eu à spécifier d'utiliser la vue "Index", le compilateur a simplement su utiliser cette vue. C'est un exemple de convention plutôt que configuration.

Si au lieu de cela, nous voulons qu'une action (disons DisplayAll) utilise une vue avec un nom différent (disons Index), alors nous devons passer le nom comme premier argument à l'appel de la méthode View(). Voici un exemple (voir les deux actions côte à côte) :

    (cf code source)

#### L'action ShowDetails

Que devrions-nous attendre de cette action ? Que devrait faire cette action ? Elle devrait nous permettre de fournir un identifiant d'instructeur, rechercher (normalement dans une base de données) l'instructeur qui correspond à cet identifiant, et en réponse, afficher l'instructeur.

L'action ShowDetails nécessite un paramètre qui identifie de manière unique un Instructor. Dans la classe Instructor, ce serait la propriété InstructorId. Cependant, comme le routing par défaut utilise id comme l'un de ses segments, il est important que nous utilisions id au lieu de InstructorId comme paramètre pour l'action ShowDetails.
La raison en est liée au model binding que nous aborderons un peu plus tard.

Alternativement, on peut également ajouter une autre route, une qui utilise un segment contenant InstructorId (ou quel que soit le nom que vous souhaitez utiliser pour le paramètre de l'action ShowDetails).
Lorsque l'action ShowDetails est appelée, une valeur pour id est/devrait être fournie (c'est le paramètre de l'action). Ensuite, l'action recherchera une instance de Instructor dans notre InstructorsList qui a la valeur de la propriété InstructorId égale à l'Id donné.

##### La directive @model

Puisque l'action transmet une instance de Instructor à cette vue, nous devrions faire de notre vue une vue fortement typée en utilisant la directive model :
@model ASPBookProject.Models.Instructor
Note : Lors de l'utilisation de la directive @model, nous avons dû utiliser le nom complet de la classe qui a la forme : namespace.nomdelaclasse.

##### La directive @using

Au lieu de la directive @model d'une seule ligne :

@model IEnumerable<ASPBookProject.Models.Instructor>

nous pourrions utiliser les deux directives suivantes :

@using ASPBookProject.Models
@model Instructor

De même, dans la vue Index, nous pouvons remplacer :
@model IEnumerable<ASPBookProject.Models.Instructor>

par

@using ASPBookProject.Models
@model IEnumerable<Instructor>

ce qui est plus facile à lire.

##### Le fichier \_ViewImports.cshtml

Au lieu d'utiliser la directive @using ASPBookProject.Models dans chaque vue de notre projet, nous avons une solution plus élégante. Nous pouvons créer un fichier nommé ViewImports.cshtml (directement sous le dossier Views !) et y copier cette directive. Ensuite, nous n'aurons plus besoin d'ajouter cette directive à aucune de nos vues (et nous pouvons les supprimer de nos vues).

Ajoutons le fichier ViewImports. Pour cela, dans la fenêtre Solution Explorer, faites un clic droit sur le dossier Views, puis sélectionnez Add > New Item ….
Ensuite, sélectionnez Razor View Imports et cliquez sur le bouton Add. Assurez-vous que le champ nom contient ViewImports.cshtml.

Dans ce fichier (ViewImports.cshtml), ajoutez la ligne :
@using ASPBookProject.Models

Vous pouvez ensuite supprimer cette directive des fichiers de vue Index et ShowDetails. Vous n'aurez pas besoin d'ajouter cette directive aux vues que vous créerez désormais dans ce projet.

Plus précisément, la vue Index ne devrait avoir aucune directive @using, seulement la directive suivante :
@model IEnumerable<Instructor>

Et de même, pour la vue ShowDetails, elle ne devrait avoir que la directive :
@model Instructor

Si vous vous demandez pourquoi nous avons un underscore (_) dans le nom de fichier ViewImports.cshtml, voici une explication : "Les fichiers dans le dossier Views dont les noms commencent par un underscore (le caractère _) ne sont pas retournés à l'utilisateur" (extrait de la documentation ASP.NET Core).

##### Les tags helpers et les html helpers

Les HTML helpers sont essentiellement des fonctions C# qui retournent (ou construisent) du code HTML. Voici un exemple :

@Html.ActionLink("cliquez pour les détails", "ShowDetails", new{id=100})

Ci-dessus, la fonction Html.ActionLink fournit trois arguments :
. une valeur pour le texte du lien hypertexte ("cliquez pour les détails") ;
. une valeur pour le nom de l'action à appeler ("ShowDetails") ;
. et un paramètre (optionnel) - id - auquel on attribue une valeur (id = 100).

Le résultat du HTML helper ci-dessus : il apparaîtra dans un navigateur sous la forme cliquez pour les détails.
Le code HTML généré par le HTML helper ci-dessus, en utilisant le routing par défaut, est :
<a href="/Instructor/ShowDetails/100">cliquez pour les détails</a>

Au lieu des HTML helpers, on peut utiliser des tag helpers. Les tag helpers "permettent au code côté serveur de participer à la création et au rendu des éléments HTML dans les fichiers Razor". Les tag helpers ressemblent beaucoup au code HTML et, de l'avis de l'auteur, ils sont plus faciles à lire pour les développeurs. Dans ce livre, nous nous concentrerons principalement sur les tag helpers, mais nous utiliserons aussi occasionnellement des HTML helpers.

Voici l'équivalent en tag helper du HTML helper donné ci-dessus :
`<a asp-action="ShowDetails" asp-route-id="100">cliquez pour les détails</a>`

La sortie et le code HTML générés sont identiques à ce que nous a donné le HTML helper.
Notez à quel point ce tag helper est naturel. Puisque nous devons créer un lien, nous avons utilisé l'élément `<A>`. Le contenu de cet élément ("cliquez pour les détails") est le texte qui apparaît comme un lien. Mais, grâce aux tag helpers, l'élément `<A>` a deux "attributs" (qui ne sont pas HTML, ils font partie des tag helpers) que nous avons utilisés :
. asp-action="ShowDetails" - pour désigner le nom de l'action (ShowDetails) que nous voulons utiliser.
. asp-route-id="100" - pour spécifier que la partie id de la route doit utiliser la valeur 100.

- IMPORTANT : Si votre route utilise un nom différent au lieu de id, disons instructorId, alors vous devriez utiliser asp-route-instructorId="100"

Très important : Pour utiliser les tag helpers, vous devrez ajouter la directive suivante :
@addTagHelper \*, Microsoft.AspNetCore.Mvc.TagHelpers

## Introductions aux Data Annotations

Nous commencerons par quelques exemples simples d'annotations de données qui ne sembleront probablement pas très utiles, mais au fur et à mesure que nous introduirons plus d'annotations de données, vous les trouverez très utiles et très puissantes. Elles valent vraiment la peine d'être étudiées et nous les utiliserons beaucoup, alors veuillez investir du temps pour les comprendre.

Les annotations de données "sont utilisées pour définir des métadonnées pour les contrôles de données ASP.NET MVC et ASP.NET"

Pour corriger l'espacement dans le nom de propriété affiché, nous utiliserons des annotations de données. Elles sont très puissantes, et nous verrons bientôt pourquoi. Mais pour l'instant, utilisons une annotation de données simple, à savoir l'annotation de données display. Si vous allez à la définition de la classe Instructor, nous pouvons ajouter des annotations de données display à chacune de nos propriétés, de sorte qu'au lieu des noms de propriétés, nous pouvons afficher n'importe quel texte que nous voulons.

Notes :
. On peut ajouter plusieurs annotations de données pour la même propriété, et
. certaines propriétés peuvent n'avoir aucune annotation de données.
Une annotation de données s'applique à la propriété suivante immédiatement après l'annotation.

IMPORTANT : Pour voir les annotations s'afficher, nous ne pouvons pas simplement utiliser le nom de la propriété (comme dans @Model.FirstName), nous devons utiliser des tag helpers/html helpers pour utiliser ces annotations de données display. Ci-dessus, nous avons utilisé un tag helper avec l'élément <label> pour afficher les noms de propriétés. Ci-dessous, nous apporterons des modifications (nous pouvons ajouter des HTML helpers ou des tag helpers) pour afficher également les valeurs des propriétés.

En utilisant ces helpers, nous avons assuré que les valeurs affichées utiliseront les Annotations de Données dans notre code. Ci-dessus, nous avons utilisé le HTML helper DisplayFor. Pour utiliser ce HTML helper, nous lui avons fourni une expression lambda spécifiant quelle propriété nous voulions afficher.

Vous devriez également noter que le html helper (et de même pour les tag helpers) a tiré parti du fait que IsTenured était déclaré comme une propriété Boolean. En raison de cela, il a affiché sa valeur comme une case à cocher (cochée pour vrai, décochée pour faux). Nous verrons plus à ce sujet dans la prochaine section.

## Suite du controller Instructor

## Ajout de l'action Add

Cette section est très importante car elle introduit plusieurs nouveaux concepts importants, et elle peut sembler un peu plus difficile qu'elle ne l'est réellement. La plupart des concepts seront revus dans la prochaine section et vous les comprendrez probablement beaucoup mieux à ce moment-là. Veuillez être patient.

Comme nous le verrons ci-dessous, l'opération Add est en fait un processus en deux étapes et nous devrons créer deux actions Add :
. une pour l'opération GET qui sera utilisée pour envoyer une demande de formulaire à remplir, et
. une pour l'opération POST que nous utiliserons pour envoyer toutes les données du formulaire au serveur.

Ajoutez la nouvelle action suivante dans le fichier InstructorController.cs (nous l'avons ajoutée juste après l'action Add précédemment ajoutée) : (cf code de la seconde action add)

Ce code compile, car la surcharge de méthode est autorisée, mais cela introduira un défi pour le routing. Exécutez à nouveau votre application et cliquez sur le lien "Add a new instructor ...". Vous obtiendrez l'erreur suivante : AmbiguousMatchException: The request matched multiple endpoints.

Pour corriger cela, nous pouvons ajouter les attributs de VERBE HTTP suivants :
[HttpGet] - pour la première action Add et
[HttpPost] - pour la seconde action Add.

Ces attributs restreignent essentiellement le type de requêtes auxquelles leurs actions respectives répondront.
. En utilisant [HttpPost] pour une action, nous limitons cette action à ne répondre qu'aux requêtes POST.
. Typiquement, lorsque vous cliquez sur un lien ou tapez une URL dans le navigateur, vous ferez une requête GET.
. Typiquement, lorsque vous cliquez sur un bouton de soumission pour un formulaire, ou téléchargez un fichier à envoyer au serveur, vous ferez une requête POST.

L'utilisation de ces attributs résoudra l'ambiguïté dont se plaignait le routing. Le code devrait compiler sans erreurs.

### Model Binding

Très important : La méthode Add ci-dessus a un paramètre de type Instructor. Nous pouvons choisir n'importe quel type de paramètre dont nous avons besoin pour une action, mais dans ce cas, nous avons choisi Instructor car nous disposons d'un mécanisme très utile, appelé model binding, qui nous aide en arrière-plan. Plus précisément, lorsque cette deuxième action Add est appelée, le model binding va :

. chercher à trouver les informations nécessaires pour notre action - dans notre cas, nous avons besoin d'une instance d'Instructor ;
. examiner les informations envoyées au serveur - dans notre cas, il examinera les données envoyées par le formulaire (et d'autres sources aussi) ; et enfin
. avec les valeurs saisies dans le formulaire, créer une instance de l'Instructor et la transmettre à notre action Add.

#### Precisions sur le model binding (liaison de modèle)

Dans l'exemple vu dans la section précédente, le système de model binding a été capable de collecter diverses données de notre formulaire et de les transformer en une instance de l'Instructor nécessaire pour l'action Add.

En général, le système de model binding peut récupérer des données de diverses sources, dans cet ordre :
. Champs de formulaire.
. Données de route.
. Paramètres de chaîne de requête.
. Fichiers téléchargés.

Le système de model binding peut fournir ces données aux contrôleurs et même convertir les diverses données de type chaîne en types .Net.

#### GET vs POST

Nous avons brièvement vu GET et POST (appelés verbes HTTP) plus tôt. Ils sont tous deux utilisés pour envoyer des informations du client à un serveur web et sont les plus courants. Mais il y a des différences importantes entre eux.

En classe, nous aimons démontrer les exemples montrés dans :
. https://www.w3schools.com/html/tryit.asp?filename=tryhtml_form_get
. https://www.w3schools.com/html/tryit.asp?filename=tryhtml_form_post

Requêtes GET
. peuvent être mises en cache ;
. peuvent être vues dans l'historique du navigateur ;
. peuvent être mises en favori ;
. ne devraient pas être utilisées pour traiter des données sensibles (comme le nom d'utilisateur et le mot de passe) ;
. ont des restrictions de longueur ;
. les données sont visibles dans l'URL ! ;
. seuls les caractères ASCII sont autorisés pour les données ;
– nous les utilisons généralement pour envoyer une demande de formulaires ;
– lorsqu'on clique sur des liens web, nous envoyons des requêtes GET.

Requêtes POST
. ne restent pas dans l'historique du navigateur ;
. ne peuvent pas être mises en favori ;
. n'ont pas de restrictions sur la longueur des données ;
. les données ne sont pas visibles dans l'URL ! ;
– nous les utilisons généralement pour envoyer des données depuis des formulaires (mais nous pouvons parfois aussi utiliser des requêtes GET) ;
– nous devons utiliser des requêtes POST pour envoyer des fichiers à un serveur.

Il existe d'autres verbes HTTP, tels que PUT, HEAD, DELETE et PATH, et vous pouvez même définir les vôtres. Mais nous ne les utiliserons pas dans ce livre. Pour en savoir plus à leur sujet, consultez la ressource suivante [13].

Ci-dessus, nous avons vu que Add était un processus en deux étapes. Nous avions ce qui suit :
. Étape 1 : Add - la requête GET : Elle était utilisée pour envoyer une requête au serveur et en retour obtenir une vue contenant un formulaire pour que l'utilisateur puisse saisir ses données.
– C'est quand l'utilisateur clique sur un lien (et plus tard un bouton).
. Étape 2 : Add - la requête POST : Elle était utilisée pour envoyer les données saisies dans le formulaire au serveur.
– C'est quand l'utilisateur clique sur le bouton de soumission.

Discutons brièvement d'autres exemples.
Le processus de connexion (nous l'implémenterons dans un chapitre ultérieur).
. Étape 1 : Login - la requête GET : Cela envoie une requête au serveur pour obtenir un formulaire afin que l'utilisateur puisse saisir son nom d'utilisateur et son mot de passe.
. Étape 2 : Login - la requête POST : Lorsque l'utilisateur clique sur le bouton de soumission, les données sont envoyées au serveur pour traitement (vérifier les informations de connexion correctes et renvoyer des cookies d'authentification).

## Exemple d'utilisation de Service dans un controller (optionnel)

Un service est un couple Interface/Classe qui fournit des fonctionnalités spécifiques à une application.

Nous l'enregistrons dans le conteneur de services de l'application pour qu'il soit disponible pour les contrôleurs et les autres services. La facon dont il est enregistré détermine comment il est créé et utilisé. (Singleton, Scoped, Transient)

Nous l'injectons dans les contrôleurs ou les autres services qui en ont besoin. Grace a la creation d'un champ privé readonly dans le controller et l'ajout d'un constructeur qui prend en parametre le service.

## Validation de modèle

Il y a trois étapes principales à suivre pour ajouter une validation à un modèle :

. Utiliser les attributs de validation intégrés (nous verrons aussi comment créer nos propres attributs de validation personnalisés).
. Appliquer la validation en utilisant le ModelState.
. Ajouter des helpers de validation pour afficher les messages d'erreur.

## Entity Framework Core

### Introduction

Dans ce chapitre, nous apprendrons comment utiliser Entity Framework Core pour travailler avec des données provenant d'une base de données. En particulier, nous verrons comment travailler avec une base de données MySQL.

Un mappeur objet-relationnel est un mécanisme qui fait correspondre des objets (dont les classes sont appelées entités) à des tables. Cela vous permet de travailler avec des données provenant de bases de données en utilisant une approche orientée objet. Quelques exemples de mappeurs objet-relationnels : Entity Framework Core, Django et Hibernate.

Entity Framework Core est un framework de mappage objet-relationnel (ORM). Il permet à une application .Net (application web, application console, ...) de travailler avec les données stockées dans une base de données. Entity Framework Core fournit un niveau d'abstraction entre une application et une base de données et, comme vous le verrez ci-dessous, il simplifie votre accès aux données (les opérations CRUD) de la base de données.

Vous n'aurez même pas besoin de connaître la syntaxe SQL pour travailler avec des bases de données SQL (via Entity Framework Core), bien qu'il soit certainement utile d'avoir des connaissances fondamentales sur les bases de données (par exemple, comprendre ce que sont les clés primaires et les clés étrangères).

### Les classe impliquées dans Entity Framework Core

Voici une introduction rapide aux classes impliquées lors de l'utilisation d'Entity Framework Core. Nous les reverrons dans la prochaine section, où nous passerons en revue les étapes nécessaires pour configurer Entity Framework Core pour travailler avec notre application.

Pour travailler avec différents types de bases de données, Entity Framework utilise différents types de classes appelées providers :
. Microsoft SQL Provider - utilisé pour se connecter aux bases de données SQL (SQL Server ou Azure SQL Database).
. SQLite Provider - utilisé pour se connecter à une base de données SQLite.
. Memory Provider - utilisé pour simuler une base de données en mémoire, idéal pour les tests.
. Autres providers - fournis par d'autres vendeurs.

nous utilierons donc logiquement le provider MySQL pour travailler avec une base de données MySQL.

Il y a deux principales classes que nous utiliserons en travaillant avec Entity Framework Core :

- La classe **DbContext** a de nombreuses responsabilités importantes, notamment :

  - connexions à la base de données (ouvrir, fermer et gérer les connexions à une base de données) ;
  - opérations sur les données (ajout de données, modification de données, suppression de données et requêtes de données) ;
  - suivi des changements (elle garde une trace des changements dans votre application - pour que vous puissiez les sauvegarder dans la base de données) ;
  - mappage de données (elle mappe les propriétés des entités aux colonnes des tables) ;
  - gestion des transactions (lorsque SaveChanges est appelé, une transaction est créée pour tous les changements en attente. Si une erreur/exception se produit lors de l'application des changements à la base de données, ils sont tous annulés).

- La classe `DbSet<TEntity>`
  - Les classes DbSet<TEntity> sont ajoutées comme propriétés à notre classe dérivée de DbContext ;
  - chaque propriété DbSet représente les données (sous forme de collection) d'une table dans la base de données ;
  - nous l'utiliserons pour effectuer des opérations de base de données pour une table ;
  - par défaut, les propriétés de l'entité/modèle sont mappées aux colonnes de la base de données avec le même nom.

Nous appelons classes d'entité les classes (de modèle) que nous mappons aux tables de la base de données.

### Ajout de Entity Framework Core à notre application

Pour ajouter Entity Framework Core à notre application, nous devons effectuer les étapes suivantes :

Etape 1 : Créer vos classes d'entité (modèles), assurez-vous que vos entités ont des propriétés publiques et des propriétés de navigation publiques, un propriété :

- dont le nom est Id
- ou [classname]Id
- ou l'attribut [Key] est appliqué

Cette propriété sera utilisée comme clé primaire de la table correspondante dans la base de données.

Etape 2 : installer les pqquets suivants :

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Pomelo.EntityFrameworkCore.MySql

Etape 3 : Creation d'une classe qui hérite de DbContext

Etape 4 : Mettre en place un data seeding

Etape 5 : Enregistrer DbContext dans le conteneur de services et utiliser une connection string

Ensuite on peut tester la base de données!

### Utilisation de Entity Framework Core dans un controller

#### Injections de dépendances dans le controller

Pour utiliser Entity Framework Core dans un controller, nous devons injecter DbContext dans le controller. Pour ce faire, nous devons ajouter un champ privé readonly de type DbContext dans le controller et ajouter un constructeur qui prend en paramètre DbContext :

```csharp
private readonly SchoolContext _context;

public InstructorController(SchoolContext context)
{
    _context = context;
}
```

#### Les etapes de mise en place de Entity Framework Core

1. Créer vos classes d'entité (modèles)
2. Installer les packages nécessaires (Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Design, Pomelo.EntityFrameworkCore.MySql, Microsoft.EntityFrameworkCore.Tools)
3. Créer une classe qui hérite de DbContext
4. Configurer la methode OnModelCreating pour definir les relations entre les tables
5. Creer une migration avec la commande `dotnet ef migrations add InitialCreate`
6. Appliquer la migration avec la commande `dotnet ef database update`

## Les vues typees dynamiquement

Dans la section précédente, nous avons vu comment utiliser des vues fortement typées. Dans cette section, nous allons voir comment utiliser des vues typées dynamiquement.

Dans une vue typée dynamiquement, nous n'avons pas de directive @model en haut de la page de la vue. Cela signifie que la vue ne travaille pas avec un modèle spécifique. Cela signifie également que nous ne pouvons pas utiliser les expressions Razor fortement typées (comme @Model.FirstName).

Au lieu de cela, nous devons utiliser des expressions Razor dynamiques. Par exemple, pour afficher le contenu d'une propriété FirstName, nous devons utiliser @ViewData["FirstName"].

## Tuples et ViewModel

Dans la section précédente, nous avons vu comment utiliser des vues typées dynamiquement. Dans cette section, nous allons voir comment utiliser des tuples et des ViewModel.

```csharp
// Méthode 1 : Utilisation d'un ViewModel

// Étape 1 : Définir vos modèles individuels
public class ModelUtilisateur
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Email { get; set; }
}

public class ModelProduit
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public decimal Prix { get; set; }
}

// Étape 2 : Créer un ViewModel qui combine les deux modèles
public class UtilisateurProduitViewModel
{
    public ModelUtilisateur Utilisateur { get; set; }
    public List<ModelProduit> Produits { get; set; }
}

// Étape 3 : Dans votre contrôleur
public class AccueilController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new UtilisateurProduitViewModel
        {
            Utilisateur = new ModelUtilisateur { Id = 1, Nom = "Jean Dupont", Email = "jean@exemple.com" },
            Produits = new List<ModelProduit>
            {
                new ModelProduit { Id = 1, Nom = "Produit 1", Prix = 19.99m },
                new ModelProduit { Id = 2, Nom = "Produit 2", Prix = 29.99m }
            }
        };

        return View(viewModel);
    }
}

// Étape 4 : Dans votre vue (Index.cshtml)
@model UtilisateurProduitViewModel

<h2>Informations de l'utilisateur</h2>
<p>Nom : @Model.Utilisateur.Nom</p>
<p>Email : @Model.Utilisateur.Email</p>

<h2>Produits</h2>
<ul>
    @foreach (var produit in Model.Produits)
    {
        <li>@produit.Nom - @produit.Prix €</li>
    }
</ul>

// Méthode 2 : Utilisation de Tuple

// Dans votre contrôleur
public class AccueilController : Controller
{
    public IActionResult Index()
    {
        var utilisateur = new ModelUtilisateur { Id = 1, Nom = "Jean Dupont", Email = "jean@exemple.com" };
        var produits = new List<ModelProduit>
        {
            new ModelProduit { Id = 1, Nom = "Produit 1", Prix = 19.99m },
            new ModelProduit { Id = 2, Nom = "Produit 2", Prix = 29.99m }
        };

        return View((utilisateur, produits));
    }
}

// Dans votre vue (Index.cshtml)
@model (ModelUtilisateur Utilisateur, List<ModelProduit> Produits)

<h2>Informations de l'utilisateur</h2>
<p>Nom : @Model.Utilisateur.Nom</p>
<p>Email : @Model.Utilisateur.Email</p>

<h2>Produits</h2>
<ul>
    @foreach (var produit in Model.Produits)
    {
        <li>@produit.Nom - @produit.Prix €</li>
    }
</ul>

```

Permettez-moi d'expliquer ces deux méthodes :

1. Utilisation d'un ViewModel :

   - C'est l'approche la plus courante et recommandée pour les vues complexes.
   - Vous créez une nouvelle classe (ViewModel) qui contient des propriétés pour toutes les données dont vous avez besoin dans votre vue.
   - Cette méthode offre une séparation claire des préoccupations et rend votre code plus facile à maintenir.
   - Elle est particulièrement utile lorsque vous devez ajouter des propriétés ou des méthodes spécifiques à la vue.

2. Utilisation de Tuple :
   - Cette méthode est plus simple et peut être utile pour des implémentations rapides ou lorsque vous ne voulez pas créer une classe ViewModel séparée.
   - Elle est prise en charge dans C# 7.0 et versions ultérieures, ce qui inclut .NET Core 2.0 et supérieur.
   - Bien que pratique, elle peut rendre votre code moins lisible si elle est surutilisée, en particulier avec des modèles complexes.

Les deux méthodes vous permettent de typer fortement vos vues, ce qui offre une meilleure vérification à la compilation et un support IntelliSense amélioré.

Quelques points supplémentaires à considérer :

1. Si vous utilisez beaucoup de combinaisons différentes de modèles, vous voudrez peut-être créer plusieurs ViewModels pour garder les choses organisées.

2. Pour des cas très simples où vous avez juste besoin de passer deux ou trois propriétés, vous pourriez aussi utiliser le ViewBag ou ViewData dynamiques, mais ils sont généralement déconseillés pour des scénarios complexes car ils ne sont pas fortement typés.

3. Si vous travaillez avec des formulaires qui doivent être mappés à plusieurs modèles, vous pourriez avoir besoin de créer des binders de modèle personnalisés ou d'utiliser des préfixes de formulaire pour lier correctement les données.

4. N'oubliez pas que l'utilisation de plusieurs modèles peut parfois indiquer que votre vue fait trop de choses. Envisagez de diviser les vues complexes en vues partielles ou en composants si elles deviennent trop difficiles à gérer.

Souhaitez-vous que je développe davantage une partie de ces méthodes ou que je vous fournisse un exemple de gestion des soumissions de formulaires avec plusieurs modèles ?

## filtres, layouts, barre de navigation, authentification et autorisation

### Apporter la cohérence à nos pages avec les Razor Layouts

#### Creer un Layout

Les layouts sont des fichiers `cshtml` placés dans le dossier `Views/Shared`. Dans ce dossier **Shared** nous allons créer un fichier **\_Layout.cshtml**.

```html
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewBag.Title</title>
    <link
      rel="stylesheet"
      href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"
    />
    <link rel="stylesheet" href="~/css/site.css" />
  </head>
  <body>
    <div>@RenderBody()</div>
  </body>
</html>
```

Vous pouvez considerer un layout comme de l'HTML commun à toutes les pages de votre site. Il contient les balises `<head>`, `<body>`, `<html>` et d'autres balises communes à toutes les pages de votre site, on remarque :

- Le titre provient de la propriété ViewBag.Title.
- Le contenu de la page est rendu à l'aide de la méthode RenderBody().
  - c'est la que le contenu des vues sera affiché
  - si vous placer du code html dans le layout, il sera affiché sur toutes les pages.

#### Utiliser un Layout dans une vue

Pour utiliser un layout dans une vue, il suffit de specifier le layout dans la directive `@layout` au debut de la vue.

```html
@{ Layout = "_Layout"; }
```

Cette directive permet de placer le contenu de la vue dans le layout.

#### Le fichier \_ViewStart.cshtml

Au lieu de copier le code ci-dessus au debut de chaque vue, nous pouvons utiliser un fichier \_ViewStart.cshtml. Ce fichier est placé dans le dossier Views et son contenu sera appliqué à toutes les vues du dossier.

```html
@{ Layout = "_Layout"; }
```

#### Modifier les vues pour utiliser \_ViewStart.cshtml

- ne conservver que le code initalement contenu dans la balise `<body>` de la vue.
- ne surtout pas supprimer la directive @model de la vue
- Pour chaque vue vous devez choisir un titre unique pour la page et le placer dans la propriété ViewBag.Title
- Si vous aviez du css et/ou du Js dans la vue, vous pouvez les placer dans le layout.

## La suite: Deploiement de l'application, securité et tests
