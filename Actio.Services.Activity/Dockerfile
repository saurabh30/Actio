FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /dotnetapp
COPY ./bin/Docker .
ENV ASPNETCORE_URLS http://*:5050
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT ["dotnet", "Actio.Services.Activity.dll"]