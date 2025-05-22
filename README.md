The goal of this hobby project is to gather data about the 1v1 player base in Stormgate,
using the public API found here: https://stormgate.untapped.gg/en/docs/api

#How to run
1) Run the following command in the docker directory:
docker compose up

2) Open Package Manager Console and run the following commands:
Add-Migration InitialCreate
Update-Database

Delete the old Migrations folder if there is one.
Note: Update-Database will also create the database if it does not exist.
This is useful when the Docker container/volume has been wiped.

3) Build, run, and go to Swagger UI to test the APIs:
https://localhost:{yourPort}/swagger/index.html
