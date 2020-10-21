#### Translator (Web-MVC application) - Version 0.0.1 Beta

### About
- Translator is an open-source web application that is designed to translate English words to Spanish words. In particular, in the current version, user will be able to only translate from English to Spanish. In addtion, user can add **[1]** standard list(s) of English words with their Spanish definitions to the database. The current version is implemented for testing and learning purposes. In the next few versions, other features, such as translation from English to French, German, Latin, Italian, and Portuguese will be implemented.

**[1]** Standard list means the file should be in a specific format as the application is designed. Please see [this file](http://www.june29.com/IDP/files/Spanish.txt) to have a better idea of the standard list.

### Installation
- Clone this repository
- Create appsetting.json in top-level folder of the application and configure and setup your database settings (MySQL)
-	Generate the schema from the model class using
> `dotnet ef migrations add InitialSchema` and
> `dotnet ef database update`
- Upload [this file](http://www.june29.com/IDP/files/Spanish.txt) to the database from localhost:8080/English/Add
