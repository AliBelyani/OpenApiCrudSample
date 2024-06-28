

After each project build, the following two scripts are executed automatically.

    1-The Swagger-generated JSON file should be automatically placed into the 'swagger' folder within the Angular project.
    2-A command using npm is executed to retrieve information from the generated Swagger file into the desired services within the Angular project, which will ultimately create or update our services and models.


If we need to manually retrieve the service information from the JSON file, we should run the following code in the Angular project:
    npm run generate-clients